/*
 *  Annick Nshimi
 *  11/20/2025
 * Derived class demonstrating inheritance.
 */

namespace new_employee_app
{
    public class HourlyEmployee : Employee
    {
        public double HourlyRate { get; set; }
        public double HoursWorked { get; set; }

        public HourlyEmployee(string name, int id, Address address, double rate, double hours)
            : base(name, id, address)
        {
            HourlyRate = rate;
            HoursWorked = hours;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine("Employee Type: Hourly");
            Console.WriteLine($"Hourly Rate: {HourlyRate:C}");
            Console.WriteLine($"Hours Worked: {HoursWorked}");
            Console.WriteLine();
        }
    }
}
