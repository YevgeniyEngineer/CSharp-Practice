using System;
using System.Threading.Tasks;

namespace ConcurrencyExamples
{
    public class Program()
    {
        public static void Main()
        {
            Parallel.For(0, 100, i => Console.WriteLine($"Processing index {i} on thread {Task.CurrentId}"));
        }
    }
}
