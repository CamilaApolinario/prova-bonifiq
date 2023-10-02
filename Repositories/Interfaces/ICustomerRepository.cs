using ProvaPub.Models;

namespace ProvaPub.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        List<Customer> GetAllCustomer();
        Customer GetById(int id);
        int GetHaveBoughtBefore(int id);
        int GetOrdersInThisMonth(int id, DateTime baseDate);
    }
}