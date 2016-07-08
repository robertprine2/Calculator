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

            // Why can't I capture multiple events in the regex like this?
            //var regexItem = new Regex(@"^(?<firstNumber>[0-9\.,]{3})\s*(?<operator1>[+\-*/]{2})\s*");

            var regexItem = new Regex(@"^\s*(?<firstNumber>[0-9\.,]+)\s*(?<operator1>[+\-*/]{1})\s*(?<secondNumber>[0-9\.,]+)\s*(?<operator2>[+\-*/]*)\s*(?<thirdNumber>[0-9\.,]*)\s*$");
            var matchItem = regexItem.Match(problem);

            Console.WriteLine("{0} {1} {2} {3} {4}", matchItem.Groups["firstNumber"].Value, matchItem.Groups["operator1"].Value, matchItem.Groups["secondNumber"].Value, matchItem.Groups["operator2"].Value, matchItem.Groups["thirdNumber"].Value);

            if (problem.Equals("exit", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            else if (matchItem.Success)
            {
                // Split the problem string into string a (first number) and string b (second number)
                string a = matchItem.Groups["firstNumber"].Value;
                string operation = matchItem.Groups["operator1"].Value;
                string b = matchItem.Groups["secondNumber"].Value;
                string operation2 = matchItem.Groups["operator2"].Value;
                string c = matchItem.Groups["thirdNumber"].Value;

                // Change strings a and b to floats
                float aNumber = float.Parse(a, CultureInfo.InvariantCulture.NumberFormat);
                float bNumber = float.Parse(b, CultureInfo.InvariantCulture.NumberFormat);
                float cNumber = float.Parse(c, CultureInfo.InvariantCulture.NumberFormat);

                float f = 0;

                if ((operation2 == "*" || operation2 == "/") && (operation != "*" || operation != "/"))
                {
                    // Calculate the answer of the second and third numbers
                    float e = Calculate(bNumber, operation2, cNumber);
                    // Calculate the answer of the first number and the answer of the second and third numbers
                    f = Calculate(aNumber, operation, e);
                }

                else
                {
                    // Calculate the answer of the first and second number
                    float e = Calculate(aNumber, operation, bNumber);
                    // Calculate the answer of the answer of the first and second number and the third number
                    f = Calculate(e, operation2, cNumber);
                }
                
                // Print answer to console and a seperator for readability
                Console.WriteLine("The answer to {0:#,#0.#####} {1} {2:#,#0.#####} {3} {4:#,#0.#####} is {5:#,#0.#####}", aNumber, operation, bNumber, operation2, cNumber, f);
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
            float f = 0;

            if (operation.Contains("+"))
            {
                // Perform calculation based on if statement
                f = aNumber + bNumber;
            } // end of if +

            else if (operation.Contains("-"))
            {
                // Perform calculation based on if statement
                f = aNumber - bNumber;
            } // end of else if -

            else if (operation.Contains("/"))
            {
                // Perform calculation based on if statement
                f = aNumber / bNumber;
            } // end of else if /

            else if (operation.Contains("*"))
            {
                // Perform calculation based on if statement
                f = aNumber * bNumber;
            } // end of else if * 

            return f;

        } // end of Calculate method
    } // end of Program class
} // end of Calculator namespace
