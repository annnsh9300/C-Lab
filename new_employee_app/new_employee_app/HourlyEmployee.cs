
/* Author: Annick Nshimi
* Date: 2025-02-07
* Purpose: Defines the HourlyEmployee class, representing employees paid by hourly rate.*/


public class HourlyEmployee : Employee
{
    public decimal HourlyRate { get; set; }
    public int HoursWorked { get; set; }

    public override void DisplayInfo()
    {
        Console.WriteLine($"[Hourly] {EmployeeID} - {Name}");
    }
}
