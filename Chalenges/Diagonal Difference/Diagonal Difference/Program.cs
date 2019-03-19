using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diagonal_Difference
{
    class Program
    {
        // Complete the diagonalDifference function below.
        static int diagonalDifference(int[][] arr)
        {
            int firstVal = 0;
            int secondVal = 0;
            int lasIndexI = 0;
            int FirstIndexJ = arr.GetLength(0) - 1;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(0); j++)
                {
                    if (i == j)
                    {
                        firstVal += arr[i][j];
                    }

                    if (i == lasIndexI && j == FirstIndexJ)
                    {
                        secondVal += arr[i][j];
                        lasIndexI++;
                        FirstIndexJ--;
                    }
                }
            }

            return Math.Abs(firstVal - secondVal);

        }
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            int[][] arr = new int[n][];

            for (int i = 0; i < n; i++)
            {
                arr[i] = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
            }

            int result = diagonalDifference(arr);

            Console.WriteLine(result);

            Console.ReadKey();
        }
    }
}

