using System;
using System.Threading.Tasks;

namespace ConcurrencyExamples
{
    /// <summary>
    /// Barrier is a synchronization primitive that enables multiple threads (or tasks)
    /// to work concurrently in phases. It ensures that all participating threads reach
    /// a certain point in the code (a "barrier") before any of them proceed to the next phase.
    /// This is useful when you have threads that need to perform operations in lockstep, ensuring that each phase
    /// is completed by all threads before moving on.
    /// </summary> 
    public class Program
    {
        /// The barrier will wait until three threads have signaled that they 
        /// have reached the barrier point.
        private static System.Threading.Barrier _barrier = new(3, (b) =>
        {
            Console.WriteLine($"Phase {b.CurrentPhaseNumber} completed.");
        });

        public static void Main()
        {
            Task[] tasks = new Task[3]
            {
                Task.Run(() => Work(1)),
                Task.Run(() => Work(2)),
                Task.Run(() => Work(3))
            };

            Task.WaitAll(tasks);
        }

        private static void Work(int id)
        {
            Console.WriteLine($"Task {id} working in phase 0");
            Task.Delay(1000 * id).Wait();
            _barrier.SignalAndWait();

            Console.WriteLine($"Task {id} working in phase 1");
            Task.Delay(1000 * id).Wait();
            _barrier.SignalAndWait();
        }
    }
}
