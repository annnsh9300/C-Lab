
/*
 *  Annick Nshimirimana
 *  11/30/2025
 *  Week 3 Main Program demonstrating interface + polymorphism.
 */

using new_employee_app;
class Program
{
    static void Main()
    {
        
        Console.WriteLine(" Project Week 3");
        Console.WriteLine(" Employee Management System");
        Console.WriteLine("  Annick Nshimimirimana");
        Console.WriteLine("======================\n");

        Console.WriteLine("This demo shows Abstraction, Constructors, and Access Specifiers.\n");

        // Create EmployeeManager (INTERFACE IMPLEMENTATION)
        IEmployeeActions manager = new EmployeeManager();

        // Create Employees
        var addr1 = new Address("123 Maple St", "Richmond");
        var addr2 = new Address("55 Cedar Rd", "Fairfax");

        Employee emp1 = new HourlyEmployee("Alex Carter", 101, addr1, 20.50, 40);
        Employee emp2 = new SalariedEmployee("Maria Lopez", 202, addr2, 60000);

        // Add Employees
        manager.AddEmployee(emp1);
        manager.AddEmployee(emp2);

        // Display All
        manager.DisplayAllEmployees();

        // Display by Type
        manager.DisplayEmployeesByType("HourlyEmployee");

        Console.WriteLine("Project Week 3 - Employee Management System\n");
        Console.WriteLine("This demo shows abstraction, constructors, and proper access specifiers.\n");

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}
