using Employee.Application.Exceptions;
using Employee.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Application.Features.Employees.Commands.RemoveEmployee
{
    public class RemoveEmployeeCommandHandler : IRequestHandler<RemoveEmployeeCommand>
    {

        private readonly IEmployeeRepository _employeeRepository;

        public RemoveEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<Unit> Handle(RemoveEmployeeCommand request, CancellationToken cancellationToken)
        {

            await _employeeRepository.DeleteAsync(new Core.Entities.Employee { EmployeeId = request.Id });

            return Unit.Value;
        }
    }
}
