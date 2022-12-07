using Employee.Application.Features.Employees.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Application.Features.Employees.Queries.GetEmployees
{
    public class GetEmployeesQuery : IRequest<List<EmployeeResponse>>
    {
    }
}
