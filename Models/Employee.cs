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
    [Table("employee")]
    public class Employee
    {
        [Key]
        public int Id { get; private set; }

        public string Name { get; private set; }

        public string Age {  get; private set; }

        public string Photo {  get; private set; }

        public Employee(string Name, string Age, string Photo)
        {
            this.Name = Name;
            this.Age = Age;
            this.Photo = Photo;
        }
    }
}
