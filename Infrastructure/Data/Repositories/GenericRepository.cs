using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly StoreContext _context;
        public GenericRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var item =  await _context.Set<T>().FindAsync(id);
            return item;
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            var items = await _context.Set<T>().ToListAsync();
            return items;
        }
    }
}