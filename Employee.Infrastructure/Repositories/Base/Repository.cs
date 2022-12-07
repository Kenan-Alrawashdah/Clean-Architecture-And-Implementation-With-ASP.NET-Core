using Employee.Core.Repositories.Base;
using Employee.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Infrastructure.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        protected readonly EmployeeContext _context;

        public Repository(EmployeeContext context)
        {
            _context= context;
        }
        public async Task<T> AddAsync(T entity)
        {
           await _context.AddAsync(entity);
           await _context.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            var x = _context.Remove(entity);
            await _context.SaveChangesAsync();   

        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id)  ;
        }

        public async Task UpdateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(UpdateAsync)} entity must not be null");
            }

                _context.Update(entity);
                await _context.SaveChangesAsync();
        }
    }
}
