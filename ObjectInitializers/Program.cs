using System;

namespace ObjectInitializers
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Dog dog = new()
            {
                Name = "Fido",
                Age = 4,
                IsTrained = true
            };

            Cat cat = new()
            {
                Name = "Mr. Meowington",
                Age = 7,
                IsDeclawed = false
            };

            Console.WriteLine($"Dog: {dog.Name}, {dog.Age}");

            Console.WriteLine($"Cat: {cat.Name}, {cat.Age}");

            // Initialization of the anonymous type, 
            // where Name and Age types are deduced by the compiler
            var pet = new { Name = "Charlie", Age = 5 };
            Console.WriteLine($"Pet: {pet.Name}, {pet.Age}");

            // Collection initialization
            var numbers = new int[] { 1, 2, 3, 4, 5, 6 };
            Console.WriteLine($"Number of items in numbers array: {numbers.Length}");

            foreach (int number in numbers)
            {
                Console.Write($"{number} ");
            }
            Console.WriteLine();

            PetOwner owner = new()
            {
                Name = "Joe Marini",
                Pets = new List<Pet>{
                    new Dog{Name="Junebug", Age=5},
                    new Cat{Name="Whiskers",Age=3},
                    new Dog{Name="Max", Age=10}
                }
            };

            Console.WriteLine($"{owner.Name}'s Pets:");

            foreach (Pet p in owner.Pets)
            {
                Console.WriteLine($"Pet's name: {p.Name}");
            }

        }
    }
}