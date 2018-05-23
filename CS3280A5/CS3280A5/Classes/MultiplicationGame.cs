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
    public class MultiplicationGame : Game
    {
        /// <summary>
        /// Constructor for a MultiplicationGame. Passes the Player object to the Game super class.
        /// </summary>
        /// <param name="p">Person playing the game</param>
        public MultiplicationGame(Player p) : base(p) { }

        /// <summary>
        /// Overidden method for generating a multiplication problem
        /// </summary>
        /// <returns>A problem object containing the operands and solution</returns>
        public override Problem GenerateProblem()
        {
            try
            {
                Random r = new Random();
                //Generate two random numbers
                int num1 = r.Next(10) + 2;
                int num2 = r.Next(10) + 2;
                //Decrement the rounds remaining
                RemRounds--;
                //Solution is the 2 random numbers multiplied
                return new Problem(num1, num2, num1 * num2);
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
                return "*";
            }
            catch(Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                   MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}
