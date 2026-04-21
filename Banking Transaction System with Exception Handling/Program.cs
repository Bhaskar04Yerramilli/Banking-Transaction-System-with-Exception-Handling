// BankAccount class - Core banking logic 
using BankingSystem;
using BankingSystem.Exceptions;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("==============================================");
        Console.WriteLine("   Banking Transaction System - C# Demo      ");
        Console.WriteLine("==============================================\n");

        // ---------------------------------------------------------------
        // Account Setup
        // ---------------------------------------------------------------
        BankAccount account = null;

        try
        {
            Console.WriteLine(">>> Creating account for Arjun Sharma with ₹5000...");
            account = new BankAccount("Arjun Sharma", 5000.00);
            Console.WriteLine("  ✔ Account created successfully.\n");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"  [ArgumentException] {ex.Message}");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"  [InvalidOperationException] {ex.Message}");
        }
        finally
        {
            Console.WriteLine("  --- Account setup block executed ---\n");
        }

        if (account == null) return;

        // ---------------------------------------------------------------
        // Scenario 1: Valid Deposit (US1)
        // ---------------------------------------------------------------
        Console.WriteLine("----------------------------------------------");
        Console.WriteLine("Scenario 1: Valid Deposit of ₹2000");
        Console.WriteLine("----------------------------------------------");
        try
        {
            account.Deposit(2000.00);
            account.CheckBalance();
        }
        catch (InvalidAmountException ex)
        {
            Console.WriteLine($"  [InvalidAmountException] {ex.Message}");
        }
        finally
        {
            Console.WriteLine("  --- Deposit block executed ---\n");
        }

        // ---------------------------------------------------------------
        // Scenario 2: Invalid Deposit – amount <= 0 (US4)
        // ---------------------------------------------------------------
        Console.WriteLine("----------------------------------------------");
        Console.WriteLine("Scenario 2: Invalid Deposit of ₹-500");
        Console.WriteLine("----------------------------------------------");
        try
        {
            account.Deposit(-500.00);
        }
        catch (InvalidAmountException ex)
        {
            Console.WriteLine($"  [InvalidAmountException] {ex.Message}");
        }
        finally
        {
            Console.WriteLine("  --- Invalid deposit block executed ---\n");
        }

        // ---------------------------------------------------------------
        // Scenario 3: Valid Withdrawal (US2)
        // ---------------------------------------------------------------
        Console.WriteLine("----------------------------------------------");
        Console.WriteLine("Scenario 3: Valid Withdrawal of ₹3000");
        Console.WriteLine("----------------------------------------------");
        try
        {
            account.Withdraw(3000.00);
            account.CheckBalance();
        }
        catch (InsufficientBalanceException ex)
        {
            Console.WriteLine($"  [InsufficientBalanceException] {ex.Message}");
        }
        catch (InvalidAmountException ex)
        {
            Console.WriteLine($"  [InvalidAmountException] {ex.Message}");
        }
        finally
        {
            Console.WriteLine("  --- Valid withdrawal block executed ---\n");
        }

        // ---------------------------------------------------------------
        // Scenario 4: Withdrawal exceeds balance (US3)
        // ---------------------------------------------------------------
        Console.WriteLine("----------------------------------------------");
        Console.WriteLine("Scenario 4: Withdraw ₹10000 (exceeds balance)");
        Console.WriteLine("----------------------------------------------");
        try
        {
            account.Withdraw(10000.00);
        }
        catch (InsufficientBalanceException ex)
        {
            Console.WriteLine($"  [InsufficientBalanceException] {ex.Message}");
        }
        catch (InvalidAmountException ex)
        {
            Console.WriteLine($"  [InvalidAmountException] {ex.Message}");
        }
        finally
        {
            Console.WriteLine("  --- Exceeded balance withdrawal block executed ---\n");
        }

        // ---------------------------------------------------------------
        // Scenario 5: Withdrawal causing balance to fall below ₹1000 (US3)
        // ---------------------------------------------------------------
        Console.WriteLine("----------------------------------------------");
        Console.WriteLine("Scenario 5: Withdraw ₹3500 (balance would drop below ₹1000)");
        Console.WriteLine("----------------------------------------------");
        try
        {
            account.Withdraw(3500.00);
        }
        catch (InsufficientBalanceException ex)
        {
            Console.WriteLine($"  [InsufficientBalanceException] {ex.Message}");
        }
        catch (InvalidAmountException ex)
        {
            Console.WriteLine($"  [InvalidAmountException] {ex.Message}");
        }
        finally
        {
            Console.WriteLine("  --- Minimum balance guard block executed ---\n");
        }

        // ---------------------------------------------------------------
        // Scenario 6: Zero deposit (US4)
        // ---------------------------------------------------------------
        Console.WriteLine("----------------------------------------------");
        Console.WriteLine("Scenario 6: Deposit ₹0 (invalid zero amount)");
        Console.WriteLine("----------------------------------------------");
        try
        {
            account.Deposit(0);
        }
        catch (InvalidAmountException ex)
        {
            Console.WriteLine($"  [InvalidAmountException] {ex.Message}");
        }
        finally
        {
            Console.WriteLine("  --- Zero deposit block executed ---\n");
        }

        // ---------------------------------------------------------------
        // Final Balance
        // ---------------------------------------------------------------
        Console.WriteLine("==============================================");
        Console.WriteLine("   Final Account Status");
        Console.WriteLine("==============================================");
        account.CheckBalance();

        Console.WriteLine("\n==============================================");
        Console.WriteLine("   All scenarios completed. Program stable.  ");
        Console.WriteLine("==============================================");
    }
}