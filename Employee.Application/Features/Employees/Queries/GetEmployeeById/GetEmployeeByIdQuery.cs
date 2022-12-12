using Employee.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Application.Features.Employees.Queries.GetEmployeeById
{
    public class GetEmployeeByIdQuery : IRequest<EmployeeResponse>
    {
        public int Id { get; set; }
    }
}
