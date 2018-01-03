using System;

namespace Episode4.Models
{
    public class Delegates
    {
        public delegate void Write(string message);
        public delegate int Add(int x, int y);

        public void Test()
        {
            Write writer = WriteMessage;
            Add adder = AddTwoNumbers;
            writer("Dominik");
            var sum = adder(1, 7);
            Console.WriteLine(sum);
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
}