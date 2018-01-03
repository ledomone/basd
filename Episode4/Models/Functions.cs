using System;

namespace Episode4.Models
{
    public class Delegates
    {
        public delegate void Write(string message);

        public void Test()
        {
            Write writer = WriteMessage;
            writer("Dominik");
        }

        public static void WriteMessage(string msg)
        {
            Console.WriteLine($"Hello {msg}!");
        }
    }
}