using System;
using System.Threading;

namespace ConcurrencyExamples
{
    /// <summary>
    /// A Mutex (Mutual Exclusion) is similar to a lock but it can be used across different processes.
    /// </summary>
    public static class Program
    {
        private static Mutex _mutex = new();

        static void Main()
        {
            var thread1 = new Thread(Work);
            var thread2 = new Thread(Work);

            thread1.Start();
            thread2.Start();
        }

        static void Work()
        {
            _mutex.WaitOne();
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} has entered the mutex");

            // Simulate the work
            Thread.Sleep(1000);

            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} is releasing the mutex");
            _mutex.ReleaseMutex();
        }
    }
}
