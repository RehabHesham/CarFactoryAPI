namespace CarAPI.Payment
{
    public class CashService : ICashService
    {
        public string Pay(double amount)
        {
            // Logic
            return $"Amount: {amount} is paid through Cash";
        }
    }
}