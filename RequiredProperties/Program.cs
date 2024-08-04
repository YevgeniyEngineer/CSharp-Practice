using System;

namespace RequiredProperties
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Employee employee1 = new() { LastName = "Doe", Id = 1, Department = "Sales" };
            Employee employee2 = new() { FirstName = "Jane", LastName = "Deaux", Id = 2, Department = "R&D" };

            Console.WriteLine(employee1);
            Console.WriteLine(employee2);

            var employee3 = new Employee("Joe", "Doe", 4, "Marketing");
            Console.WriteLine(employee3);
        }
    }
}