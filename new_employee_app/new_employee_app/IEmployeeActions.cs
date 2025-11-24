/******
*Annick Nshimirimana
*Date: 11/20/2025
*Defines employee management behaviors through an interface

*/
namespace new_employee_app
{
    public interface IEmployeeActions
    {
        void AddEmployee(Employee emp);
        void RemoveEmployee(int id);
        void UpdateEmployee(int id, string newName);
        void DisplayAllEmployees();
        void DisplayEmployeesByType(string type);
    }
}
