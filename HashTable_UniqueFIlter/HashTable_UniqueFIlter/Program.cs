using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HashTable_UniqueFIlter
{
    class Program
    {
        static void Main(string[] args)
        {
            //Define array that we want to delete duplicates
            string[] items = new[] {"mazda", "chevrolet", "mitsubishi", "dodge", "ford", "mitsubishi", "chevrolet", "mazda", "mazda", "chevrolet", "mitrubishi", "dodge", "ford", "mitsubishi", "chevrolet", "mazda" };

            Console.WriteLine($"\n\n-----------------HashTable------------------\n\n");
            Console.WriteLine($"Original Array: {String.Join(",", items)}\n");
            //Create the dictionary
            Hashtable hashtbl = new Hashtable();

            //Loop over each item to add into the hashtable
            foreach (var item in items)
            {
                hashtbl[item] = 0;
            }

            //Result: The Hashtable type doesn't accept duplicate keys
            Console.WriteLine(string.Join(", ", hashtbl.Keys.OfType<string>()));

            Console.ReadKey();


            Console.WriteLine("Enter n: ");
            int n = Convert.ToInt32(Console.ReadLine());

            int paths = NumOfPathsToDest(n, 1, 0);
            Console.WriteLine("Number of Paths: " + paths);
            Console.ReadKey();



        }

        public static int NumOfPathsToDest(int n, int startI, int startJ)
        {
            int result = 0;
            while (startI <= n -1 && startJ <= n -1)
            {
                if (startI + 1 <= n-1)
                {
                    Console.WriteLine($"({startI},{startJ})");
                    startI++;
                    result += NumOfPathsToDest(n, startI, startJ);
                    
                }
                if (startI >= startJ + 1)
                {
                    Console.WriteLine($"({startI},{startJ})");
                    startJ++;
                    result += NumOfPathsToDest(n, startI, startJ);
                    
                }

                if (startI >= n-1 || startJ >= startI) break;



            }

            if (startI == n-1 && startJ == n-1)
            {
                Console.WriteLine($"({startI},{startJ})");
                return result + 1;

            }
            return result;
            // your code goes here
        }
    }
}
