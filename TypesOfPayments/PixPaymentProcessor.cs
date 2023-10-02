namespace ProvaPub.TypesOfPayments
{
    public class PixPaymentProcessor : IPaymentProcessor
    {
        public bool CanProcess(string paymentMethod)
        {
            return paymentMethod == "pix";
        }
        public async Task<bool> ProcessPayment(decimal paymentValue)
        {
            // Lógica de pagamento via Pix
            return true;
        }
    }
}
