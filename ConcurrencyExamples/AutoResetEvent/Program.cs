using System;
using System.Threading;

namespace ConcurrencyExamples
{
    public static class Program
    {
        private static AutoResetEvent _autoResetEvent = new(false);

        public static void Main(string[] args)
        {
            var thread = new Thread(WaitForSignal);
            thread.Start();

            Console.WriteLine("Main thread sleeping for 2 seconds");
            Thread.Sleep(2000);
            Console.WriteLine("Main thread signaling");

            // Signal the waiting thread
            _autoResetEvent.Set();
        }

        private static void WaitForSignal()
        {
            Console.WriteLine("Waiting for signal...");
            _autoResetEvent.WaitOne();
            Console.WriteLine("Received signal!");
        }
    }
}
