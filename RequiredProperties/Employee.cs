using System.Diagnostics.CodeAnalysis;

namespace RequiredProperties
{
    public class Employee
    {
        // this member can only be initialized, but not changed afterwards
        private readonly int _id;

        public Employee()
        {
        }

        [SetsRequiredMembers]
        public Employee(string firstName, string lastName, int id, string department)
        {
            FirstName = firstName;
            LastName = lastName;
            Id = id;
            Department = department;
        }

        public string? FirstName
        {
            get; set;
        }

        public required string LastName
        {
            get; set;
        }

        public required int Id
        {
            get => _id;
            init => _id = value;
        }

        public string? Department
        {
            get; set;
        }

        public override string ToString() => $"{FirstName} {LastName}, Id: {Id} in {Department}";
    }
}