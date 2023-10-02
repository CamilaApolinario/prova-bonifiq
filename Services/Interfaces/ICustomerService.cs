using ProvaPub.Models;

namespace ProvaPub.Services.Interfaces
{
    public interface ICustomerService
    {
        ListInfo<Customer> ListCustomers(int page);

        PurchaseResult CanPurchase(int customerId, decimal purchaseValue);

        bool HasPurchasedThisMonth(int customerId);

        bool IsFirstPurchase(int customerId);
        
    }
}