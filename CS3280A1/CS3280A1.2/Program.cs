using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS3280A1._2
{
    /// <summary>
    /// Class for Assignment 1 Program 2
    /// </summary>
    class Program
    {
        /// <summary>
        /// Main Method for the Program class.
        /// </summary>
        /// <param name="args">Passed In Commandline Arguments</param>
        public static void Main(string[] args)
        {
            int num1;
            int num2;

            //Get user input and convert the 2 integers
            Console.Write("Please enter the first number: ");
            num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Please enter the second number: ");
            num2 = Convert.ToInt32(Console.ReadLine());

            //Adding whitespace for readability
            Console.Write("\n");

            //Print the various arithmetic expressions
            Console.WriteLine("{0} + {1} = {2}", num1, num2, num1 + num2);
            Console.WriteLine("{0} - {1} = {2}", num1, num2, num1 - num2);
            Console.WriteLine("{0} * {1} = {2}", num1, num2, num1 * num2);
            Console.WriteLine("{0} / {1} = {2}", num1, num2, num1 / num2);
            Console.WriteLine("{0} % {1} = {2}", num1, num2, num1 % num2);

            //Adding whitespace for readability
            Console.Write("\n");

            //Print the comparisons
            Console.WriteLine("{0} {1} {2}", num1, num1 < num2 ? "is less than" : "is not less than", num2);
            Console.WriteLine("{0} {1} {2}", num1, num1 > num2 ? "is greater than" : "is not greater than", num2);
            Console.WriteLine("{0} {1} {2}", num1, num1 == num2 ? "equals" : "does not equal", num2);

            //Wait for input before terminating program
            Console.ReadLine();
        }
    }
}
