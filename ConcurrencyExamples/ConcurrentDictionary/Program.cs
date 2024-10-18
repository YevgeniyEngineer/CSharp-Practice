using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace ConcurrencyExamples
{
    public class Program
    {
        private static ConcurrentDictionary<int, int> _dictionary = new();

        public static void Main()
        {
            Parallel.For(0, 100, i =>
            {
                var item = i * i;
                _dictionary.TryAdd(i, item);
                Console.WriteLine($"Added item {item} to a dictionary with key {i}");
            });

            Console.WriteLine($"Dictionary contains {_dictionary.Count} items.");
        }
    }
}
