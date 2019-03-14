using System;
using System.Collections;
using System.Linq;

namespace HashTable_ValueCounting
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] items = new[] { "mazda", "chevrolet", "mitsubishi", "dodge", "ford", "mitsubishi", "chevrolet", "mazda", "mazda", "chevrolet", "mitrubishi", "dodge", "ford", "mitsubishi", "chevrolet", "mazda" };

            Console.WriteLine($"\n\n-----------------HashTable Value Counting------------------\n\n");
            Console.WriteLine($"Original Array: {String.Join(",", items)}\n");
            //Create the dictionary
            Hashtable hashtbl = new Hashtable();

            //Loop over each item to add into the hashtable
            foreach (var item in items)
            {
                if (hashtbl.ContainsKey(item))
                {
                    hashtbl[item] = (int)hashtbl[item] + 1;
                }
                else
                {
                    hashtbl[item] = 1;
                }
                
            }
            foreach (DictionaryEntry entry in hashtbl)
            {
                Console.WriteLine(entry.Key + ":" + entry.Value);
            }
            

            Console.ReadKey();
        }
    }
}
