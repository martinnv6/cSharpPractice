using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Interfaces_RandomNumbers
{
    interface IRandom
    {
        void CreateRandom(int upperNumber);
    }

    

    public class RandomCustom: IRandom
    {
        public event PropertyChangedEventHandler PropertyChanged;        
        private int _randomNumber;

        private void NotifyPropChanged(string propName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        public int randomNumber
        {
            get { return _randomNumber; }
            set
            {
                _randomNumber = value;
                NotifyPropChanged("upperNumber");
            }
        }
        

        public void CreateRandom(int upperNumber)
        {
            Random randomNum = new Random();
            randomNumber = randomNum.Next(upperNumber);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            RandomCustom ran = new RandomCustom();

            ran.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
            {
                Console.WriteLine($"Property changed: {e.PropertyName} \nvalue: {ran.randomNumber}");
            };

            while (true)
            {
                Console.WriteLine("\nUpper Number to generate a random number: ");
                string value = Console.ReadLine();
                if (value == "exit")
                {
                    break;
                }

                if (int.TryParse(value, out var upperNumber))
                ran.CreateRandom(upperNumber);
            }
        }
    }
}
