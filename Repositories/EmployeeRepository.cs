#pragma warning disable CS8604

using EstudoBDM.Configs;
using EstudoBDM.Models;
using Microsoft.EntityFrameworkCore;

namespace EstudoBDM.Repositories
{
    public interface IEmployeeRepository
    {
        Employee Add(Employee employee);

        List<Employee> GetAll();
    }
    public class EmployeeRepository : IEmployeeRepository
    {
        public DatabaseConnection DbCon;

        public EmployeeRepository(DatabaseConnection DbCon) {
            this.DbCon = DbCon;
        }

        public Employee Add(Employee employee)
        {
            var result = DbCon.Employees.FromSqlRaw("CALL sp_ins_employee({0}, {1}, {2});", employee.name, employee.age, employee.photo);

            var newEmployee = result.ToList().ElementAt(0);

            return newEmployee;
        }

        public List<Employee> GetAll()
        {
            return DbCon.Employees.FromSqlRaw("CALL sp_get_all_employees();").ToList();
        }
    }
}
