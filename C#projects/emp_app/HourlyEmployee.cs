/******************************************
*Name: Annick Nshimirimana
*Defines the IEmployeeActions interface
*******************************************/
using system;
namespace emp_app
{
public class HourlyEmployee : Employee
{
    public double HourlyRate {get; set;}
    public double HoursWorked {get; set;}

    public HourlyEmployee(int id, string name, double rate, double hours)
         : base(id, name)
    {
        HourlyRate = rate;
        HoursWorked = hours;
    }

    //polymorphism: overrides CalculatePay
    public override double CalculatePay()
    {
        return HourlyRate * HoursWorked;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Type: Hourly | pay: ${CalculatePay()}");
    }
}
}
