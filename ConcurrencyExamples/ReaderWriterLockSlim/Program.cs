using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConcurrencyExamples
{
    /// <summary>
    /// ReaderWriterLockSlim allows multiple threads to be in read mode, and one thread to be in write mode,
    /// with exclusive ownership of the lock
    /// </summary>
    public class Program
    {
        private static ReaderWriterLockSlim _lock = new ReaderWriterLockSlim();
        private static int _resource = 0;

        public static void Main()
        {
            Task[] tasks = new Task[5];

            tasks[0] = Task.Run(() => WriteResource(10));

            for (var i = 1; i < 5; ++i)
            {
                tasks[i] = Task.Run(() => ReadResource());
            }

            Task.WaitAll(tasks);
        }

        private static void WriteResource(int value)
        {
            _lock.EnterWriteLock();
            try
            {
                Console.WriteLine("Writing resource...");
                _resource = value;
                Task.Delay(1000).Wait();
                Console.WriteLine("Write completed.");
            }
            finally
            {
                _lock.ExitWriteLock();
            }
        }

        private static void ReadResource()
        {
            _lock.EnterReadLock();
            try
            {
                Console.WriteLine($"Read resource value: {_resource}");
                Task.Delay(500).Wait();
            }
            finally
            {
                _lock.ExitReadLock();
            }
        }
    }
}
