using System;

namespace ObjectInitializers
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Dog dog = new Dog()
            {
                Name = "Fido",
                Age = 4,
                IsTrained = true
            };


            Cat cat = new Cat
            {
                Name = "Mr. Meowington",
                Age = 7,
                IsDeclawed = false
            };

            Console.WriteLine($"Dog: {dog.Name}, {dog.Age}");

            Console.WriteLine($"Cat: {cat.Name}, {cat.Age}");
        }
    }
}