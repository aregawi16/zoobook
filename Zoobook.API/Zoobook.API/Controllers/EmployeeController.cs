using Microsoft.AspNetCore.Mvc;
using Zoobook.Application.EmployeeService;
using Zoobook.Domain.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Zoobook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<IActionResult> Gets()
        {
            var result = await _employeeService.GetAllAsync();
            return Ok(result);
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _employeeService.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound("Employee Not Found");
            }
            return Ok(result);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _employeeService.AddAsync(employee);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest("Employee ID mismatch");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _employeeService.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound("Employee Not Found");
            }

            await _employeeService.UpdateAsync(employee, result);
            return NoContent();
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _employeeService.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound("Employee Not Found");
            }

            await _employeeService.RemoveAsync(id);
            return NoContent();
        }
    }
}