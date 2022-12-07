using Employee.Core.Repositories;
using Employee.Core.Repositories.Base;
using Employee.Infrastructure.Repositories;
using Employee.Infrastructure.Repositories.Base;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Infrastructure.utils
{
    public static class InfrastructureExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {  
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
        }
    }
}
