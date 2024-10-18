using System;
using System.Threading.Tasks;

namespace ConcurrencyExamples
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var task = Task.Run(() => DoWork());

            // Wait for the task to complete
            task.Wait();
        }

        private static void DoWork()
        {
            Console.WriteLine("Work done in task.");
        }
    }
}
