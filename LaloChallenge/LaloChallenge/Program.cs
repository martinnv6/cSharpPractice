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
                        Console.WriteLine("Base: ");
                        int baseInt = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("String(Numbers): ");
                        string numbers = Console.ReadLine();
                        Console.WriteLine("\n" + Challenge1.ConvertToBase(baseInt, numbers));
                        break;
                    case "4":
                        Console.WriteLine("Firt word: ");
                        string str1 = Console.ReadLine();
                        Console.WriteLine("Second word: ");
                        string str2 = Console.ReadLine();
                        Console.WriteLine("\n" + Challenge1.Anagram(str1, str2));
                        break;
                    case "5":
                        Console.WriteLine("Word to reverse: ");
                        string strToCompress = Console.ReadLine();
                        Console.WriteLine("\n" + String.Join("", Challenge1.Compress(strToCompress)));
                        break;
                    case "6":
                        Console.WriteLine("Word to reverse: ");
                        string strToReverse = Console.ReadLine();
                        Console.WriteLine("\n" + String.Join("", Challenge1.Reverse(strToReverse)));
                        break;
                    case "7":
                        Console.WriteLine("Firt number: ");
                        int int1 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Second number: ");
                        int int2 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("\n" + Challenge1.Swap(int1, int2));
                        break;
                    case "8":
                        Console.WriteLine("Indicate the M and N for the array separated by a space: ");
                        string[] MN = Console.ReadLine().Split(' ');
                        int M = Convert.ToInt32(MN[0]);
                        int N = Convert.ToInt32(MN[1]);
                        int[][] amounts = new int[N][];
                        Console.WriteLine("Indicate each row of the array (each number separated by a space): ");
                        Console.WriteLine("Example: \n2 3 4\n8 4 6\n8 0 2\n\n\n");
                        for (int amountsRowItr = 0; amountsRowItr < N; amountsRowItr++)
                        {
                            amounts[amountsRowItr] = Array.ConvertAll(Console.ReadLine().Split(' '), amountsTemp => Convert.ToInt32(amountsTemp));
                        }
                        var result = Challenge1.ArrayChallenge(amounts);
                        Console.WriteLine("\n\nResult:\n");
                        foreach (int[] i in result)
                        {
                            Console.Write("{0} \n", String.Join(" ",i));
                        }
                        //Console.WriteLine(result);
                        break;



                }
            } while (msg != "exit");

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }
}
