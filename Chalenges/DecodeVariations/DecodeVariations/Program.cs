using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DecodeVariations
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = new []{'1','2','6','2'};
            char[,] i = new char[9,9];
            
            var result = decodeVariations(input);
            Console.WriteLine(result);
            Console.ReadKey();


        }


        static int decodeVariations(char[] S)
        {
            int pre = 27;
            int cur = 0;
            int first = 1;
            int second = 1;

            foreach (var i in S)
            {
                int d = Int32.Parse(i.ToString());
                if (d == 0)
                {
                    cur = 0;
                }
                else
                {
                    cur = first;
                    if (d * 10 + pre < 27)
                    {
                        cur += second;
                    }
                }

                pre = d;
                first = cur;
                second = first;
            }

            return cur;


        }

    }
}
