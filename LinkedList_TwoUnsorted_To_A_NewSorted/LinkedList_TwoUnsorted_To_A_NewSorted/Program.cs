using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinkedList_TwoUnsorted_To_A_NewSorted
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("LinkedList 1. Insert the 3 val separated by , :");
            int[] val1 = Console.ReadLine()?.Split(',').Select(n => Convert.ToInt32(n)).ToArray();
            Console.WriteLine("LinkedList 2. Insert the 3 val separated by , :");
            int[] val2 = Console.ReadLine()?.Split(',').Select(n => Convert.ToInt32(n)).ToArray();

            //LinkedLists ToDo: Validations for NULL
            LinkedList<int> l1 = new LinkedList<int>(val1);
            LinkedList<int> l2 = new LinkedList<int>(val2);
            
            LinkedList<int> l3 = new LinkedList<int>(l1.Concat(l2)); //Concatenated List
            LinkedList<int> l4 = new LinkedList<int>();//Result List

            var currentNodeL3 = l3.First;            
            var currentNodeL4 = l4.First;


            while (currentNodeL3 != null)
            {
                if (currentNodeL4 == null) //FirstTime
                        {
                            l4.AddFirst(currentNodeL3.Value);
                            currentNodeL4 = l4.First;
                            currentNodeL3 = currentNodeL3.Next;
                            continue;
                        }

                addToL4(currentNodeL3.Value, ref l4, currentNodeL4);
                currentNodeL4 = l4.First;
                currentNodeL3 = currentNodeL3.Next;                    
                }
            Console.Write($"The sorted list is:  {String.Join(",", l4)}");
            Console.ReadKey();
       }

        static void addToL4(int item, ref LinkedList<int> l4, LinkedListNode<int> currentNodeL4)
        {

            
            if (item <= currentNodeL4.Value)
            {
                if (currentNodeL4.Previous != null && item <= currentNodeL4.Previous.Value)
                {
                    currentNodeL4 = currentNodeL4.Previous;
                    addToL4(item, ref l4, currentNodeL4);
                }
                else
                {
                    l4.AddBefore(currentNodeL4, item);
                }
                
            }
            else
            {
                if (currentNodeL4.Next != null && item >= currentNodeL4.Next.Value)
                {
                    currentNodeL4 = currentNodeL4.Next;
                    addToL4(item, ref l4, currentNodeL4);                    
                }
                else
                {
                    l4.AddAfter(currentNodeL4, item);
                } 
                
            }
        }

    }
}
