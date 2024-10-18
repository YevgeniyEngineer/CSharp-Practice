using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConcurrencyExamples
{
    public class Program
    {
        public static async Task Main()
        {
            await foreach (var number in GenerateNumbersAsync())
            {
                Console.WriteLine(number);
            }
        }

        private static async IAsyncEnumerable<int> GenerateNumbersAsync()
        {
            for (var i = 0; i < 5; i++)
            {
                // Simulate asynchronous work
                await Task.Delay(500);

                yield return i;
            }
        }
    }
}
