using System;
using System.Threading.Tasks;
using Episode6.Models;

namespace Episode6
{
    class Program
    {
        static void Main(string[] args)
        {
            var parallelism = new Parallelism();
            parallelism.Test();
        }
    }
}
