using Microsoft.EntityFrameworkCore;
using EstudoBDM.Models;

namespace EstudoBDM.Configs
{
    public class DatabaseConnection : DbContext
    {
        public DatabaseConnection(DbContextOptions<DatabaseConnection> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseNpgsql(
                    $"Server   = {Environment.GetEnvironmentVariable("Server")};" +
                    $"Port     = {Environment.GetEnvironmentVariable("Port")};" +
                    $"Database = {Environment.GetEnvironmentVariable("Database")};" +
                    $"User Id  = {Environment.GetEnvironmentVariable("UserId")};" +
                    $"Password = {Environment.GetEnvironmentVariable("Password")};"
                );
        }
    }
}
