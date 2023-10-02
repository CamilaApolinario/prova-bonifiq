namespace ProvaPub.TypesOfPayments
{
    public class CreditCardPaymentProcessor : IPaymentProcessor
    {
        public bool CanProcess(string paymentMethod)
        {
            return paymentMethod == "creditcard";
        }

        public async Task<bool> ProcessPayment(decimal paymentValue)
        {
            // Lógica de pagamento via cartão de crédito
            return true;
        }
    }
}
