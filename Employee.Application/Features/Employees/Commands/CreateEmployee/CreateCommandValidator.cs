using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Application.Features.Employees.Commands.CreateEmployee
{
    public class CreateCommandValidator: AbstractValidator<CreateEmployeeCommand>
    {
        public CreateCommandValidator() { 
            RuleFor(e => e.FirstName)
            .NotEmpty()
            .NotNull()
            .MaximumLength(100);

           RuleFor(e => e.LastName)
           .NotEmpty()
           .NotNull()
           .MaximumLength(100);
            //@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
            RuleFor(e => e.Email).EmailAddress();

            RuleFor(e => e.PhoneNumber).Matches(@"\(?\d{3}\)?[-\.]? *\d{3}[-\.]? *[-\.]?\d{4}");
        }
    }
}
