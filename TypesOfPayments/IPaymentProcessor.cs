namespace ProvaPub.TypesOfPayments
{
    public interface IPaymentProcessor
    {
        bool CanProcess(string paymentMethod);
        Task<bool> ProcessPayment(decimal paymentValue);
    }
}
