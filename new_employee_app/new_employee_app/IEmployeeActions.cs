/******
* Annick Nshimimirimana
* Week 3 Interface Update
* Added new abstract methods as required
*/

namespace new_employee_app
{
    public interface IEmployeeActions
    {
        // Week 2 methods
        void AddEmployee(Employee emp);
        void RemoveEmployee(int id);
        void UpdateEmployee(int id, string newName);
        void DisplayAllEmployees();
        void DisplayEmployeesByType(string type);

        // WEEK 3: NEW METHODS
        int GetTotalEmployees();               // returns number of employees
        Employee GetEmployeeById(int id);      // retrieves employee object by ID
    }
}
