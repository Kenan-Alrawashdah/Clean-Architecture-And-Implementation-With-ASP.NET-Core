using Employee.Application.Dtos;
using Employee.Application.Exceptions;
using Employee.Application.Features.Employees.Commands.CreateEmployee;
using Employee.Application.Mappers;
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
            UpdateEmployeeCommandValidator validations = new UpdateEmployeeCommandValidator();
            var result = await validations.ValidateAsync(request);

            if(result.Errors.Any())
            {
                throw new CustomExceptions("Update emplyee is not vaild", result.Errors.Select(messageErr => messageErr.ErrorMessage).ToList());
            }
            var em = await _employeeRepository.GetByIdAsync(request.Id);
            
            if(em == null) {
                throw new CustomExceptions("Update emplyee is not vaild", new List<string> { $"No employee found with the id {request.Id}" });
            }
            var employeeEntity = EmployeeMapper.Mapper.Map<UpdateEmployeeCommand, Core.Entities.Employee>(request, em);
            var newEmployee = await _employeeRepository.UpdateAsync(employeeEntity);

            return EmployeeMapper.Mapper.Map<EmployeeResponse>(newEmployee);
        }
    }
}
