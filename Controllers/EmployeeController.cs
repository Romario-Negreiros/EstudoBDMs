using EstudoBDM.Infraestructure;
using EstudoBDM.Repositories;
using EstudoBDM.DTOs;
using EstudoBDM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

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
        [Authorize]
        [ScopeRequirement(claimValue: "write")]
        public IActionResult Add(EmployeeDTOs.AddEmployeeDTO addEmployee) {
            if (addEmployee.name == null)
            {
                return BadRequest("Name cannot be empty!");
            }

            if (addEmployee.age == null)
            {
                return BadRequest("Age cannot be empty!");
            }

            var employee = new Employee(addEmployee);

            var newEmployee = _employeeRepository.Add(employee);

            _uof.Commit();

            return Created(uri: "Url to get created resource", newEmployee);
        }

        [HttpGet]
        [Authorize]
        [ScopeRequirement(claimValue: "read")]
        public IActionResult GetAll()
        {
            var employees = _employeeRepository.GetAll();

            return Ok(employees);
        }
    }
}
