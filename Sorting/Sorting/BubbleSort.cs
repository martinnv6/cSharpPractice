using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sorting
{
    public static class BubbleSort
    {
        public static int IterationsCounter;
        public static bool PrintIterations;
        public static int[] Sort(int[] set)
        {

            for (int i = 1; i < set.Length; i++)
            {

                for (int j = 0; j < set.Length-1; j++)
                {
                    if (set[j] > set[j+1])
                    {
                        int temp = set[j + 1];
                        set[j + 1] = set[j];
                        set[j] = temp;
                    }
                    if(PrintIterations)Console.WriteLine($"Iteration {IterationsCounter + 1 }: {String.Join(",", set)}");
                    IterationsCounter++;
                }
            }
            return set;

        }
    }
}
