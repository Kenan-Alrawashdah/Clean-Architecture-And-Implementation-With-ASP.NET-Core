using Employee.Application.Features.Employees.Mappers;
using Employee.Application.Features.Employees.Responses;
using Employee.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Application.Features.Employees.Queries.GetEmployeeById
{
    public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeResponse>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetEmployeeByIdQueryHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<EmployeeResponse> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var employeeentity = await _employeeRepository.GetByIdAsync(request.Id);
            var employeeResponse = EmployeeMapper.Mapper.Map<EmployeeResponse>(employeeentity);

            return employeeResponse;
        }
    }
}
