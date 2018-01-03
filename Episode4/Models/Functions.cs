using System;

namespace Episode4.Models
{
    public class Delegates
    {
        public delegate void Write();

        public void Test()
        {
            Write writer = WriteMessage;
            writer();
        }

        public static void WriteMessage()
        {
            Console.WriteLine($"Hello!");
        }
    }
}