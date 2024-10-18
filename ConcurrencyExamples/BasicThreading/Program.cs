using System;
using System.Threading;

namespace ConcurrencyExamples
{
    public static class Program
    {
        static void Main()
        {
            var thread = new Thread(DoWork);

            // Start doing work
            thread.Start();

            // Wait for the thread to finish
            thread.Join();
        }

        static void DoWork()
        {
            Console.WriteLine("Hello from another thread!");
        }
    }
}
