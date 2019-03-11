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
            int[] set = new[] {7, 3, 5, 8, 1, 9, 4, 22, 55, 11, 12, 67};

            //BubbleSort
            Console.WriteLine($"\n\n-----------------BubbleSort------------------\n\n");
            Console.WriteLine($"Original Array: {String.Join(",", set)}");
            BubbleSort.Sort(set);
            Console.WriteLine("Number of Iterations {0}",BubbleSort.IterationsCounter);
            Console.ReadKey();

            
            //QuickSort
            Console.WriteLine($"\n\n-----------------BubbleSort------------------\n\n");
            Console.WriteLine($"Original Array: {String.Join(",", set)}");
            BubbleSort.Sort(set);
            Console.WriteLine("Number of Iterations {0}", BubbleSort.IterationsCounter);
            Console.ReadKey();

        }
    }
}
