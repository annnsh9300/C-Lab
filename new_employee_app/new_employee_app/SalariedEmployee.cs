/*
 * Annick Nshimi
 * 11/20/2025
 *  Derived class demonstrating inheritance.
 */

namespace new_employee_app
{
    public class SalariedEmployee : Employee
    {
        public double AnnualSalary { get; set; }

        public SalariedEmployee(string name, int id, Address address, double salary)
            : base(name, id, address)
        {
            AnnualSalary = salary;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine("Employee Type: Salaried");
            Console.WriteLine($"Annual Salary: {AnnualSalary:C}");
            Console.WriteLine();
        }
    }
}
