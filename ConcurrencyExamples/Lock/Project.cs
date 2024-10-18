using System;
using System.Threading;

namespace ConcurrencyExamples
{
    /// <summary>
    /// The lock provides a way of ensuring that only one thread can access a particular block of code at a time.
    /// </summary>
    public static class Program
    {
        private static object _lock = new();
        private static int _counter = 0;

        static void Main()
        {
            var thread1 = new Thread(Increment);
            var thread2 = new Thread(Increment);

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();

            Console.WriteLine($"Final Counter Value: {_counter}");
        }

        private static void Increment()
        {
            for (var i = 0; i < 20; ++i)
            {
                lock (_lock)
                {
                    Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} modifying counter.");
                    _counter++;
                }

                Thread.Sleep(50);
            }
        }
    }
}
