using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LaloChallenge
{
    static class Challenge1
    {
        public static double Summation()
        {
            double result = 0;
            for (int k = 1; k <= 10000000;k++)
            {
                result += (Math.Pow(-1, k - 1)) / (2 * k - 1);
            }

            return 4*result;
        }

        public static string FizzBuzz(int num)
        {
            string result = "";
            if (num % 3 == 0)
            {
                result += "fizz";
            }

            if (num % 5 == 0)
            {
                result += "buzz";
            }

            return result;
        }
    }
}
