using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delegate_Chalenge
{
    class Program
    {
        delegate double MyDelegate(double price);
        static void Main(string[] args)
        {
            MyDelegate f1;
            string zone = "";
            double price = 0;
            do
            {
                Console.WriteLine("Select the zone: ");
                zone = Console.ReadLine();
                Console.Write("What's the product price: ");
                price = Convert.ToDouble(Console.ReadLine());
                ShippingFees.CalculateFee(zone, ref price);
                Console.WriteLine("The shipping fee is: " + price);
            } while (zone != "exit");

        }

        

        
    }
}
