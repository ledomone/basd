using System;
using System.Threading.Tasks;
using Episode7.Models;

namespace Episode7
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
