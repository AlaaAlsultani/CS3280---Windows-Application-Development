using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS3280A6.classes
{
    /// <summary>
    /// Passenger class representing the Passenger table in the DB
    /// </summary>
    public class Passenger
    {
        /// <summary>
        /// Passenger's Id
        /// </summary>
        private int Id;
        /// <summary>
        /// Passenger's first name
        /// </summary>
        private string FirstName;
        /// <summary>
        /// Passenger's last name
        /// </summary>
        private string LastName;

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
        /// Getter method for the first name
        /// </summary>
        public string _FirstName
        {
            get
            {
                return this.FirstName;
            }
        }

        /// <summary>
        /// Getter method for the last name
        /// </summary>
        public string _LastName
        {
            get
            {
                return this.LastName;
            }
        }

        /// <summary>
        /// Getter method for the full name
        /// </summary>
        public string _FullName
        {
            get
            {
                return this.FirstName + " " + this.LastName;
            }
        }

        /// <summary>
        /// Defualt constructor
        /// </summary>
        public Passenger() { }

        /// <summary>
        /// Full constructor
        /// </summary>
        /// <param name="_Id">Id of the new Passenger</param>
        /// <param name="_FirstName">First name of the new Passenger</param>
        /// <param name="_LastName">Last name of the new Passenger</param>
        public Passenger(int _Id, string _FirstName, string _LastName)
        {
            this.Id = _Id;
            this.FirstName = _FirstName;
            this.LastName = _LastName;
        }
    }
}
