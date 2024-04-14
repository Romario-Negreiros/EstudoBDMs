using EstudoBDM.Configs;
using EstudoBDM.Models;

namespace EstudoBDM.Repositories
{
    public interface IEmployeeRepository
    {
        void Add(Employee employee);

        List<Employee> GetAll();
    }
    public class EmployeeRepository : IEmployeeRepository
    {
        public DatabaseConnection DbCon;

        public EmployeeRepository(DatabaseConnection DbCon) {
            this.DbCon = DbCon;
        }

        public void Add(Employee employee)
        {
            DbCon.Add(employee);
        }

        public List<Employee> GetAll()
        {
            return DbCon.Employees.ToList();
        }
    }
}
