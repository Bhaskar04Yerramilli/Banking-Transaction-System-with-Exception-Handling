namespace BankingSystem.Exceptions
{
    public class InvalidAmountException : Exception
    {
        public double AttemptedAmount { get; }

        public InvalidAmountException(double attemptedAmount)
            : base($"Invalid amount: ₹{attemptedAmount:F2}. Amount must be greater than 0.")
        {
            AttemptedAmount = attemptedAmount;
        }

        public InvalidAmountException(string message) : base(message) { }
    }
}
