using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CS3280A5.Classes
{
    /// <summary>
    /// Player object containing Name and Age
    /// </summary>
    public class Player
    {
        /// <summary>
        /// Age of the Player
        /// </summary>
        private int Age { get; set; }
        /// <summary>
        /// Name of the Player
        /// </summary>
        private string Name { get; set; }

        /// <summary>
        /// Constructor for the Player class.
        /// </summary>
        /// <param name="_Age">Age of the Player</param>
        /// <param name="_Name">Name of the Player</param>
        public Player(int _Age, string _Name)
        {
            try
            {
                Age = _Age;
                Name = _Name;
            }
            catch(Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                   MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Get the Player's Age
        /// </summary>
        /// <returns>Player's Age</returns>
        public int GetAge()
        {
            try
            {
                return this.Age;
            }
            catch(Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                   MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Get the Player's Name
        /// </summary>
        /// <returns>Player's Name</returns>
        public string GetName()
        {
            try
            {
                return this.Name;
            }
            catch(Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                   MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}
