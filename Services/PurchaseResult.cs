namespace ProvaPub.Services
{
    public class PurchaseResult
    {
        public bool CanPurchase { get; private set; }
        public string ErrorMessage { get; private set; }

        private PurchaseResult(bool canPurchase, string errorMessage)
        {
            CanPurchase = canPurchase;
            ErrorMessage = errorMessage;
        }

        public static PurchaseResult Success()
        {
            return new PurchaseResult(true, null);
        }

        public static PurchaseResult Fail(string errorMessage)
        {
            return new PurchaseResult(false, errorMessage);
        }
    }
}
