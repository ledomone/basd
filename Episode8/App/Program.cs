using System;
using System.Threading.Tasks;
using Episode8.Models;

namespace Episode8
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
