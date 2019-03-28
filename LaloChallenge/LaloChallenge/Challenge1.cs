using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Sorting;

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

        public static string FizzBuzz()
        {
            string result = "";
            for (int i = 1; i <= 200; i++)
            {
                string aux = "";
                if (i % 3 == 0)
                {
                    aux += "fizz";
                }

                if (i % 5 == 0)
                {
                    aux += "buzz";
                }

                result =result + "\n" + (aux != "" ? aux : i.ToString());

            }

            return result;
        }

        public static bool Anagram(string str1, string str2)
        {

            //Hashtable hashtbl1 = new Hashtable();
            //Hashtable hashtbl2 = new Hashtable();

            ////Loop over each item to add into the hashtable
            //foreach (var item in str1)
            //{
            //    hashtbl1[item] = 0;
            //}

            //foreach (var item in str2)
            //{
            //    hashtbl2[item] = 0;
            //}
            //Lo de arriba no jalo por que pueden estar repetidas las letras y eso es omitido por las tablas hash
            //var asasd = str1.ToCharArray().Select(Convert.ToInt32).ToArray();
            var sorted1 = QuickSort.Sort(str1.ToCharArray().Select(Convert.ToInt32).ToArray(), 0, str1.Length - 1);
            var sorted2 = QuickSort.Sort(str2.ToCharArray().Select(Convert.ToInt32).ToArray(), 0, str1.Length - 1);

            if (str1.Length != str2.Length)
            {
                return false;
            }

            for(int i =0; i<sorted1.Length;i++)
            {
                if (sorted1[i] != sorted2[i])
                {
                    return false;
                }
            }

            return true;
        }


        public static char[] Reverse(string str)
        {
            int index = str.Length;
            char[] result = new char[index];
            index --;//last index
            foreach (char item in str)
            {
                result[index] = item;
                index --;
            }

            return result;
        }

        internal static string Compress(string strToCompress)
        {            
            int lastindex = strToCompress.Length-1;
            string result="";
            
            int counter = 0;

            //Loop over the original string to fill the result string
            for (int i = 0; i <= lastindex; i++ )
            {
                //First loop
                if (i == 0)
                {
                    result += strToCompress[i];                                        
                    counter = 1;                                       
                    continue;
                }

                //If the actual character is the same than the last then increment the counter
                if (strToCompress[i] == strToCompress[i - 1])
                {
                    counter++;
                    
                }
                else
                {
                    //If no then add the las counter and the new character, also reset the counter.
                    result += counter.ToString() + strToCompress[i];
                    counter = 1;
                }

                if (i == lastindex)//LastCount
                {
                    result += counter.ToString();

                }
            }

            //Only if is smaller
            return result.Length < strToCompress.Length ? result: strToCompress;
        }
    }
}
