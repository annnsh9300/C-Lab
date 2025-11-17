/*
*Annick Nshimirimana
*11/13/2025
*This file contains the main program and the  class definitions for the employee management app.It demonstrates inheritance using the employee(base class), HourlyEmployee and SalariedEmployee(derived classes).

*It also demonstrates composition, where an employee "has an "Address object*
*
*
*/
namespace EmployeeManagementApp
{
    class Address
    {
        public string Street{get;set;}
        public string City{get; set;}
        public Address(string street, string city)
    {
        Street=street;
        City= city;
    }
        public override string ToString()
    {
        return $"{Street},{City}";
    }
    
    }

    //Base class (Inheritance)
    class Employee
    {
        public string Name{get; set;}
        public int EmployeeID{get; set;}

        //Composition : Employee has an address
        public Address HomeAddress{get; set;}

        public Employee(string name, int id,  Address address)
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

        
    }

//Derived class 1 (Inheritance Demo)
        class HourlyEmployee : Employee
    {
        public double HourlyRate{get; set;}
        public double HoursWorked {get; set;}
        public HourlyEmployee(string name, int id, Address address, double rate, double hours): base(name,id, address)//inheritance call
        {
            HourlyRate = rate;
            HoursWorked= hours;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            {
                base.DisplayInfo();
                Console.WriteLine($"Role: Hourly Employee");
                Console.WriteLine($"Hourly Rate: {HourlyRate:C}");
                Console.WriteLine($"Hours Worked: {HoursWorked}");;
                Console.WriteLine();
            }
        }

        //Derived Class 2 (Inheritance Demo)
        class SalariedEmployee : Employee
        {
            public double AnnualSalary {get; set;}
            public SalariedEmployee(string name, int id, Address address, double salary): base(name,id,address)
            {
                AnnualSalary = salary;
            }
            public override void DisplayInfo()
            {
                base.DisplayInfo();
                Console.WriteLine("Role: Salaried Employee");
                Console.WriteLine($"Annual Salary: {AnnualSalary:C}");
                Console.WriteLine();
            }
        }

        //Main Program
        class program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("==============");
                Console.WriteLine("Project Week 1 - Employee Management System");
                Console.WriteLine();
                Console.WriteLine("==============");
                Console.WriteLine();
                Console.WriteLine("Welcome, this is the first step of employee Management project.");
                Console.WriteLine("Below, we will demonstrate inheritance, composition, and class output");
                Console.WriteLine();
                

                //Create Address Objects(composition)
                Address addr1 = new Address("123 Main St", "Richmond");
                Address addr2 = new Address("49 pine Lane", "Arlington");


                //create Employees inheritance demo
                HourlyEmployee emp1 = new HourlyEmployee("Alex Carter",101, addr1, 20.50, 40);
                SalariedEmployee emp2 = new SalariedEmployee("Maria Lopez", 202, addr2, 60000);


                Console.WriteLine("Displaying Employee Informantion:\n");



                //Display Info
                emp1.DisplayInfo();
                emp2.DisplayInfo();


                Console.WriteLine("End of project week 1 demonstartion.");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
            
        
    }








}