using Microsoft.EntityFrameworkCore;
using ProvaPub.Models;
using ProvaPub.Repositories.Interfaces;
using ProvaPub.Repository;

namespace ProvaPub.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly TestDbContext _context;

        public CustomerRepository(TestDbContext context)
        {
            _context = context;
        }

        public List<Customer> GetAllCustomer()
        {
            return _context.Customers.Include(x => x.Orders).ToList();
        }
        public Customer GetById(int id)
        {
            return _context.Customers.Include(x=>x.Orders).FirstOrDefault(x=>x.Id ==id);
        }
        public int GetOrdersInThisMonth(int id, DateTime baseDate)
        {
            return _context.Orders.Count(s => s.CustomerId == id && s.OrderDate >= baseDate);
        }

        public int GetHaveBoughtBefore(int id)
        {
            return _context.Customers.Count(s => s.Id == id && s.Orders.Any());
        }
    }
}
