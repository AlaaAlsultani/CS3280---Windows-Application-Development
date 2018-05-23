using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CS3280A5.Classes
{
    /// <summary>
    /// Problem Class consisting of 2 operands and a solution
    /// </summary>
    public class Problem
    {
        /// <summary>
        /// First number in the Problem
        /// </summary>
        private int Num1 { get; set; }
        /// <summary>
        /// Second number in the Problem
        /// </summary>
        private int Num2 { get; set; }
        /// <summary>
        /// Solution to the Problem
        /// </summary>
        private int Solution { get; set; }

        /// <summary>
        /// Constructor for the Problem class. 
        /// Takes in 3 numbers representing the 2 operands and the solution.
        /// </summary>
        /// <param name="num1">First number in the Problem</param>
        /// <param name="num2">Second number in the Problem</param>
        /// <param name="solution">Solution to the Problem</param>
        public Problem(int num1, int num2, int solution)
        {
            try
            {
                this.Num1 = num1;
                this.Num2 = num2;
                this.Solution = solution;
            }
            catch(Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                   MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Get the first number in the Problem
        /// </summary>
        /// <returns>First number in the Problem</returns>
        public int GetNum1()
        {
            try
            {
                return this.Num1;
            }
            catch(Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                   MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Get the second number in the Problem
        /// </summary>
        /// <returns>Second number in the Problem</returns>
        public int GetNum2()
        {
            try
            {
                return this.Num2;
            }
            catch(Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                   MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Get the solution to the Problem
        /// </summary>
        /// <returns>Solution to the Problem</returns>
        public int GetSolution()
        {
            try
            {
                return this.Solution;
            }
            catch(Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                   MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }

}
