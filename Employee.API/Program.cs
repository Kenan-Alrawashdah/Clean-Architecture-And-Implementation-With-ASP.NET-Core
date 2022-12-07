using Employee.Application.Features.Employees.Commands.CreateEmployee;
using Employee.Core.Repositories;
using Employee.Core.Repositories.Base;
using Employee.Infrastructure.Data;
using Employee.Infrastructure.Repositories;
using Employee.Infrastructure.Repositories.Base;
using Employee.Infrastructure.utils;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
var con = builder.Configuration.GetConnectionString("WebApiDatabase");
builder.Services.AddDbContext<EmployeeContext>(m => m.UseMySql(con, ServerVersion.AutoDetect(con)));
builder.Services.AddMediatR(typeof(CreateEmployeeCommandHandler).GetTypeInfo().Assembly);
builder.Services.AddRepositories();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
