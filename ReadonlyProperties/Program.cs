using System;

namespace ReadonlyProperties
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Book myBook = new Book("9780241265543", "War and Peace", "Leo Tolstoy");

            Console.WriteLine($"{myBook.GetBookDetails()}");

            Employee employee = new Employee("John", "Smith", 25, "Accounting");
            Console.WriteLine(employee);
        }
    }
}