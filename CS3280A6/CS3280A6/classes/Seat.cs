using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS3280A6.classes
{
    /// <summary>
    /// Seat class representing the seats table in the DB
    /// </summary>
    public class Seat
    {
        /// <summary>
        /// Id of the seat
        /// </summary>
        private int Id;
        /// <summary>
        /// X position of the seat
        /// </summary>
        private int X;
        /// <summary>
        /// Y position of the seat
        /// </summary>
        private int Y;
        /// <summary>
        /// Availability of the seat
        /// </summary>
        private bool Available;
        /// <summary>
        /// Seat number
        /// </summary>
        private int Number;

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
        /// Getter method for the X coordinate
        /// </summary>
        public int _X
        {
            get
            {
                return this.X;
            }
        }

        /// <summary>
        /// Getter  method for the Y coordinate
        /// </summary>
        public int _Y
        {
            get
            {
                return this.Y;
            }
        }

        /// <summary>
        /// Getter method for the availabilty
        /// </summary>
        public bool _Available
        {
            get
            {
                return this.Available;
            }
        }

        /// <summary>
        /// Getter method for the seat number
        /// </summary>
        public int _Number
        {
            get
            {
                return this.Number;
            }
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public Seat() { }

        /// <summary>
        /// Full constructor
        /// </summary>
        /// <param name="Id">New seat's id</param>
        /// <param name="X">New seat's X coordinate</param>
        /// <param name="Y">New seat's Y coordinate</param>
        /// <param name="Available">New seat's availability</param>
        /// <param name="Number">New seat's seat number</param>
        public Seat(int Id, int X, int Y, bool Available, int Number)
        {
            this.Id = Id;
            this.X = X;
            this.Y = Y;
            this.Available = Available;
            this.Number = Number;
        }
    }
}
