using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool displayMenu = true;
            while (displayMenu)
            {
                displayMenu = MainMenu();
            }
        }

        private static bool MainMenu()
        {
            Console.WriteLine("Enter an equation to solve or 'exit' to quit.");

            string problem = Console.ReadLine();

            if (problem.Equals("exit", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            else
            {
                Calculate(problem);
                return true;
            }
        }

        public static void Calculate(string problem)
        {
            if (problem.Contains("+"))
            {
                int location = problem.IndexOf("+");
                string a = problem.Substring(0, location);
                string b = problem.Substring(location + 1);
                int aNumber = ToInt32(a);
                Console.WriteLine(b);
                Console.ReadLine();
            }
        }

        public static void Addition()
        {

        }
    }
}
