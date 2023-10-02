using ProvaPub.Models;
using ProvaPub.Repositories.Interfaces;
using ProvaPub.Services.Interfaces;

namespace ProvaPub.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;
        private readonly IPaginationService _pagination;

        public CustomerService(ICustomerRepository repository, IPaginationService pagination)
        {
            _repository = repository;
            _pagination = pagination;
        }

        public ListInfo<Customer> ListCustomers(int page)
        {
            return _pagination.ListEntities<Customer>(page);
        }

        public PurchaseResult CanPurchase(int customerId, decimal purchaseValue)
        {
            var customer = _repository.GetById(customerId);
            if (customer == null)
            {
                return PurchaseResult.Fail($"Customer Id {customerId} does not exist");
            }

            if (purchaseValue <= 0)
            {
                return PurchaseResult.Fail("Invalid purchase value");
            }

            if (HasPurchasedThisMonth(customerId))
            {
                return PurchaseResult.Fail("Customer has already purchased this month");
            }

            if (IsFirstPurchase(customerId) && purchaseValue > 100)
            {
                return PurchaseResult.Fail("First purchase must be <= 100");
            }

            return PurchaseResult.Success();
        }

        public bool HasPurchasedThisMonth(int customerId)
        {
            var baseDate = DateTime.UtcNow.AddMonths(-1);
            var ordersInThisMonth = _repository.GetOrdersInThisMonth(customerId, baseDate);
            return ordersInThisMonth > 0;
        }

        public bool IsFirstPurchase(int customerId)
        {
            var haveBoughtBefore = _repository.GetHaveBoughtBefore(customerId);
            return haveBoughtBefore == 0;
        }
    }
}
