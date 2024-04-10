using EmployeeManagementSystem.Models;

namespace OperationsInterface
{
    public interface IOperations
    {
        List<Employee> GetEmployeeList();
        void AddEmployee(EmployeeDto emp);
        void UpdateEmployee(string employeeId, EmployeeDto updatedemp);
        void DeleteEmployee(string id);

        Employee RetrieveEmployeeByID(string id);
        List<Employee> GetEmployeesByDepartment(int id);
        int GetCountOfEmployeesByDepartment(int id);
        List<Employee> LastUpdatedEmployee();
        void SoftDeleteEmployee(string id);
        List<Employee> GetTopSalariesEmployeesDepartmentWise(int count);

    }
}
