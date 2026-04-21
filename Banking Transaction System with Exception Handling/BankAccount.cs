// Deposit ans withdraw logic
using BankingSystem.Exceptions;

namespace BankingSystem
{
    public class BankAccount
    {
        private const double MinimumBalance = 1000.00;

        public string AccountHolderName { get; private set; }
        public double Balance { get; private set; }

        public BankAccount(string accountHolderName, double initialBalance)
        {
            if (string.IsNullOrWhiteSpace(accountHolderName))
                throw new ArgumentException("Account holder name cannot be empty.", nameof(accountHolderName));

            if (initialBalance < MinimumBalance)
                throw new InvalidOperationException(
                    $"Initial balance must be at least ₹{MinimumBalance:F2}.");

            AccountHolderName = accountHolderName;
            Balance = initialBalance;
        }

        /// <summary>
        /// Deposits a valid positive amount into the account.
        /// Throws InvalidAmountException if amount <= 0.
        /// </summary>
        public void Deposit(double amount)
        {
            if (amount <= 0)
                throw new InvalidAmountException(amount);

            Balance += amount;
            Console.WriteLine($"  ✔ Deposited ₹{amount:F2} successfully.");
        }

        /// <summary>
        /// Withdraws amount from the account.
        /// Throws InvalidAmountException if amount <= 0.
        /// Throws InsufficientBalanceException if withdrawal exceeds balance
        /// or would bring balance below the minimum threshold.
        /// </summary>
        public void Withdraw(double amount)
        {
            if (amount <= 0)
                throw new InvalidAmountException(amount);

            if (amount > Balance)
                throw new InsufficientBalanceException(Balance, amount);

            if ((Balance - amount) < MinimumBalance)
                throw new InsufficientBalanceException(
                    $"Cannot withdraw ₹{amount:F2}. Balance would fall below the minimum " +
                    $"required balance of ₹{MinimumBalance:F2}. Current balance: ₹{Balance:F2}.");

            Balance -= amount;
            Console.WriteLine($"  ✔ Withdrawn ₹{amount:F2} successfully.");
        }

        /// <summary>
        /// Displays the current balance.
        /// </summary>
        public void CheckBalance()
        {
            Console.WriteLine($"  Account Holder : {AccountHolderName}");
            Console.WriteLine($"  Current Balance: ₹{Balance:F2}");
        }
    }
}