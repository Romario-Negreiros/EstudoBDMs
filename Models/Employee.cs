using EstudoBDM.RouteModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EstudoBDM.Models
{
    public interface IEmployee
    {
        int Id { get; }
        string Name { get; }
        string Age { get; }
        string Photo { get; }
    }
    [Table("EMPLOYEE")]
    public class Employee
    {
        [Key]
        public int Id { get; private set; }

        public string Name { get; private set; }

        public int Age {  get; private set; }

        public string? Photo {  get; private set; }

        public Employee(string Name, int Age, string Photo)
        {
            this.Name  = Name;
            this.Age   = Age;
            this.Photo = Photo;
        }

        public Employee(EmployeeRouteModels.AddEmployeeModel addEmployee)
        {
            // Nullable fields have been already checked here

            Name  = addEmployee.Name!;
            Age   = (int)addEmployee.Age!;
            Photo = addEmployee.Photo;
        }
    }
}
