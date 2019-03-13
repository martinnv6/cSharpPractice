using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace OrderedListSearch
{
    class Program
    {
        static void Main(string[] args)
        {
  
            int[] orderedList = new[] { 1, 3, 4, 5, 10, 33, 55, 68 };

            Console.WriteLine($"\n\n-----------------Ordered List Searching------------------\n\n");
            Console.WriteLine($"Original Array: {String.Join(",", orderedList)}");
            Console.WriteLine(SearchItem(3, orderedList));
            Console.WriteLine(SearchItem(55, orderedList));
            Console.WriteLine(SearchItem(90, orderedList).HasValue);
            Console.ReadKey();


        }

        private static int? SearchItem(int item, int[] set)
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
                    return middleIndex;
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

            return null;
        }
    }
}
