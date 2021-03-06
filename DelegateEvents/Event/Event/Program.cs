﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Event
{
    delegate void BalanceChangedHandler(decimal amount);

    class Balance
    {
        private decimal _amount;
        public event BalanceChangedHandler balanceChanged;

        public decimal amount
        {
            get
            {
                return _amount;
            }
            set
            {
                _amount = value;
                balanceChanged(value);
            }
        }

    }

    public class BalanceInfo
    {
        public void showBalance(decimal balance)
        {
            Console.WriteLine("The balance amount is {0}", balance);
        }
    }

    public class CheckGoal
    {
        public void checkGoal(decimal balance)
        {
            if (balance > 500)
            {
                Console.WriteLine("You saving ${0}, this is your goal!", balance);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Balance ba = new Balance();
            BalanceInfo bi = new BalanceInfo();
            CheckGoal cg = new CheckGoal();

            ba.balanceChanged += bi.showBalance;
            ba.balanceChanged += cg.checkGoal;

            string line = "";
            do
            {
                Console.WriteLine("Deposit: ");
                line = Console.ReadLine();
                if (line != "exit")
                {
                    decimal value = Convert.ToDecimal(line);
                    ba.amount += value;
                }

            } while (line!="exit");
        }
    }
}
