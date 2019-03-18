using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace List_Compare_the_Triplets
{
    class Program
    {
        // Complete the compareTriplets function below.
        static List<int> compareTriplets(List<int> a, List<int> b)
        {
            int[] result = new int[2];
            for (int i = 0; i <= 2; i++)
            {
                if (a[i] > b[i])
                {
                    result[0] += 1;
                }
                if (b[i] > a[i])
                {
                    result[1] += 1;
                }
            }
            return result.ToList();

        }
        static void Main(string[] args)
        {
            List<int> a = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(aTemp => Convert.ToInt32(aTemp)).ToList();

            List<int> b = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(bTemp => Convert.ToInt32(bTemp)).ToList();

            List<int> result = compareTriplets(a, b);

            Console.WriteLine(String.Join(" ", result));

            Console.ReadKey();
        }
    }
}
