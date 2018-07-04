using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS3280A6.classes
{
    /// <summary>
    /// Flight class representing the Flight table in the DB.
    /// </summary>
    class Flight
    {
        /// <summary>
        /// Id of the Flight
        /// </summary>
        private int Id;
        /// <summary>
        /// Number associated with the flight
        /// </summary>
        private int FlightNum;
        /// <summary>
        /// Aircraft type 
        /// </summary>
        private string Aircraft;

        /// <summary>
        /// Getter method for the Id
        /// </summary>
        public int _Id
        {
            get
            {
                return this.Id;
            }
        }

        /// <summary>
        /// Getter method for the Flight number
        /// </summary>
        public int _FlightNum
        {
            get
            {
                return this.FlightNum;
            }
        }

        /// <summary>
        /// Getter method for the Aircraft
        /// </summary>
        public string _Aircraft
        {
            get
            {
                return this.Aircraft;
            }
        }

        /// <summary>
        /// Getter method for the combination of Flight number and Aircraft
        /// </summary>
        public string _FlightDetails
        {
            get
            {
                return this.FlightNum + " : " + this.Aircraft;
            }
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public Flight() { }

        /// <summary>
        /// Full constructor
        /// </summary>
        /// <param name="_Id">Id of the new Flight</param>
        /// <param name="_FlightNum">Number of the new Flight</param>
        /// <param name="_Aircraft">Aircraft for the new Flight</param>
        public Flight(int _Id, int _FlightNum, string _Aircraft)
        {
            this.Id = _Id;
            this.FlightNum = _FlightNum;
            this.Aircraft = _Aircraft;
        }


    }
}
