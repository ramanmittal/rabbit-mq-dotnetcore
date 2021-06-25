using System;
using System.Threading;

namespace Subscribe
{
    class Program
    {
        static void Main(string[] args)
        {

            new Worker2().Subcribe();
            new Worker1().Subcribe();
            Thread.Sleep(int.MaxValue);
        }
    }
}
