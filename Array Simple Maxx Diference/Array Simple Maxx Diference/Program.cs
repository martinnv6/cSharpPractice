using System;
using System.Collections.Generic;
using System.Linq;


namespace Array_Simple_Maxx_Diference
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array={9,9,5,6,1,3,2};

            int result = maxDifference(array.ToList());

            //Array Simple Maxx
            Console.WriteLine($"\n\n-----------------Array Simple Maxx------------------\n\n");
            Console.WriteLine($"Original Array: {String.Join(",", array)}");
            Console.WriteLine($"Maxx difference: {result}");

            Console.ReadKey();


        }
        public static int maxDifference(List<int> nums)
        {
            int maximumSize = 0;
            for (int k = nums.Count; k > 0; k--)
            {
                maximumSize = maximumSize + k;
            }
            int[] arrayResult = new int[maximumSize];
            int index = 0;
            for (int i = 0; i < nums.Count; i++)
            {
                for (int j = i; j < nums.Count; j++)
                {
                    if (nums[i] < nums[j])
                    {
                        arrayResult[index] = nums[j] - nums[i];
                        index++;
                    }
                }
            }


            int biggest = 0;

            //Manual Operation
            //foreach (var i in arrayResult)
            //{
            //    if (i > biggest)
            //    {
            //        biggest = i;
            //    }
            //}

            //Using .NET
            //return arrayResult.Max();

            //Using Recursive method
            biggest = FindMax(arrayResult, 0, 0);

            return biggest;


        }

        public static int FindMax(int[] array, int lastIndex, int highestNumber)
        {
            if (lastIndex > array.Length - 1) return highestNumber;
            if (array[lastIndex] > highestNumber)
            {
                highestNumber = array[lastIndex];
            }

            lastIndex++;
            highestNumber = FindMax(array, lastIndex, highestNumber);

            return highestNumber;
        }
    }


}
