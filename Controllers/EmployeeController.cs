using CRUDOperations;
using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Template;
using OperationsInterface;

namespace EmployeeManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public readonly IOperations _operations;
        public EmployeeController()
        {
            _operations = new Operations();
        }


        [HttpGet(template: "/RetrieveEmployeeByID")]
        public IActionResult GetEmployeeByID(string empID_to_recover)
        {
            var employee = _operations.RetrieveEmployeeByID(empID_to_recover);
            if (employee == null)
            {
                return BadRequest(error: "Employee not found");
            }
            return Ok(employee);
        }


        [HttpGet(template:"/GetAllEmployee")]
        public ActionResult GetAllEmployee() {

            var employees = _operations.GetEmployeeList();
            if (employees == null)
                return BadRequest("Bad Request");
            else
            return Ok(employees);
        }  


        [HttpPost(template: "/AddEmployee")]
        public IActionResult AddEmployee(EmployeeDto e)
        {

            if (e == null)
            {
                return BadRequest(error: "Give employee details!");
            }
            else
            {
                _operations.AddEmployee(e);
                return Ok(e.EmployeeName);
            }

        }


        [HttpPut(template: "/UpdateEmployee")]
        public IActionResult UpdateEmployee(string employeeId, EmployeeDto updatedEmployee)
        {

            if (updatedEmployee == null)
            {
                return BadRequest(error: "Give employee details!");
            }
            else
            {
                _operations.UpdateEmployee(employeeId, updatedEmployee);
                return Ok(value: "Updated Successfully");
            }
        }


        [HttpDelete(template: "/DeleteEmployee")]
        public IActionResult DeleteEmployee(string id)
        {
            if (id == null)
            {
                return BadRequest(error: "ID doesn't exist");

            }
            else
            {
                _operations.DeleteEmployee(id);
                return Ok(value: "Deleted Successfully");
            }
        }


        [HttpGet(template: "/GetCountOfEmployeesByDepartment")]
        public IActionResult GetCountOfEmployeesByDepartment(int id)
        {

            var employee = _operations.GetCountOfEmployeesByDepartment(id);
            if (employee == null)
            {
                return BadRequest(error: "Employee not found with this DeptID");
            }
            return Ok(employee);
        }


        [HttpGet(template: "/LastUpdatedEmployees")]
        public IActionResult LastUpdatedEmployee()
        {
            var employee = _operations.LastUpdatedEmployee();

            if (employee == null)
            {
                return BadRequest(error: "not found");
            }
            return Ok(employee);
        }


        [HttpDelete(template: "/SoftDelete")]
        public IActionResult SoftDeleteEmployee(string id)
        {
            if (id == null)
            {
                return BadRequest(error: "ID doesn't exist");

            }
            else
            {
                _operations.SoftDeleteEmployee(id);
                return Ok(value: "Softdeleted Successfully");
            }
        }


        [HttpGet(template: "/GetTopSalariesEmployeesDepartmentWise")]
        public IActionResult GetTopSalariesEmployeesDepartmentWise(int count)
        {

            if (count == null)
            {
                return BadRequest(error: "enter a value");
            }
            var employee = _operations.GetTopSalariesEmployeesDepartmentWise(count);
            return Ok(employee);
        }
    }
}