using ProvaPub.Models;
using ProvaPub.Repositories.Interfaces;
using ProvaPub.Repository;

namespace ProvaPub.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly TestDbContext _context;

        public OrderRepository(TestDbContext context)
        {
            _context = context;
        }
        public void AddOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }
    }
}
