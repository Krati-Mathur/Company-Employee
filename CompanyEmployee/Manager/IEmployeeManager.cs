using CompanyEmployee.Models;
namespace CompanyEmployee.Repository
{
    public interface IEmployeeManager
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployeeByID(int ID);
        Task<Employee> CreateEmployee(Employee objEmployee);
        Task<Employee> EditEmployee(Employee objEmployee);
        bool DeleteEmployee(int ID);
    }
}
