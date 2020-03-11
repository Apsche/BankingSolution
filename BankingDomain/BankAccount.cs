using System;

namespace BankingDomain
{
    public enum AccountType { Standard, Gold}
    public class BankAccount
    {
        private decimal CurrentBalance = 5000;
        public AccountType TypeOfAccount = AccountType.Standard;

        public decimal GetBalance()
        {
            return CurrentBalance;
        }

        public void Withdraw(decimal amountToWithdraw)
        {
            if (amountToWithdraw > CurrentBalance)
                throw new OverdraftException();
            else
                CurrentBalance -= amountToWithdraw;
        }

        public void Deposit(decimal amountToDeposit)
        {
            if (TypeOfAccount == AccountType.Gold)
                amountToDeposit *= 1.10M;
            CurrentBalance += amountToDeposit;
        }
    }
}