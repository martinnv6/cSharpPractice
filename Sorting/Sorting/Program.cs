using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] set = new[] { 22,7, 5,2 , 55, 11, 12, 67};

            //BubbleSort
            Console.WriteLine($"\n\n-----------------BubbleSort------------------\n\n");
            Console.WriteLine($"Original Array: {String.Join(",", set)}");
            BubbleSort.Sort(set);
            Console.WriteLine("Number of Iterations {0}",BubbleSort.IterationsCounter);
            Console.ReadKey();

            set = new[] { 22, 7, 5, 2, 55, 11, 12, 67 };
            //QuickSort
            Console.WriteLine($"\n\n-----------------BubbleSort------------------\n\n");
            Console.WriteLine($"Original Array: {String.Join(",", set)}");
            Console.WriteLine($"\nSorted Array: {String.Join(",", MergeSort.Sort(set))}"); 
            Console.WriteLine("Number of Iterations {0}", MergeSort.IterationsCounter);
            Console.ReadKey();

        }
    }
}
