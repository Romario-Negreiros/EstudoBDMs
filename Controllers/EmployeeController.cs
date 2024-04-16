using EstudoBDM.Infraestructure;
using EstudoBDM.Repositories;
using EstudoBDM.DTOs;
using EstudoBDM.Models;
using Microsoft.AspNetCore.Mvc;

namespace EstudoBDM.Controllers
{
    [ApiController]
    [Route("api/v1/employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly IUnitOfWork _uof;
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IUnitOfWork unitOfWork)
        {
            _uof = unitOfWork;
            _employeeRepository = unitOfWork.EmployeeRepository;
        }

        [HttpPost]
        public IActionResult Add(EmployeeDTOs.AddEmployeeDTO addEmployee) {
            if (addEmployee.Name == null)
            {
                return BadRequest("Name cannot be empty!");
            }

            if (addEmployee.Age == null)
            {
                return BadRequest("Age cannot be empty!");
            }

            var employee = new Employee(addEmployee);

            var newEmployee = _employeeRepository.Add(employee);

            _uof.Commit();

            return Created(uri: "Url to get created resource", newEmployee);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var employees = _employeeRepository.GetAll();

            return Ok(employees);
        }
    }
}
