using System;
using Episode1.Models;

namespace Episode1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            User user = new User("Heniu", "em@i.l");
            user.SetEmail("ala@ma.kota");
        }
    }
}
