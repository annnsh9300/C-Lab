
/*
 * Annick Nshimirimana
 * Demonstrates abstraction + constructors for Salaried Employees
 */

namespace new_employee_app
{
    public class SalariedEmployee : Employee
    {
        public double AnnualSalary { get; private set; }

        public SalariedEmployee() { }

        public SalariedEmployee(string name, int id, Address address, double salary)
            : base(name, id, address)
        {
            AnnualSalary = salary;
        }

        public override void DisplayInfo()  // Required by abstract Employee
        {
            Console.WriteLine($"ID: {EmployeeID}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Address: {HomeAddress}");
            Console.WriteLine("Employee Type: Salaried");
            Console.WriteLine($"Annual Salary: {AnnualSalary:C}\n");
        }
    }
}
