
/*Author: Annick Nshimi
 *Date: 12/07/2025
 *Defines the abstract Employee base class shared by all employee types.*/

public abstract class Employee
{
    public int EmployeeID { get; set; }
    public string Name { get; set; } = "";
    public Address Address { get; set; } = new Address();

    public abstract void DisplayInfo();
}
