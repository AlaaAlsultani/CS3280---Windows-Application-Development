using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CS3280A6.dao
{
    /// <summary>
    /// Class that facilitates communication to the DB
    /// </summary>
    public class DataAccess
    {
        /// <summary>
        /// Connection string to the DB
        /// </summary>
        private string DBConnectionString;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public DataAccess()
        {
            DBConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data source= ..\\..\\dao\\ReservationSystem.mdb";
        }

        /// <summary>
        /// Executes a Scalar call to the DB
        /// </summary>
        /// <param name="cmd">OleDbCommand object</param>
        /// <returns>A string returned by DB</returns>
        public string ExecuteScalarSQL(OleDbCommand cmd)
        {
            try
            {
                object obj;

                using(OleDbConnection conn = new OleDbConnection(DBConnectionString))
                {
                    using(OleDbDataAdapter adapter = new OleDbDataAdapter())
                    {

                        conn.Open();

                        cmd.Connection = conn;
                        adapter.SelectCommand = cmd;
                        adapter.SelectCommand.CommandTimeout = 0;

                        obj = adapter.SelectCommand.ExecuteScalar();
                    }
                }

                return obj == null ? "" : obj.ToString();
            }
            catch(Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + 
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Execute a normal SQL statement
        /// </summary>
        /// <param name="cmd">OleDbCommand object</param>
        /// <param name="iRetVal">Reference to an integer to hold the returned vlue</param>
        /// <returns>A DataSet returned by the DB</returns>
        public DataSet ExecuteSQLStatement(OleDbCommand cmd, ref int iRetVal)
        {
            try
            {
                DataSet ds = new DataSet();

                using (OleDbConnection conn = new OleDbConnection(DBConnectionString))
                {
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter())
                    {

                        conn.Open();

                        cmd.Connection = conn;
                        adapter.SelectCommand = cmd;
                        adapter.SelectCommand.CommandTimeout = 0;

                        adapter.Fill(ds);

                    }
                }

                iRetVal = ds.Tables[0].Rows.Count;

                return ds;
            }
            catch(Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Execute a Non Query to the DB
        /// </summary>
        /// <param name="SQLStatement">A string with the SQL Query</param>
        /// <returns>An integer returned by DB</returns>
        public int ExecuteNonQuery(OleDbCommand cmd)
        {
            try
            {

                int numRows;

                using(OleDbConnection conn = new OleDbConnection(DBConnectionString))
                {

                    conn.Open();

                    cmd.Connection = conn;
                    cmd.CommandTimeout = 0;

                    numRows = cmd.ExecuteNonQuery();
                }

                return numRows;

            }
            catch(Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

    }
}
