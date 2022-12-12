using Employee.Application.Dtos;
using Employee.Application.Exceptions;
using Employee.Application.Mappers;
using Employee.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Application.Features.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, EmployeeResponse>
    {

        private readonly IEmployeeRepository _employeeRepository;

        public CreateEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<EmployeeResponse> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {

            CreateEmployeeCommandValidator validations = new CreateEmployeeCommandValidator();
            var result = await validations.ValidateAsync(request);

            if (result.Errors.Any()) {
                throw new CustomExceptions("Employee is not valid", result.Errors.Select(err => err.ErrorMessage).ToList());
             }
            var employeeEntity = EmployeeMapper.Mapper.Map<Core.Entities.Employee>(request);

            var newEmployee = await _employeeRepository.AddAsync(employeeEntity);
            var employeeResponse = EmployeeMapper.Mapper.Map<EmployeeResponse>(newEmployee);

            return employeeResponse;
        }
    }
}
