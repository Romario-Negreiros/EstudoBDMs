using EstudoBDM.Infraestructure;
using EstudoBDM.Configs;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DatabaseConnection>(options =>
{
    string connectionString = $"Server   = {Environment.GetEnvironmentVariable("Server")};" +
                              // $"Port     = {Environment.GetEnvironmentVariable("Port")};" +
                              $"Database = {Environment.GetEnvironmentVariable("Database")};" +
                              $"User     = {Environment.GetEnvironmentVariable("UserId")};" +
                              $"Password = {Environment.GetEnvironmentVariable("Password")};";

    connectionString = "server=localhost;user=romario;password=123456;database=estudobdm";

    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); // TODO: Learn how to customize Swagger UI.

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(policy =>
{
    policy.AllowAnyOrigin();
    policy.AllowAnyMethod();
    policy.AllowAnyHeader();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
