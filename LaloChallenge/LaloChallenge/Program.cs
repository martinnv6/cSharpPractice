using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace LaloChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

            string msg = "";
            do
            {
                Console.WriteLine("\n\nSelect Challenge: \n\n1. Summation\n2. FizzBuzz\n3. BaseX\n4. Anagram\n5. Repeated Characters\n6. Reverse\n7. Swap Integer\n8. Matrix");
                msg = Console.ReadLine();
                switch (msg)
                {
                    case "1":
                        Console.WriteLine(Challenge1.Summation());
                        break;
                    case "2":
                        int num;
                        do
                        {
                            Console.WriteLine("Insert a number between 1 and 200");
                            num = Convert.ToInt32(Console.ReadLine());
                        } while (num < 1 && num > 200);
                        Console.WriteLine(Challenge1.FizzBuzz(num));
                        break;
                }
            } while (msg != "exit");

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }
}
