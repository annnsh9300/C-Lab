

/*
 *  Annick Nshimi
 * 11/20/2025
 * Base Employee class demonstrating inheritance and composition.
 */

namespace new_employee_app
{
    // Composition class (Employee HAS an Address)
    public class Address
    {
        public string Street { get; set; }
        public string City { get; set; }

        public Address(string street, string city)
        {
            Street = street;
            City = city;
        }

        public override string ToString()
        {
            return $"{Street}, {City}";
        }
    }

    // Base Class
    public abstract class Employee
    {
        public string Name { get; set; }
        public int EmployeeID { get; set; }
        public Address HomeAddress { get; set; }

        public Employee(string name, int id, Address address)
        {
            Name = name;
            EmployeeID = id;
            HomeAddress = address;
        }

        // POLYMORPHISM: Virtual method
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"ID: {EmployeeID}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Address: {HomeAddress}");
        }
    }
}
