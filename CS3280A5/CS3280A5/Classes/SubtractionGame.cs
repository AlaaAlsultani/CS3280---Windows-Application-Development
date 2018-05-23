using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CS3280A5.Classes
{
    /// <summary>
    /// Extends the Game class. Implements a method for generating a multipication problem.
    /// </summary>
    public class SubtractionGame : Game
    {

        /// <summary>
        /// Constructor for a SubtractionGame. Passes the Player object to the Game super class.
        /// </summary>
        /// <param name="p">Person playing the game</param>
        public SubtractionGame(Player p) : base(p) { }

        /// <summary>
        /// Overidden method for generating a subtraction problem
        /// </summary>
        /// <returns>A problem object containing the operands and solution</returns>
        public override Problem GenerateProblem()
        {
            try
            {
                Random r = new Random();
                //Generate a random number
                int num1 = r.Next(10) + 2;
                //Generate a second number and add the first number. Ensures the number is larger.
                int num2 = r.Next(10) + num1;
                //Decrement remaining rounds
                RemRounds--;
                //Return the problem
                return new Problem(num2, num1, num2 - num1);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Gets the operator representing the class type
        /// </summary>
        /// <returns>The operator representing the class type</returns>
        public override string GetOperator()
        {
            try
            {
                return "-";
            }
            catch(Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                   MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}
