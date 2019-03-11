using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sorting
{
    
    public static class MergeSort
    {
        public static int IterationsCounter=0;
        public static int[] Sort(int[] set)
        {
            int middle = set.Length / 2;
            int[] result = new int[middle * 2];
            if (set.Length > 1)
            {
                
                
                int[] leftSet = new int[middle];
                int[] rightSet = new int[middle];


                //Fill left and right array
                for (int index = 0; index < middle; index++)
                {
                    leftSet[index] = set[index];
                    rightSet[index] = set[middle + index];
                }                
                
                //Recursivity calls divide array and sort into the deeper call 
                leftSet =Sort(leftSet);
                rightSet = Sort(rightSet);


                //Loop to compare
                return Merge(leftSet, rightSet);
            }

            return set;
        }

        private static int[] Merge(int[] leftSet, int[] rightSet)
        {
            int resultLenght = leftSet.Length + rightSet.Length;
            int[] result = new int[resultLenght];
            int i = 0, j = 0, k = 0;

            //While both sets having elements compare and sort
            while (i < leftSet.Length && j < rightSet.Length)
            {
                if (leftSet[i] < rightSet[j])
                {
                    result[k] = leftSet[i];
                    i++;
                }
                else
                {
                    result[k] = rightSet[j];
                    j++;
                }
                IterationsCounter++;

                k++;                
            }


            //If one of the sets have elements, copy at the end of setResult
            while (i < leftSet.Length)
            {
                result[k] = leftSet[i];
                i++;
                k++;
            }
            while (j < rightSet.Length)
            {
                result[k] = rightSet[j];
                j++;
                k++;
            }
            Console.WriteLine($"Iteration {IterationsCounter }: {String.Join(",", result)}");
           
            return result;
        }
    }
}
