using CompanyEmployee.Models;
using CompanyEmployee.Repository;

namespace CompanyEmployee.Manager
{
	public class EmployeeManager : IEmployeeManager
	{

		private readonly IEmployeeRepository _employeeRepository;
		public EmployeeManager(IEmployeeRepository employeeRepository) 
		{ 
			_employeeRepository = employeeRepository;
		}

		public async Task<IEnumerable<Employee>> GetEmployees()
		{
			return await _employeeRepository.GetEmployees();
		}
		public async Task<Employee> CreateEmployee(Employee objEmployee)
		{
			return await _employeeRepository.CreateEmployee(objEmployee);
		}

		public async Task<Employee> GetEmployeeByID(int ID)
		{
			return await _employeeRepository.GetEmployeeByID(ID);
		}

		public async Task<Employee> EditEmployee(Employee objEmployee)
		{
			return await _employeeRepository.EditEmployee(objEmployee);
		}

		public bool DeleteEmployee(int ID)
		{
			return _employeeRepository.DeleteEmployee(ID);
		}
	}
}
