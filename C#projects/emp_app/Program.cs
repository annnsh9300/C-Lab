/*
 * Annick Nshimimirimana
 * 11/20/2025
 * Week 2 - Employee Management Application
 * This file contains:
 * - An interface (IWorkInfo)
 * - Inheritance (Employee base class, HourlyEmployee & SalariedEmployee derived classes)
 * - Composition (Employee HAS an Address)
 * - Polymorphism using a list of IWorkInfo
 */

using System;
using System.Collections.Generic;

namespace emp_app
{
    // Composition class: Employee HAS an Address
    class Address
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

    // Interface (Week 2 requirement)
    interface IWorkInfo
    {
        double CalculatePay();              // Polymorphic behavior
        void DisplayWorkDetails();          // Polymorphic behavior
    }

    // Base class (Inheritance)
    abstract class Employee : IWorkInfo
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

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Employee ID: {EmployeeID}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Address: {HomeAddress}");
        }

        // Interface requirements
        public abstract double CalculatePay();
        public abstract void DisplayWorkDetails();
    }

    // Derived Class 1
    class HourlyEmployee : Employee
    {
        public double HourlyRate { get; set; }
        public double HoursWorked { get; set; }

        public HourlyEmployee(string name, int id, Address address, double rate, double hours)
            : base(name, id, address)
        {
            HourlyRate = rate;
            HoursWorked = hours;
        }

        public override double CalculatePay()
        {
            return HourlyRate * HoursWorked;
        }

        public override void DisplayWorkDetails()
        {
            Console.WriteLine($"[Hourly Employee] {Name} | Pay: {CalculatePay():C}");
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine("Role: Hourly Employee");
            Console.WriteLine($"Hourly Rate: {HourlyRate:C}");
            Console.WriteLine($"Hours Worked: {HoursWorked}");
            Console.WriteLine();
        }
    }

    // Derived Class 2
    class SalariedEmployee : Employee
    {
        public double AnnualSalary { get; set; }

        public SalariedEmployee(string name, int id, Address address, double salary)
            : base(name, id, address)
        {
            AnnualSalary = salary;
        }

        public override double CalculatePay()
        {
            return AnnualSalary / 52; // weekly pay example
        }

        public override void DisplayWorkDetails()
        {
            Console.WriteLine($"[Salaried Employee] {Name} | Weekly Pay: {CalculatePay():C}");
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine("Role: Salaried Employee");
            Console.WriteLine($"Annual Salary: {AnnualSalary:C}");
            Console.WriteLine();
        }
    }

    // Main Program
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==============================");
            Console.WriteLine("Project Week 2 - Employee Management System");
            Console.WriteLine("Created by: Annick Nshimi");
            Console.WriteLine("==============================");
            Console.WriteLine("Welcome! This program will demonstrate interfaces and polymorphism.");
            Console.WriteLine();

            // Composition objects
            Address addr1 = new Address("123 Main St", "Richmond");
            Address addr2 = new Address("49 Pine Lane", "Arlington");

            // Inheritance + Interface + Polymorphism
            HourlyEmployee emp1 = new HourlyEmployee("Alex Carter", 101, addr1, 20.50, 40);
            SalariedEmployee emp2 = new SalariedEmployee("Maria Lopez", 202, addr2, 60000);

            Console.WriteLine("Displaying Full Employee Information:\n");
            emp1.DisplayInfo();
            emp2.DisplayInfo();

            // POLYMORPHISM DEMO
            Console.WriteLine("Polymorphism Demonstration (Interface-based List):\n");
            List<IWorkInfo> workers = new List<IWorkInfo>();
            workers.Add(emp1);
            workers.Add(emp2);

            foreach (var worker in workers)
            {
                worker.DisplayWorkDetails(); // <-- Polymorphism HAPPENS HERE
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}