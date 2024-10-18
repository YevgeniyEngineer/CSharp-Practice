using System;
using System.Threading;

namespace ConcurrencyExamples
{
    /// <summary>
    /// Semaphores are used to control access to a resource pool by multiple threads.
    /// It allows a specified number of threads to access a resource simultaneously.
    /// </summary>
    public static class Program
    {
        // Allow up to 2 threads
        private static SemaphoreSlim _semaphore = new SemaphoreSlim(2);

        public static void Main(string[] args)
        {
            for (var i = 0; i < 5; ++i)
            {
                var thread = new Thread(Work);
                thread.Start(i);
            }
        }

        private static void Work(object id)
        {
            Console.WriteLine($"Thread {id} is waiting to enter the semaphore");

            _semaphore.Wait();
            Console.WriteLine($"Thread {id} has entered the semaphore");

            // Simulate work
            Thread.Sleep(1000);

            Console.WriteLine($"Thread {id} is releasing the semaphore");
            _semaphore.Release();
        }
    }
}
