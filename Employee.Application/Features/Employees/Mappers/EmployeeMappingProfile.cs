using AutoMapper;
using Employee.Application.Features.Employees.Commands.CreateEmployee;
using Employee.Application.Features.Employees.Commands.UpdateEmployee;
using Employee.Application.Features.Employees.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Application.Features.Employees.Mappers
{
    public class EmployeeMappingProfile : Profile
    {
        public EmployeeMappingProfile()
        {
            CreateMap<Core.Entities.Employee, EmployeeResponse>().ReverseMap();
            CreateMap<Core.Entities.Employee, CreateEmployeeCommand>().ReverseMap();
            CreateMap<Core.Entities.Employee, UpdateEmployeeCommand>().ReverseMap();
        }
    }
}
