using EmployeeManagementSystem.Model;

namespace EmployeeManagementSystem.Sevices
{
    public interface IEmployee
    {
        IEnumerable<Employee> GetAllEmployees { get; }
        Task<Employee> GetEmployeeById(int id);
        Task AddEmployee(Employee employee);
        Task UpdateEmployee(Employee employee);
        Task DeleteEmployee(Employee employee);
        Task<Employee> GetEmployeeByName(string name);
        IEnumerable<Employee> SearchEmployee(string name);

    }
}
