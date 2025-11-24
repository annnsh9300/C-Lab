/******************************************
*Name: Annick Nshimirimana
*Defines the IEmployeeActions interface
*******************************************/
namespace emp_app
{


      public interface IEmployeeActions
      {
    void AddEmployee(Employee emp);//All employee types must display info
    void RemoveEmployee(int id);
    void UpdateEmployee(int id, string newName);
    void DisplayAllEmployees();
       }
 
}