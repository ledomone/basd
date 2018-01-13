using System;
using System.Threading;

namespace Episode4.Models
{
    public class Delegates
    {
        public delegate void Write(string message);
        public delegate int Add(int x, int y);
        public delegate void Alert(int change);

        public void Test()
        {
            Write writer = WriteMessage;
            Add adder = AddTwoNumbers;
            writer("Dominik");
            var sum = adder(1, 7);
            Console.WriteLine(sum);
            CheckTemperature(TooLowAlert, OptimalAlert, TooHighAlert);
        }

        public static void TooLowAlert(int change)
        {
            Console.WriteLine($"Temperature is too low (changed by {change}).");
        }

        public static void OptimalAlert(int change)
        {
            Console.WriteLine($"Temperature is optimal (changed by {change}).");
        }

        public static void TooHighAlert(int change)
        {
            Console.WriteLine($"Temperature is too high (changed by {change}).");
        }

        public static void CheckTemperature(Alert tooLow, Alert optimal, Alert tooHigh)
        {
            var temperature = 10;
            var random = new Random();

            while(true)
            {
                var change = random.Next(-5, 5);
                temperature += change;
                Console.WriteLine($"Temperature is at: {temperature} C.");
                if (temperature <= 0)
                {
                    tooLow(change);
                }
                else if (temperature > 0 && temperature <= 10)
                {
                    optimal(change);
                }
                else
                {
                    tooHigh(change);
                }
                Thread.Sleep(500);
            }
        }

        public static int AddTwoNumbers(int a, int b)
        {
            return a + b;
        }

        public static void WriteMessage(string msg)
        {
            Console.WriteLine($"Hello {msg}!");
        }
    }

    public class LambdaExpressions
    {
        public delegate void Write(string message);
        public delegate int Add(int x, int y);
        public delegate void Alert(int change);

        public void Test()
        {
            Action writer = () => Console.WriteLine("Writing...");
            Action<string, int> advancedWriter = (message, number) => 
                                Console.WriteLine($"{message}, {number}");
            writer();
            advancedWriter("Sajonara", 42);

            Func<int, int, int> adder = (x, y) => x + y;
            advancedWriter("Hello", 5);

            var sum = adder(1,6);
            advancedWriter("sum", sum);
        }
    }
}
