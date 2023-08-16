using CompanyEmployee.Models;
using CompanyEmployee.Repository;

namespace CompanyEmployee.Manager
{
	public class DepartmentManager : IDepartmentManager
	{
		private readonly IDepartmentRepository _departmentRepository;
		public DepartmentManager(IDepartmentRepository departmentRepository) 
		{ 
			_departmentRepository = departmentRepository;
		}
		public async Task<IEnumerable<Department>> GetDepartment()
		{
			return await _departmentRepository.GetDepartment();
		}

		public async Task<Department> GetDepartmentById(int ID)
		{
			return await _departmentRepository.GetDepartmentById(ID);
		}
		public async Task<Department> CreateDepartment(Department objDepartment)
		{
			return await _departmentRepository.CreateDepartment(objDepartment);
		}

		public async Task<Department> EditDepartment(Department objDepartment)
		{
			return await _departmentRepository.EditDepartment(objDepartment);
		}

		public bool DeleteDepartment(int ID)
		{
			return _departmentRepository.DeleteDepartment(ID);
		}
	}
}
