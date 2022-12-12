using Employee.Application.Dtos;
using Employee.Application.Mappers;
using Employee.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Application.Features.Employees.Queries.GetEmployees
{
    public class GetEmployeesQueryHandler : IRequestHandler<GetEmployeesQuery, List<EmployeeResponse>>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetEmployeesQueryHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<List<EmployeeResponse>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
        {

            var employees = await _employeeRepository.GetAllAsync();

            var employeeResponse = EmployeeMapper.Mapper.Map<List<EmployeeResponse>>(employees);
            return employeeResponse;
        }
    }
}
