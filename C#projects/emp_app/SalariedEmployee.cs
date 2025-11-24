/******************************************
*Name: Annick Nshimirimana
*Defines the IEmployeeActions interface
*******************************************/

public class SalariedEmployee : Employee
{
    public double AnnualSalary {get; set;}
    public SalariedEmployee(int id, string name, double salary)
          : base(id, name)
    {
        AnnualSalary = salary;
    }
    //polymorphism
    public override double CalculatePay()
    {
        return AnnualSalary / 52; //weekly pay
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Type: salaried | weekly pay: ${CalculatePay()}");
    }
}