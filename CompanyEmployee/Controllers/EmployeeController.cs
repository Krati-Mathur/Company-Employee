using CompanyEmployee.Repository;
using CompanyEmployee.Models;
using CompanyEmployee.Manager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Routing;

namespace CompanyEmployee.Controllers
{
    public class EmployeeController : ControllerBase
    {
		//private readonly IEmployeeRepository _employee;
		//private readonly IDepartmentRepository _department;
		private readonly IEmployeeManager _employeeManager;
        private readonly IDepartmentManager _departmentManager;
        
        public EmployeeController(IEmployeeManager employeeManager, IDepartmentManager departmentManager)
        {
			_employeeManager = employeeManager ??
                throw new ArgumentNullException(nameof(employeeManager));
			_departmentManager = departmentManager ??
                throw new ArgumentNullException(nameof(departmentManager));
        }

        [HttpGet]
        [Route("GetEmployees")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _employeeManager.GetEmployees());
        }

        [HttpGet]
        [Route("GetEmployeeByID/{ID}")]
        public async Task <IActionResult> GetEmpByID(int ID)
        {
            return Ok(await _employeeManager.GetEmployeeByID(ID));
        }

        [HttpPost]
        [Route("CreateEmployee")]
        public async Task <IActionResult> Post(Employee emp)
        {
            var result= await _employeeManager.CreateEmployee(emp);
            if (result.EmployeeId == 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong");
            }
            return Ok("Created Successfully");
        }

        [HttpPut]
        [Route("EditEmployee")]
        public async Task <IActionResult> Put(Employee emp)
        {
            await _employeeManager.EditEmployee(emp);
            return Ok("Updated Successfully");
        }

        [HttpDelete]
        [Route("DeleteEmployee")]
        public JsonResult Delete(int id) 
        {
            var result = _employeeManager.DeleteEmployee(id);
            return new JsonResult("Deleted Successfully");
        }

       	[HttpGet]
		[Route("GetDepartmentByID/{ID}")]
		public async Task<IActionResult> GetDeptById(int ID)
		{
			return Ok(await _departmentManager.GetDepartmentById(ID));
		}

	}
}
