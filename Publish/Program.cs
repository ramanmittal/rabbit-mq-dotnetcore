using System;
using System.Threading;

namespace Publish
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Publisher.Publish("task_queue2", "task_queue2");
                Thread.Sleep(1000);
            }
            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
    }
}
