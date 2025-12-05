
/*
 * Annick Nshimirimana
 * 11/27/2025
 *Week 3 
 * Demonstrates Abstraction, constructors, and access specifiers */

namespace new_employee_app
{
    public class EmployeeManager : IEmployeeActions
    {
        // Private list - access specifier ensures encapsulation
        private List<Employee> Employees;

        // Week 3: Default constructor
        public EmployeeManager()
        {
            Employees = new List<Employee>();
        }

        // Week 3: Overloaded constructor
        public EmployeeManager(List<Employee> initialEmployees)
        {
            Employees = initialEmployees;
        }
        
       public int GetTotalEmployees()
    {
        return Employees.Count;
    }

    public Employee GetEmployeeById(int id)
    {
        return Employees.FirstOrDefault(e => e.EmployeeID == id);
    }


        public void AddEmployee(Employee emp)
        {
            Employees.Add(emp);
            Console.WriteLine($"Employee {emp.Name} added.\n");
        }

        public void RemoveEmployee(int id)
        {
            var emp = Employees.FirstOrDefault(e => e.EmployeeID == id);
            if (emp != null)
            {
                Employees.Remove(emp);
                Console.WriteLine($"Employee {id} removed.\n");
            }
            else Console.WriteLine("Employee not found.\n");
        }

        public void UpdateEmployee(int id, string newName)
        {
            var emp = Employees.FirstOrDefault(e => e.EmployeeID == id);
            if (emp != null)
            {
                emp.Name = newName;
                Console.WriteLine("Employee updated.\n");
            }
        }

        public void DisplayAllEmployees()
        {
            Console.WriteLine("\n All Employees ");
            Console.WriteLine("\n ----------------");
            foreach (var emp in Employees)
                emp.DisplayInfo(); // POLYMORPHISM
        }

        public void DisplayEmployeesByType(string type)
        {
            Console.WriteLine($"\n Employees of Type: {type} ");
            Console.WriteLine("\n ------------------- ");
            foreach (var emp in Employees)
            {
                if (emp.GetType().Name.ToLower() == type.ToLower())
                    emp.DisplayInfo(); // POLYMORPHISM
            }
        }
    }
}
