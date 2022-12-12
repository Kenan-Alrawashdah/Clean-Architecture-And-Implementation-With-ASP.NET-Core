using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Application.Interfaces
{
    public interface IPipelineBehavior<TRequest, TResponse> where TRequest: notnull
    {
        Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next );
    }
}
