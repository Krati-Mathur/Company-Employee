using CompanyEmployee.Models;
namespace CompanyEmployee.Repository
{
    public interface IDepartmentManager
    {
        Task<IEnumerable<Department>> GetDepartment();
        Task<Department> GetDepartmentById(int ID);
        Task<Department> CreateDepartment (Department objDepartment);
        Task<Department> EditDepartment (Department objDepartment);
        bool DeleteDepartment (int ID);
    }
}

