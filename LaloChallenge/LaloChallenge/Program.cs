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
                        Console.WriteLine(Challenge1.FizzBuzz());
                        break;
                    case "3":
                        Console.WriteLine("Aun no lo hago :)");
                        break;
                    case "4":
                        Console.WriteLine("Firt word: ");
                        string str1 = Console.ReadLine();
                        Console.WriteLine("Second word: ");
                        string str2 = Console.ReadLine();
                        Console.WriteLine("\n"+Challenge1.Anagram(str1,str2));                        
                        break;
                    case "5":
                        Console.WriteLine("Word to reverse: ");
                        string strToCompress = Console.ReadLine();
                        Console.WriteLine("\n" + String.Join("", Challenge1.Compress(strToCompress)));
                        break;
                    case "6":
                        Console.WriteLine("Word to reverse: ");
                        string strToReverse = Console.ReadLine();
                        Console.WriteLine("\n" + String.Join("",Challenge1.Reverse(strToReverse)));
                        break;
                    

                }
            } while (msg != "exit");

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }
}
