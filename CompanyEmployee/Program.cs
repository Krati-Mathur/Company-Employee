using Microsoft.EntityFrameworkCore;
using CompanyEmployee.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using Newtonsoft.Json.Serialization;
using CompanyEmployee.Repository;
using Microsoft.OpenApi.Models;
using CompanyEmployee.Manager;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("EmployeeAppCon");
builder.Services.AddDbContext<CompanyContext>(option => option.UseSqlServer(connectionString));


// Add services to the container.
builder.Services.AddTransient<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddTransient<IDepartmentManager, DepartmentManager>();
builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddTransient<IEmployeeManager, EmployeeManager>();


builder.Services.AddControllersWithViews().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore).AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors
(c =>
{
    var policyName = "CompanyEmployee";
    c.AddPolicy(name: policyName,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:5001", "http://localhost:4200/");
                      });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

    app.UseDeveloperExceptionPage();
}

app.UseExceptionHandler("/Error");

app.UseHsts();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "CompanyEmployee");
});

app.Run();
