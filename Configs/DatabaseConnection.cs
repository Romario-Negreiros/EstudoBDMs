using Microsoft.EntityFrameworkCore;
using EstudoBDM.Models;

namespace EstudoBDM.Configs
{
    public class DatabaseConnection : DbContext
    {
        #pragma warning disable 8618
        public DatabaseConnection(DbContextOptions<DatabaseConnection> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
    }
}
