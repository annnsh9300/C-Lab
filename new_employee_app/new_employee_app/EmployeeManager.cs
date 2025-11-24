/*
 *  Annick Nshimi
 * 11/20/2025
 * Demonstrates interface implementation + composition.
 */

namespace new_employee_app
{
    public class EmployeeManager : IEmployeeActions
    {
        private List<Employee> Employees = new List<Employee>(); // COMPOSITION

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
                    emp.DisplayInfo();
            }
        }
    }
}
