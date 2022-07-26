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

        //POST
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Employee employee)
        {
            await _db.AddEmployee(employee);
            return Ok(employee);
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
        /* [HttpGet("search/id")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            Employee employee = await _db.GetEmployeeById(id);
            if (employee is null)
            {
                return NotFound();//404
            }
            return Ok(employee);
        }*/
        [HttpPut("{employeeId}")]
        public async Task<IActionResult> UpdateEmployee(int employeeId, Employee employee)
        {
            if (employee is null)
                return NotFound();
            await _db.UpdateEmployee(employee);
            return Ok();
        }

        [HttpGet("search/name")]
        public async Task<IActionResult> GetEmployeeByName(string name)
        {
            var employee = await _db.GetEmployeeByName(name);
            if (employee is null)
                return NotFound();
            return Ok(employee);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteEmployee(Employee employee)
        {
            if (employee is null)
                return NotFound();
            await _db.DeleteEmployee(employee);
            return Ok();
        }
    }
}
