using EstudoBDM.Configs;

namespace EstudoBDM.Repository
{
    public interface IEmployeeRepository
    {
        void Add(Employee employee);

        List<Employee> GetAll();
    }
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DatabaseConnection dbCon = new DatabaseConnection();

        public void Add(Employee employee)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
