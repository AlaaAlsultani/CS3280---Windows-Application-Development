using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CS3280A5.Classes
{
    /// <summary>
    /// Extends the Game class. Implements a method for generating an addition problem.
    /// </summary>
    public class AdditionGame : Game
    {
        /// <summary>
        /// Constructor for an AdditionGame. Passes the Player object to the Game super class.
        /// </summary>
        /// <param name="p">Person playing the game</param>
        public AdditionGame(Player p) : base(p) { }

        /// <summary>
        /// Overidden method for generating an addition problem
        /// </summary>
        /// <returns>A problem object containing the operands and solution</returns>
        public override Problem GenerateProblem()
        {
            try
            {
                Random r = new Random();
                //Generate two numbers from 2 to 11
                int num1 = r.Next(10) + 2;
                int num2 = r.Next(10) + 2;
                //Decrement the number of rounds left
                RemRounds--;
                //Return the problem
                return new Problem(num1, num2, num1 + num2);
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
                return "+";
            }
            catch(Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                   MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}
