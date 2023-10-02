using ProvaPub.Models;
using ProvaPub.Repositories.Interfaces;
using ProvaPub.Services.Interfaces;
using ProvaPub.TypesOfPayments;

namespace ProvaPub.Services
{
    public class OrderService : IOrderService
	{
        private readonly ICustomerRepository _customerRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IEnumerable<IPaymentProcessor> _paymentProcessors;

        public OrderService(ICustomerRepository customerRepository,
                            IOrderRepository orderRepository,
                            IEnumerable<IPaymentProcessor> paymentProcessors)
        {
            _customerRepository = customerRepository;
            _orderRepository = orderRepository;
            _paymentProcessors = paymentProcessors;
        }

        public async Task<Order> PayOrder(string paymentMethod, decimal paymentValue, int customerId)
		{
            var paymentProcessor = _paymentProcessors.SingleOrDefault(p => p.CanProcess(paymentMethod)) ?? throw new ArgumentException("Método de pagamento não suportado.");
            bool paymentResult = await paymentProcessor.ProcessPayment(paymentValue);
            var customer = _customerRepository.GetById(customerId);
            
            if (paymentResult)
            {
                var order = new Order()
                {
                    Value = paymentValue,
                    CustomerId = customerId,
                    OrderDate = DateTime.Now,
                    Customer = customer,
                };
                _orderRepository.AddOrder(order);
                return order;
            }
            else
            {
                throw new Exception("O pagamento não pôde ser processado.");
            }
        }
    }	
}
