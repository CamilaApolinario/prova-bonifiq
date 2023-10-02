using Microsoft.EntityFrameworkCore;
using ProvaPub.Models;
using ProvaPub.Repositories.Interfaces;
using ProvaPub.Repository;

namespace ProvaPub.Repositories
{
    public class BaseRepository : IBaseRepository
    {
        private readonly TestDbContext _context;

        public BaseRepository(TestDbContext context)
        {
            _context = context;
        }
        public List<T> GetAll<T>() where T : class
        {
            if (typeof(T) == typeof(Customer))
            {
                return _context.Customers.Include(x => x.Orders).Cast<T>().ToList();
            }
            else
            {
                return _context.Set<T>().ToList();
            }
        }
    }
}
