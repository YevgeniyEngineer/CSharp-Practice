using System;
using System.Threading.Tasks;

namespace ConcurrencyExamples
{
    public class Program
    {
        private static int _counter = 0;

        public static void Main()
        {
            Parallel.For(0, 1000000, i =>
            {
                System.Threading.Interlocked.Increment(ref _counter);
            });

            Console.WriteLine($"Counter: {_counter}");
        }
    }
}
