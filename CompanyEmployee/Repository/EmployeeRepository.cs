using CompanyEmployee.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyEmployee.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly CompanyContext _companyContext;
        public EmployeeRepository(CompanyContext context)
        {
            _companyContext = context ??
                throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _companyContext.Employees.ToListAsync();
        }
        public async Task<Employee> GetEmployeeByID(int ID)
        {
            return await _companyContext.Employees.FindAsync(ID);
        }
        public async Task<Employee> CreateEmployee(Employee objEmployee)
        {
            _companyContext.Employees.Add(objEmployee);
            await _companyContext.SaveChangesAsync();
            return objEmployee;
        }
        public async Task<Employee> EditEmployee(Employee objEmployee)
        {
            _companyContext.Entry(objEmployee).State = EntityState.Modified;
            await _companyContext.SaveChangesAsync();
            return objEmployee;
        }
        public bool DeleteEmployee(int ID)
        {
            bool result = false;
            var employee = _companyContext.Employees.Find(ID);
            if (employee != null)
            {
                _companyContext.Entry(employee).State = EntityState.Deleted;
                _companyContext.SaveChanges();
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }              
    }
}
