using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace OrderedListSearch
{
    class Program
    {
        static int Iteration = 0;
        static void Main(string[] args)
        {
  
            int[] orderedList = new[] { 1, 3, 4, 5, 10, 33, 55, 6 };
            int[] itemsToFind = new[] {3, 55, 90};



            Console.WriteLine($"\n\n-----------------Ordered List Searching------------------\n\n");
            Console.WriteLine($"Original Array: {String.Join(",", orderedList)}");
            if (!IsSortedList(orderedList))
            {
                Console.WriteLine($"\nThe list is not sorted");
            }
            else
            {
                foreach (var i in itemsToFind)
                {
                    Iteration = 0;
                    Console.WriteLine($"\nItem to find: {i}");
                    Console.WriteLine($"Index found: {SearchItem(i, orderedList)}");
                }
            }

            Console.ReadKey();


        }

        private static bool IsSortedList(int[] set)
        {
            for(var i = 1;i<set.Length-1;i++)
            {
                if (set[i] > set[i + 1])
                {
                    return false;
                }
            }

            return true;
        }

        private static string SearchItem(int item, int[] set)
        {
            //First and last index in the list
            int lowerIndex = 0;
            int upperIndex = set.Length - 1;

            //Loop while the last index doesn't cross the firstIndex, that would means we finish with the list 
            while (lowerIndex < upperIndex)
            {
                //Place to divide the list
                int middleIndex = (lowerIndex + upperIndex) / 2;

                //If the place where divide the array is the item that we are searching
                if (item == set[middleIndex])
                {
                    return middleIndex.ToString();
                }
                //If not we ignore the side where is not the item, and move the index do it again.
                else
                {
                    if (item > set[middleIndex])
                    {
                        lowerIndex = middleIndex + 1;
                    }
                    else
                    {
                        upperIndex = middleIndex - 1;
                    }
                }
            }

            return "None";
        }
    }
}
