using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Application.Features.Employees.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommandValidator: AbstractValidator<UpdateEmployeeCommand>
    {
        public UpdateEmployeeCommandValidator()
        {  
            // custom message error
            RuleFor(e => e.FirstName)
           .NotEmpty().WithMessage("The first name must be at least 2 character long")
           .MaximumLength(100).WithMessage("First name must exceed 100 characters");

            // defult message error
            RuleFor(e => e.LastName)
            .NotEmpty()
            .MaximumLength(100);

            RuleFor(e => e.PhoneNumber).Matches(@"\(?\d{3}\)?[-\.]? *\d{3}[-\.]? *[-\.]?\d{4}");
        }
    }
}
