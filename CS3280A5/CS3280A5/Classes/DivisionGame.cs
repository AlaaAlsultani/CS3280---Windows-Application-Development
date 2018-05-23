using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CS3280A5.Classes
{
    /// <summary>
    /// Extends the Game class. Implements a method for generating a division problem.
    /// </summary>
    public class DivisionGame : Game
    {
        /// <summary>
        /// Constructor for a DivisionGame. Passes the Player object to the Game super class.
        /// </summary>
        /// <param name="p">Person playing the game</param>
        public DivisionGame(Player p) : base(p) { }

        /// <summary>
        /// Overidden method for generating a division problem
        /// </summary>
        /// <returns>A problem object containing the operands and solution</returns>
        public override Problem GenerateProblem()
        {
            try
            {
                Random r = new Random();
                //Generate a random number
                int num2 = r.Next(10) + 2;
                //Generate the solution to the problem
                int solution = r.Next(10) + 2;
                //Decrement the rounds remaining
                RemRounds--;
                //The 1st number in the problem is the solution multiplied by the 2nd number
                return new Problem(num2 * solution, num2, solution);
            }
            catch(Exception ex)
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
                return "÷";
            }
            catch(Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                   MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}
