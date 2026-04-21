// custom exception
namespace BankingSystem.Exceptions
{
    public class InsufficientBalanceException : Exception
    {
        public double CurrentBalance { get; }
        public double AttemptedAmount { get; }

        public InsufficientBalanceException(double currentBalance, double attemptedAmount)
            : base($"Insufficient balance. Current balance: ₹{currentBalance:F2}, " +
                   $"Attempted: ₹{attemptedAmount:F2}. Minimum balance of ₹1000 must be maintained.")
        {
            CurrentBalance = currentBalance;
            AttemptedAmount = attemptedAmount;
        }

        public InsufficientBalanceException(string message) : base(message) { }
    }
}
