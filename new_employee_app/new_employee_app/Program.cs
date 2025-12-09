class Program
{
    static void Main()
    {
        EmployeeRepository repo = new EmployeeRepository();
            Console.WriteLine("Annick Nshimirimana");
               Console.WriteLine("12-8-2025");
        while (true)
        {
            Console.WriteLine("\n EMPLOYEE CRUD MENU");
             Console.WriteLine("\n -------------------");
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. View All Employees");
            Console.WriteLine("3. Find Employee by ID");
            Console.WriteLine("4. Update Employee");
            Console.WriteLine("5. Delete Employee");
            Console.WriteLine("6. Exit");
            Console.Write("Enter choice: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddEmployee(repo);
                    break;

                case 2:
                  var list = repo.GetAllEmployees();
                  if (list.Count == 0)
                   Console.WriteLine("No employees found.");
                   else
                    PrintEmployeeTable(list);
                   break;


                case 3:
                    Console.Write("Enter ID: ");
                    int findId = int.Parse(Console.ReadLine());
                    var emp = repo.GetEmployeeById(findId);
                    Console.WriteLine(emp == null ? "Not found." : emp.Name);
                    break;

                case 4:
                    UpdateEmployee(repo);
                    break;

                case 5:
                    Console.Write("Enter ID to delete: ");
                    int delId = int.Parse(Console.ReadLine());
                    Console.WriteLine(repo.DeleteEmployee(delId)
                                      ? "Deleted."
                                      : "Not found.");
                    break;

                case 6:
                    return;
            }
        }
    }

    static void AddEmployee(EmployeeRepository repo)
    {
        Console.Write("Enter 1 for Hourly, 2 for Salaried: ");
        int type = int.Parse(Console.ReadLine());

        Console.Write("ID: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Street: ");
        string street = Console.ReadLine();

        Console.Write("City: ");
        string city = Console.ReadLine();

        Console.Write("State: ");
        string state = Console.ReadLine();

        Console.Write("Zip: ");
        string zip = Console.ReadLine();

        Employee emp;

        if (type == 1)
        {
            Console.Write("Hourly rate: ");
            decimal rate = decimal.Parse(Console.ReadLine());

            Console.Write("Hours worked: ");
            int hours = int.Parse(Console.ReadLine());

            emp = new HourlyEmployee
            {
                EmployeeID = id,
                Name = name,
                Address = new Address { Street = street, City = city, State = state, Zip = zip },
                HourlyRate = rate,
                HoursWorked = hours
            };
        }
        else
        {
            Console.Write("Salary: ");
            decimal salary = decimal.Parse(Console.ReadLine());

            emp = new SalariedEmployee
            {
                EmployeeID = id,
                Name = name,
                Address = new Address { Street = street, City = city, State = state, Zip = zip },
                Salary = salary
            };
        }

        repo.AddEmployee(emp);
        Console.WriteLine("Employee added!");
    }

    static void UpdateEmployee(EmployeeRepository repo)
    {
        Console.Write("Enter ID to update: ");
        int id = int.Parse(Console.ReadLine());

        var existing = repo.GetEmployeeById(id);
        if (existing == null)
        {
            Console.WriteLine("Employee not found.");
            return;
        }

        Console.Write("New Name: ");
        existing.Name = Console.ReadLine();

        repo.UpdateEmployee(existing);
        Console.WriteLine("Updated!");
    }
    static void PrintEmployeeTable(List<Employee> employees)
{
    Console.WriteLine("\n---------------------------------------------------------------------------------------------------------------");
    Console.WriteLine("| ID  | Name   | Type   | Pay Info | Street| City | State | Zip|");
    Console.WriteLine("---------------------------------------------------------------------------------------------------------------");

    foreach (var e in employees)
    {
        string type = e is HourlyEmployee ? "Hourly" : "Salaried";

        string pay = e is HourlyEmployee h
            ? $"{h.HourlyRate} x {h.HoursWorked}"
            : e is SalariedEmployee s
                ? $"{s.Salary}/yr"
                : "";

        Console.WriteLine(
            $"| {e.EmployeeID,-3} | {e.Name,-16} | {type,-8} | {pay,-16} | " +
            $"{e.Address.Street,-16} | {e.Address.City,-11} | {e.Address.State,-5} | {e.Address.Zip,-4} |"
        );
    }

    Console.WriteLine("---------------------------------------------------------------------------------------------------------------");
}


}
