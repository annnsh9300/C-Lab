
/*
 * Annick Nshimirimana
 * Demonstrates inheritance + abstraction + constructors for Hourly Employee.
 */

namespace new_employee_app
{
    public class HourlyEmployee : Employee
    {
        public double HourlyRate { get; private set; }
        public double HoursWorked { get; private set; }

        // DEFAULT CONSTRUCTOR
        public HourlyEmployee() { }

        // MAIN CONSTRUCTOR
        public HourlyEmployee(string name, int id, Address address, double rate, double hours)
            : base(name, id, address)
        {
            HourlyRate = rate;
            HoursWorked = hours;
        }

        // ABSTRACTION IMPLEMENTATION (Week 3)
        public override void DisplayInfo()
        {
            Console.WriteLine($"ID: {EmployeeID}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Address: {HomeAddress}");
            Console.WriteLine("Employee Type: Hourly");
            Console.WriteLine($"Hourly Rate: {HourlyRate:C}");
            Console.WriteLine($"Hours Worked: {HoursWorked}\n");
        }
    }
}
