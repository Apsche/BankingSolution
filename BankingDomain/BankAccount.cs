using System;

namespace BankingDomain
{
    public class BankAccount
    {
        private decimal CurrentBalance = 5000;

        public decimal GetBalance()
        {
            return CurrentBalance;
        }

        public void Withdraw(decimal amountToWithdraw)
        {
            if (amountToWithdraw > CurrentBalance)
                return;
            CurrentBalance -= amountToWithdraw;
        }

        public void Deposit(decimal amountToDeposit)
        {
            CurrentBalance += amountToDeposit;
        }
    }
}