namespace ProvaPub.TypesOfPayments
{
    public class PayPalPaymentProcessor : IPaymentProcessor
    {
        public bool CanProcess(string paymentMethod)
        {
            return paymentMethod == "paypal";
        }
        public async Task<bool> ProcessPayment(decimal paymentValue)
        {
            // Lógica de pagamento via PayPal
            return true;
        }
    }
}
