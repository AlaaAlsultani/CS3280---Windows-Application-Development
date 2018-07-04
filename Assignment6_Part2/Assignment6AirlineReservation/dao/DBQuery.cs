using CS3280A6.classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace CS3280A6.dao
{
    /// <summary>
    /// Class containing prewritten Queries to the DB
    /// </summary>
    public class DBQuery
    {
        /// <summary>
        /// Class that handles communication to the DB
        /// </summary>
        private DataAccess DA;

        /// <summary>
        /// Default constructor
        /// </summary>
        public DBQuery()
        {
            try
            {
                DA = new DataAccess();
            }
            catch(Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Retrieve all flights
        /// </summary>
        /// <returns>A BindingList of all Flights</returns>
        internal BindingList<Flight> SelectAllFlights()
        {
            try
            {
                BindingList<Flight> bFlights = new BindingList<Flight>();
                DataSet ds;

                OleDbCommand cmd = new OleDbCommand("SELECT * FROM Flight ORDER BY Flight_ID");

                int retVal = 0;

                ds = DA.ExecuteSQLStatement(cmd, ref retVal);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    bFlights.Add(new Flight(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]), dr[2].ToString()));
                }

                return bFlights;
            }
            catch(Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Retrieve a list of passengers by flight
        /// </summary>
        /// <param name="FlightId">Flight Id</param>
        /// <returns>A BindingList of Passengers on the provided flight</returns>
        internal BindingList<Passenger> SelectPassengersByFlight(int FlightId)
        {
            try
            {
                BindingList<Passenger> bPassengers = new BindingList<Passenger>();
                DataSet ds;

                OleDbCommand cmd = new OleDbCommand("SELECT P.Passenger_ID, P.First_Name, P.Last_Name FROM Flight_Passenger_Link FP INNER JOIN Passenger P ON " +
                    "FP.Passenger_ID = P.Passenger_ID WHERE Flight_ID = @FlightId");

                cmd.Parameters.Add("@FlightId", OleDbType.Integer).Value = FlightId;

                int retVal = 0;

                ds = DA.ExecuteSQLStatement(cmd, ref retVal);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    bPassengers.Add(new Passenger(Convert.ToInt32(dr[0]), dr[1].ToString(), dr[2].ToString()));
                }

                return bPassengers;
            }
            catch(Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Retrieve the seat number for the provided passenger on the provided flight
        /// </summary>
        /// <param name="PassengerId">Passenger's Id</param>
        /// <param name="FlightId">Flight Id</param>
        /// <returns>An int representing the Passenger's seat number</returns>
        public int SelectPassengerSeatNumberByFlight(int PassengerId, int FlightId)
        {
            try
            {
                string result;
                OleDbCommand cmd = new OleDbCommand("SELECT Seat_Number FROM Flight_Passenger_Link WHERE Flight_ID = @FlightId AND Passenger_ID = @PassengerId");

                cmd.Parameters.Add("@FlightId", OleDbType.Integer).Value = FlightId;
                cmd.Parameters.Add("@PassengerId", OleDbType.Integer).Value = PassengerId;

                result = DA.ExecuteScalarSQL(cmd);

                return result != "" ? Convert.ToInt32(result) : -1;
            }
            catch(Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Retrieve the seat information for the provided passenger on the provided flight
        /// </summary>
        /// <param name="FlightId">Flight Id</param>
        /// <param name="PassengerId">Passenger Id</param>
        /// <returns>A Seat object for the provided passenger on the provided flight</returns>
        public Seat SelectPassengerSeat(int FlightId, int PassengerId)
        {
            try
            {
                DataSet ds;
                OleDbCommand cmd = new OleDbCommand("SELECT FP.Seat_Number FROM Flight_Passenger_Link FP INNER JOIN Passenger P ON FP.Passenger_Id = P.Passenger_Id WHERE P.Passenger_Id = @PassengerId AND FP.Flight_Id = @FlightId");
                cmd.Parameters.Add("@PassengerId", OleDbType.Integer).Value = PassengerId;
                cmd.Parameters.Add("@FlightId", OleDbType.Integer).Value = FlightId;

                int seatNum = Convert.ToInt32(DA.ExecuteScalarSQL(cmd));

                cmd = new OleDbCommand("SELECT S.Seat_Id, S.X, S.Y, S.Available, S.Seat_Num FROM Seat_Flight_Link SF INNER JOIN Seats S ON SF.Seat_Id = S.Seat_Id WHERE SF.Flight_Id = @FlightId AND S.Seat_Num = @SeatNum");
                cmd.Parameters.Add("@FlightId", OleDbType.Integer).Value = FlightId;
                cmd.Parameters.Add("@SeatNum", OleDbType.Integer).Value = seatNum;

                int retVal = 0;

                ds = DA.ExecuteSQLStatement(cmd, ref retVal);

                DataRow dr = ds.Tables[0].Rows[0];
                return new Seat(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]), Convert.ToInt32(dr[2]), Convert.ToInt32(dr[3]) == 1 ? true : false, Convert.ToInt32(dr[4]));
            }
            catch(Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Retrieve the seats associated with the provided flight
        /// </summary>
        /// <param name="FlightId">Flight Id</param>
        /// <returns>A List of Seat objects</returns>
        public List<Seat> SelectSeatInfoByFlight(int FlightId)
        {
            try
            {
                DataSet ds;
                List<Seat> bSeat = new List<Seat>();
                OleDbCommand cmd = new OleDbCommand("SELECT S.Seat_Id, S.X, S.Y, S.Available, S.Seat_Num FROM Seats S INNER JOIN Seat_Flight_Link SF " +
                    "ON S.Seat_Id = SF.Seat_Id WHERE SF.Flight_Id = @FlightId");

                cmd.Parameters.Add("@FlightId", OleDbType.Integer).Value = FlightId;

                int retVal = 0;

                ds = DA.ExecuteSQLStatement(cmd, ref retVal);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    bSeat.Add(new Seat(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]), Convert.ToInt32(dr[2]), Convert.ToInt32(dr[3]) == 1 ? true : false, Convert.ToInt32(dr[4])));
                }

                return bSeat;
            }
            catch(Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        public void InsertNewPassenger(string FirstName, string LastName, int FlightId)
        {
            try
            {
                OleDbCommand cmd = new OleDbCommand("INSERT INTO Passenger(First_Name, Last_Name) VALUES (@FirstName, @LastName)");

                cmd.Parameters.Add("@FirstName", OleDbType.VarChar).Value = FirstName;
                cmd.Parameters.Add("@LastName", OleDbType.VarChar).Value = LastName;

                DA.ExecuteNonQuery(cmd);

                cmd = new OleDbCommand("SELECT TOP 1 Passenger_Id FROM Passenger ORDER BY Passenger_Id DESC");
                int identity = Convert.ToInt32(DA.ExecuteScalarSQL(cmd));

                cmd = new OleDbCommand("INSERT INTO Flight_Passenger_Link(Flight_Id, Passenger_Id) VALUES (@FlightId, @PassengerId)");
                cmd.Parameters.Add("@FlightId", OleDbType.Integer).Value = FlightId;
                cmd.Parameters.Add("PassengerId", OleDbType.Integer).Value = identity;

                DA.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Selects the last passenger that was inserted
        /// </summary>
        /// <returns>Last inserted passenger</returns>
        public Passenger SelectLastInsertedPassenger()
        {
            try
            {
                DataSet ds;
                OleDbCommand cmd = new OleDbCommand("SELECT * FROM Passenger ORDER BY Passenger_Id DESC");

                int retVal = 0;

                ds = DA.ExecuteSQLStatement(cmd, ref retVal);

                DataRow dr = ds.Tables[0].Rows[0];

                return new Passenger(Convert.ToInt32(dr[0]), dr[1].ToString(), dr[2].ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Selects the Passenger's Id depending on FlightId and Seat Number
        /// </summary>
        /// <param name="SeatNum">Passenger's Seat Number</param>
        /// <param name="FlightId">Passenger's Flight Id</param>
        /// <returns>Passenger's Id</returns>
        public int SelectPassengerIdBySeatNumberAndFlight(int SeatNum, int FlightId)
        {
            try
            {
                OleDbCommand cmd = new OleDbCommand("SELECT Passenger_Id FROM Flight_Passenger_Link WHERE Flight_Id = @FlightId AND Seat_Number = @SeatNum");
                cmd.Parameters.Add("@FlightId", OleDbType.Integer).Value = FlightId;
                cmd.Parameters.Add("@SeatNum", OleDbType.Integer).Value = SeatNum;

                string pId = DA.ExecuteScalarSQL(cmd);

                return pId == "" ? -1 : Convert.ToInt32(pId);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Selects a passenger by their ID
        /// </summary>
        /// <param name="PassengerId">Passenger's Id</param>
        /// <returns>A passenger corresponding to the Id</returns>
        public Passenger SelectPassengerById(int PassengerId)
        {
            try
            {
                DataSet ds;
                OleDbCommand cmd = new OleDbCommand("SELECT * FROM Passenger WHERE Passenger_Id = @PassengerId");

                cmd.Parameters.Add("@PassengerId", OleDbType.Integer).Value = PassengerId;

                int retVal = 0;

                ds = DA.ExecuteSQLStatement(cmd, ref retVal);

                DataRow dr = ds.Tables[0].Rows[0];
                return new Passenger(Convert.ToInt32(dr[0]), dr[1].ToString(), dr[2].ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Updates a Passengers Seat Number on provided flight
        /// </summary>
        /// <param name="FlightId">Flight Id</param>
        /// <param name="PassengerId">Passenger's Id</param>
        /// <param name="NewSeatNumber">New Seat Number</param>
        public void UpdatePassengerSeatNumber(int FlightId, int PassengerId, int NewSeatNumber)
        {
            try
            {
                OleDbCommand cmd;

                cmd = new OleDbCommand("SELECT Seat_Number FROM Flight_Passenger_Link WHERE Passenger_Id = @PassengerId AND Flight_Id = @FlightId");
                cmd.Parameters.Add("@PassengerId", OleDbType.Integer).Value = PassengerId;
                cmd.Parameters.Add("@FlightId", OleDbType.Integer).Value = FlightId;

                string oldSeatNumber = DA.ExecuteScalarSQL(cmd);


                string oldSeatId = "";
                if (oldSeatNumber != "")
                {
                    cmd = new OleDbCommand("SELECT S.Seat_Id FROM Seat_Flight_Link SF INNER JOIN Seats S ON SF.Seat_Id = S.Seat_Id WHERE SF.Flight_Id = @FlightId AND S.Seat_Num = @SeatNum");
                    cmd.Parameters.Add("@FlightId", OleDbType.Integer).Value = FlightId;
                    cmd.Parameters.Add("@SeatNum", OleDbType.Integer).Value = oldSeatNumber;
                    oldSeatId = DA.ExecuteScalarSQL(cmd);
                }

                cmd = new OleDbCommand("SELECT S.Seat_Id FROM Seat_Flight_Link SF INNER JOIN Seats S ON SF.Seat_Id = S.Seat_Id WHERE SF.Flight_Id = @FlightId AND S.Seat_Num = @SeatNum");
                cmd.Parameters.Add("@FlightId", OleDbType.Integer).Value = FlightId;
                cmd.Parameters.Add("@SeatNum", OleDbType.Integer).Value = NewSeatNumber;

                int newSeatId = Convert.ToInt32(DA.ExecuteScalarSQL(cmd));

                cmd = new OleDbCommand("UPDATE Flight_Passenger_Link SET Seat_Number = " + NewSeatNumber + " WHERE Flight_ID = " + FlightId + " AND Passenger_ID = " + PassengerId + ";");
                //cmd.Parameters.Add("@FlightId", OleDbType.Integer).Value = FlightId;
                //cmd.Parameters.Add("@PassengerId", OleDbType.Integer).Value = PassengerId;
                //cmd.Parameters.Add("@SeatNumber", OleDbType.Integer).Value = NewSeatNumber;

                
                DA.ExecuteNonQuery(cmd);

                if (oldSeatId != "")
                {
                    cmd = new OleDbCommand("UPDATE Seats SET Available = " + 1 + " WHERE Seat_Id = " + oldSeatId);
                    //cmd.Parameters.Add("@SeatId", OleDbType.Integer).Value = Convert.ToInt32(oldSeatId);

                    DA.ExecuteNonQuery(cmd);
                }

                cmd = new OleDbCommand("UPDATE Seats SET Available = " + 0 + " WHERE Seat_Id = " + newSeatId);
                //cmd.Parameters.Add("@SeatId", OleDbType.Integer).Value = newSeatId;

                DA.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Removes passenger from given flight
        /// </summary>
        /// <param name="PassengerId">Passenger's Id</param>
        /// <param name="FlightId">Flight Id</param>
        /// <param name="SeatId">Seat Id</param>
        public void RemovePassengerFromFlight(int PassengerId, int FlightId, int SeatId)
        {
            try
            {
                OleDbCommand cmd = new OleDbCommand("DELETE FROM Flight_Passenger_Link WHERE Flight_ID = @FlightId AND Passenger_ID = @PassengerId");
                cmd.Parameters.Add("@FlightId", OleDbType.Integer).Value = FlightId;
                cmd.Parameters.Add("@PassengerId", OleDbType.Integer).Value = PassengerId;

                DA.ExecuteNonQuery(cmd);

                cmd = new OleDbCommand("DELETE FROM Passenger WHERE Passenger_ID = @PassengerId");
                cmd.Parameters.Add("@PassengerId", OleDbType.Integer).Value = PassengerId;

                DA.ExecuteNonQuery(cmd);

                cmd = new OleDbCommand("UPDATE Seats SET Available = " + 1 + " WHERE Seat_Id = " + SeatId);
                DA.ExecuteNonQuery(cmd);
            }
            catch(Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}
