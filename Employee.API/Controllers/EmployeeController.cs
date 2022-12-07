using Employee.Application.Exceptions;
using Employee.Application.Features.Employees.Commands.CreateEmployee;
using Employee.Application.Features.Employees.Commands.RemoveEmployee;
using Employee.Application.Features.Employees.Queries.GetEmployeeById;
using Employee.Application.Features.Employees.Queries.GetEmployees;
using Employee.Application.Features.Employees.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<EmployeeResponse>> CreateEmployee([FromBody] CreateEmployeeCommand command)
        {
            var respons = new ResponsAPI<EmployeeResponse>();
            try
            {
                  respons.Data = await _mediator.Send(command);
            }
            catch (CustomExceptions ex)
            {   
                ex.ErrorMessages.ForEach(messag => respons.AddError(messag));
                return BadRequest(respons);
            }
            return Ok(respons);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<EmployeeResponse>>> GetEmployees()
        {
            var respons = new ResponsAPI<List<EmployeeResponse>>();

            try
            {
               respons.Data = await _mediator.Send(new GetEmployeesQuery());
            }
            catch(CustomExceptions ex)
            {
                respons.AddError(ex.Message);
                return BadRequest(respons);
            }
            return Ok(respons);
        }

        [HttpGet("{employeeId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<EmployeeResponse>> GetEmployeeById(int employeeId)
        {
            var respons = new ResponsAPI<EmployeeResponse>();
            try
            {
                respons.Data = await _mediator.Send(new GetEmployeeByIdQuery() { Id = employeeId });
            }
            catch(Exception ex)
            {
                respons.AddError(ex.Message);
                return BadRequest(respons);
            }
            return Ok(respons);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<EmployeeResponse>> DeleteEmployees(int employeeId)
        {
            var respons = new ResponsAPI<string>();
            try
            {
                await _mediator.Send(new RemoveEmployeeCommand() { Id = employeeId });
                respons.Data = "Employee Deleted";
            }
            catch (Exception ex)
            {
                respons.AddError("Something is error");
                return NotFound(respons);
            }

            return Ok(respons);
        }
    }
}
