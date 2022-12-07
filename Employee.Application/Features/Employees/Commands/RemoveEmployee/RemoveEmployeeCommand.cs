using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Application.Features.Employees.Commands.RemoveEmployee
{
    public class RemoveEmployeeCommand : IRequest
    {
        public int Id { get; set; }
    }
}
