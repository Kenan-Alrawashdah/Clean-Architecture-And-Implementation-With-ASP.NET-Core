using Employee.Application.Features.Employees.Commands.CreateEmployee;
using Employee.Application.Features.Employees.Mappers;
using Employee.Application.Features.Employees.Responses;
using Employee.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Application.Features.Employees.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, EmployeeResponse>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public UpdateEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<EmployeeResponse> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            //TODO
            var employeeEntity = EmployeeMapper.Mapper.Map<Core.Entities.Employee>(request);

            var newEmployee = await _employeeRepository.UpdateAsync(employeeEntity);
            var employeeResponse = EmployeeMapper.Mapper.Map<EmployeeResponse>(newEmployee);

            return employeeResponse;
        }
    }
}
