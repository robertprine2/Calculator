using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;

namespace Calculator
{
    public class Program
    {
        // Allows user to continue using the calculator without closing the console every use
        static void Main(string[] args)
        {
            bool displayMenu = true;
            while (displayMenu)
            {
                displayMenu = MainMenu();
            }
        }

        // Prompt user for entry
        private static bool MainMenu()
        {
            Console.WriteLine("Enter an equation to solve (use +, -, *, or /) or 'exit' to quit.");

            // store user entry
            string problem = Console.ReadLine();
            
            // Apparently don't need this since "," are not in the way when performing operations
            //problem.Replace(@",", "");

            // Why doesn't replacing the = sign work and why does it break my code?
            //problem.Replace(@"=", "");

            var regexItem = new Regex(@"^(?<firstNumber>[0-9\.,]+)\s*(?<operator>[+\-*/]{1})\s*(?<secondNumber>[0-9\.,]+)$");
            var matchItem = regexItem.Match(problem);

            if (problem.Equals("exit", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            else if (matchItem.Success)
            {
                // Split the problem string into string a (first number) and string b (second number)
                int location = problem.IndexOf("+");
                string a = matchItem.Groups["firstNumber"].Value;
                string operation = matchItem.Groups["operator"].Value;
                string b = matchItem.Groups["secondNumber"].Value;

                // Change strings a and b to floats
                float aNumber = float.Parse(a, CultureInfo.InvariantCulture.NumberFormat);
                float bNumber = float.Parse(b, CultureInfo.InvariantCulture.NumberFormat);

                // Calculate the answer
                float c = Calculate(aNumber, operation, bNumber);

                // Print answer to console and a seperator for readability
                Console.WriteLine("The answer to {0:#,#0.#####} {1} {2:#,#0.#####} is {3:#,#0.#####}", aNumber, operation, bNumber, c);
                Console.WriteLine("----------------------------------------------------------");

                return true;
            }

            else
            {
                Console.WriteLine("Your entry is invalid. Please only enter numbers and operations. :)");
                return true;
            }
          
        }

        // Uses user entry to solve a mathmatical problem
        public static float Calculate(float aNumber, string operation, float bNumber)
        {
            float c = 0;

            if (operation.Contains("+"))
            {
                // Perform calculation based on if statement
                c = aNumber + bNumber;
            } // end of if +

            else if (operation.Contains("-"))
            {
                // Perform calculation based on if statement
                c = aNumber - bNumber;
            } // end of else if -

            else if (operation.Contains("/"))
            {
                // Perform calculation based on if statement
                c = aNumber / bNumber;
            } // end of else if /

            else if (operation.Contains("*"))
            {
                // Perform calculation based on if statement
                c = aNumber * bNumber;
            } // end of else if * 

            return c;

        } // end of Calculate method
    } // end of Program class
} // end of Calculator namespace
