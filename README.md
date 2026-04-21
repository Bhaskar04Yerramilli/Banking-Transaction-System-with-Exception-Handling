CSharp_ExceptionHandling_CaseStudy

Problem Statement

A Banking Transaction System built in C# that allows users to deposit money, withdraw money, and check account balance — while enforcing business rules through robust exception handling.

Business Rules:
- Minimum account balance must be ₹1000 at all times
- Withdrawal amount cannot exceed current balance
- Deposit amount must be greater than 0

Project Structure:

BankingSystem/
├── BankAccount.cs                          # Core banking logic
├── Program.cs                              # Entry point with test scenarios
├── Exceptions/
│   ├── InsufficientBalanceException.cs     # Custom exception for balance violations
│   └── InvalidAmountException.cs          # Custom exception for invalid amounts
└── README.md

Exception Types Used:

| Exception |                        | Type |                     | When Thrown |

| `InvalidAmountException`       | Custom (user-defined)  | Deposit or withdrawal amount ≤ 0 |
| `InsufficientBalanceException` | Custom (user-defined)  | Withdrawal exceeds balance or drops balance below ₹1000 |
| `ArgumentException`            | Built-in               | Empty account holder name |
| `InvalidOperationException`    | Built-in               | Initial balance below ₹1000 minimum |

All exception handling uses try-catch-finally blocks in `Program.cs`.

Sample Output:

==============================================
   Banking Transaction System - C# Demo
==============================================

>>> Creating account for Arjun Sharma with ₹5000...
  ✔ Account created successfully.
  --- Account setup block executed ---

----------------------------------------------
Scenario 1: Valid Deposit of ₹2000
----------------------------------------------
  ✔ Deposited ₹2000.00 successfully.
  Account Holder : Arjun Sharma
  Current Balance: ₹7000.00
  --- Deposit block executed ---

----------------------------------------------
Scenario 2: Invalid Deposit of ₹-500
----------------------------------------------
  [InvalidAmountException] Invalid amount: ₹-500.00. Amount must be greater than 0.
  --- Invalid deposit block executed ---

----------------------------------------------
Scenario 3: Valid Withdrawal of ₹3000
----------------------------------------------
  ✔ Withdrawn ₹3000.00 successfully.
  Account Holder : Arjun Sharma
  Current Balance: ₹4000.00
  --- Valid withdrawal block executed ---

----------------------------------------------
Scenario 4: Withdraw ₹10000 (exceeds balance)
----------------------------------------------
  [InsufficientBalanceException] Insufficient balance. Current balance: ₹4000.00,
  Attempted: ₹10000.00. Minimum balance of ₹1000 must be maintained.
  --- Exceeded balance withdrawal block executed ---

----------------------------------------------
Scenario 5: Withdraw ₹3500 (balance would drop below ₹1000)
----------------------------------------------
  [InsufficientBalanceException] Cannot withdraw ₹3500.00. Balance would fall
  below the minimum required balance of ₹1000.00. Current balance: ₹4000.00.
  --- Minimum balance guard block executed ---

----------------------------------------------
Scenario 6: Deposit ₹0 (invalid zero amount)
----------------------------------------------
  [InvalidAmountException] Invalid amount: ₹0.00. Amount must be greater than 0.
  --- Zero deposit block executed ---

==============================================
   Final Account Status
==============================================
  Account Holder : Arjun Sharma
  Current Balance: ₹4000.00

==============================================
   All scenarios completed. Program stable.
==============================================

User Stories Covered:

| ID | Story | Status |
|---|---|---|
| US1 | Deposit valid amount | ✅ Handled |
| US2 | Withdraw and update balance | ✅ Handled |
| US3 | Block withdrawal beyond limits | ✅ Custom exception thrown |
| US4 | Block invalid deposit amount | ✅ Custom exception handled |
| US5 | Custom exceptions for business rules | ✅ Implemented |
