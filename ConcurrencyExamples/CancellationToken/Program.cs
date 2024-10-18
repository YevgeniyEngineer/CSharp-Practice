using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConcurrencyExamples
{
    public class Program
    {
        public static async Task Main()
        {
            CancellationTokenSource cancellationTokenSource = new();

            var task = Task.Run(() => DoWork(cancellationTokenSource.Token), cancellationTokenSource.Token);

            Console.WriteLine("Press any key to cancel...");
            Console.ReadKey();
            cancellationTokenSource.Cancel();

            try
            {
                await task;
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Task was cancelled.");
            }
        }

        static void DoWork(CancellationToken token)
        {
            var i = 0;

            while (true)
            {
                token.ThrowIfCancellationRequested();
                Console.WriteLine($"Working... {i++}");
                Thread.Sleep(500);
            }
        }
    }
}
