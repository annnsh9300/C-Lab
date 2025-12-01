
/*
 * Annick Nshimirimana
 * 12/01/2025
 * This file defines the abstract Employee base class.
 * It demonstrates abstraction, constructors, and proper access specifiers.
 */

namespace new_employee_app
{
    public abstract class Employee   // ABSTRACT CLASS (Week 3)
    {
        public string Name { get; set; }  // Protected setters
        public int EmployeeID { get; private set; } // Only set in constructor
        public Address HomeAddress { get; protected set; }

        // DEFAULT CONSTRUCTOR (Week 3)
        protected Employee() { }

        // MAIN CONSTRUCTOR
        protected Employee(string name, int id, Address address)
        {
            Name = name;
            EmployeeID = id;
            HomeAddress = address;
        }

        // ABSTRACT METHOD → must be implemented by derived classes
        public abstract void DisplayInfo();  // Week 3 ABSTRACTION
    }


    // Composition Object
    public class Address
    {
        public string Street { get; private set; }
        public string City { get; private set; }

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
}
