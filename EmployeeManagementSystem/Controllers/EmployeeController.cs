using EmployeeManagementSystem.Model;
using EmployeeManagementSystem.Sevices;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee _db;
        public EmployeeController(IEmployee db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetEmployees()
        {
            IEnumerable<Employee> employees = _db.GetAllEmployees;
            return Ok(employees); //200 status code
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            Employee employee = await _db.GetEmployeeById(id);
            if (employee is null)
            {
                return NotFound();//404
            }
            return Ok(employee);
        }
        //api/controller/3
        //api/controller?id=3
        [HttpGet("search/id")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            Employee employee = await _db.GetEmployeeById(id);
            if (employee is null)
            {
                return NotFound();//404
            }
            return Ok(employee);
        }

        //Add employee
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Employee employee)
        {
            Employee currentEmployee = await _db.GetEmployeeByName(employee.Name);
            if (currentEmployee is not null)
            {
                return BadRequest("This employee already exists");
            }
            await _db.AddEmployee(employee);
            return Ok(employee);
        }
        //api/controller/3?k=10


        [HttpGet("search/name")]
        public async Task<IActionResult> GetEmployeeByName(string name)
        {
            var employee = await _db.GetEmployeeByName(name);
            if (employee is null)
                return NotFound();
            return Ok(employee);
        }
        //api/controller/search/names
        //api/controller/search/name

        [HttpGet("search/names")]
        public IActionResult GetEmployeesByName(string name)
        {
            var employees = _db.SearchEmployee(name);
            return Ok(employees);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployee([FromBody]Employee employee)
        {
            /*  if (employee is null)
                  return NotFound();*/
            /*Employee currentEmployee = await _db.GetEmployeeById(employee.Id);
            if (currentEmployee is null)
            {
                return NotFound("Employee not found");
            }*/
            await _db.UpdateEmployee(employee);
            return Ok("Updated");
        }

        [HttpDelete("{employeeId}")]
        public async Task<IActionResult> DeleteEmployee(int employeeId)
        {
            Employee currentEmployee = await _db.GetEmployeeById(employeeId);
            if (currentEmployee is null)
                return NotFound();
            await _db.DeleteEmployee(currentEmployee);
            return Ok("Deleted");
        }
    }
}
