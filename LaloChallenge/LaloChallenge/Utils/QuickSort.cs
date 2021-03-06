﻿using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sorting
{
    public static class QuickSort
    {

        public static int[] Sort(int[] set, int first, int last)
        {
            if (first < last)
            {
                int pivotIndex = Partition(set, first, last);
                Sort(set, first, pivotIndex - 1);
                Sort(set, pivotIndex + 1, last);
            }
            return set;
        }

        private static int Partition(int[] set, int first, int last)
        {
            //Chose the pivote
            int pivotValue = set[first];

            //Set the upper and lower indexes
            int lower = first + 1;
            int upper = last;

            //Searching the crossing point
            bool done = false;
            while (!done)
            {
                while (lower <= upper && set[lower] < pivotValue)
                {

                    lower++;

                }
                while (set[upper] >= pivotValue && upper >= lower)
                {

                    upper--;

                }

                if (lower > upper)
                {
                    done = true;
                }
                else
                {
                    int temp = set[lower];
                    set[lower] = set[upper];
                    set[upper] = temp;
                }


            }
            int temp2 = set[upper];
            set[upper] = pivotValue;
            set[first] = temp2;

            return upper;
        }
    }
}
