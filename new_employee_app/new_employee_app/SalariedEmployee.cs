/*Author: Annick Nshimi
* 2025-02-07
*Defines the SalariedEmployee class, representing employees paid an annual salary.*/


public class SalariedEmployee : Employee
{
    public decimal Salary { get; set; }

    public override void DisplayInfo()
    {
        Console.WriteLine($"[Salaried] {EmployeeID} - {Name}");
    }
}
