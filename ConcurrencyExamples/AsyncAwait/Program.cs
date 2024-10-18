using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConcurrencyExamples
{
    public static class Program
    {
        public static async Task Main()
        {
            string content = await DownloadContentAsync("https://file-examples.com/wp-content/storage/2018/04/file_example_AVI_480_750kB.avi");
            Console.WriteLine(content);
        }

        private static async Task<string> DownloadContentAsync(string url)
        {
            using HttpClient client = new HttpClient();
            return await client.GetStringAsync(url);
        }
    }
}
