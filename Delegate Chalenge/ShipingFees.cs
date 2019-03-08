using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delegate_Chalenge
{
    public abstract class ShipingFees
    {
        delegate double MyDelegate(double price);

        public static void CalculateFee(string zone, ref double price)
        {
            MyDelegate f1;
            switch (zone)
            {
                case "zone1":
                    f1 = Zone1;
                    price = f1(price);
                    break;
                case "zone2":
                    f1 = Zone2;
                    price = f1(price);
                    break;
                case "zone3":
                    f1 = Zone3;
                    price = f1(price);
                    break;
                case "zone4":
                    f1 = Zone4;
                    price = f1(price);
                    break;

            }


        }
        static double Zone1(double price)
        {
            return (price * 0.25);
        }
        static double Zone2(double price)
        {
            return (price * 0.12 + 20);
        }
        static double Zone3(double price)
        {
            return (price * .08);
        }
        static double Zone4(double price)
        {
            return (price * 0.04 + 20);
        }
    }
}
