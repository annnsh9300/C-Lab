/******************************************
*Name: Annick Nshimirimana
*Defines the IEmployeeActions interface
*******************************************/
using system;
namespace emp_app
{
public  class Employee 
{
    public int Id {get; set;}
    public string Name {get; set;}

    public Employee(int id, string name)
    {
        Id= id;
        Name= name;
    }

    //Abastrsct method = polymorphism(each employee type overrides it)
    public abstract double CalculatePay();
    //Interface implementation
    public virtual void DisplayInfo()
    {
        Console.WriteLine($"ID: {Id}, Name: {Name}");
    }
}
}
