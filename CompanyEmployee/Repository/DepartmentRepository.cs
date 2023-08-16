using CompanyEmployee.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyEmployee.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly CompanyContext _companyContext;
        public DepartmentRepository(CompanyContext context)
        {
            _companyContext = context ??
                throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<Department>> GetDepartment()
        {
            return await _companyContext.Departments.ToListAsync();
        }
        public async Task<Department> GetDepartmentById(int ID)
        {
            return await _companyContext.Departments.FindAsync(ID);
        }
        public async Task<Department> CreateDepartment(Department objDepartment)
        {
            _companyContext.Departments.Add(objDepartment);
            await _companyContext.SaveChangesAsync();
            return objDepartment;
        }
        public async Task<Department> EditDepartment(Department objDepartment)
        {
            _companyContext.Entry(objDepartment).State = EntityState.Modified;
            await _companyContext.SaveChangesAsync();
            return objDepartment;
        }
        public bool DeleteDepartment(int ID)
        {
            bool result = false;
            var department = _companyContext.Departments.Find(ID);
            if (department != null)
            {
                _companyContext.Entry(department).State = EntityState.Deleted;
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
