using CompanyEmployee.Models;
using CompanyEmployee.Repository;
using CompanyEmployee.Manager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CompanyEmployee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
		//private readonly IDepartmentRepository _department;
		private readonly IDepartmentManager _departmentManager;
		public DepartmentController(IDepartmentManager departmentManager)
        {
			_departmentManager = departmentManager ??
                throw new ArgumentNullException(nameof(departmentManager));
        }

        [HttpGet]
        [Route("GetDepartment")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _departmentManager.GetDepartment());
        }

		[HttpGet]
		[Route("GetDepartmentByID/{ID}")]
		public async Task<IActionResult> GetDeptById(int ID)
		{
			return Ok(await _departmentManager.GetDepartmentById(ID));
		}

		[HttpPost]
        [Route("CreateDepartment")]
        public async Task<IActionResult> POST(Department dep)
        {
            var result = await _departmentManager.CreateDepartment(dep);
            if (result.DepartmentId == 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
            }
            return Ok("Added Successfully");
        }

        [HttpPut]
        [Route("EditDepartment")]
        public async Task<IActionResult> PUT(Department dep)
        {
            await _departmentManager.EditDepartment(dep);
            return Ok("Updated Successfully");
        }

        [HttpDelete]
        [Route("DeleteDepartment")]
        public JsonResult Delete(int id)
        {
            _departmentManager.DeleteDepartment(id);
            return new JsonResult("Deleted Successfully");
        }
    }
}
