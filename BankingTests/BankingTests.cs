using BankingDomain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingTests
{
    class BankAccountTests
    {
        [Fact]
        public void NewAccountHasCorrectBalance()
        {
            var account = new BankAccount();

            decimal currentBalance = account.GetBalance();

            Assert.Equal(5000M, currentBalance);
        }

        [Fact]
        public void WithdrawDecreasesBalance()
        {
            // Arrange - Given
            var account = new BankAccount();
            var openingBalance = account.GetBalance();
            var amountToWithdraw = 1M;
            // Arrange - When
            account.Withdraw(amountToWithdraw);
            // Arrange - Then
            Assert.Equal(openingBalance - amountToWithdraw, account.GetBalance());
        }

        [Fact]
        public void DepositIncreasesBalance()
        {
            // Arrange - Given
            var account = new BankAccount();
            var openingBalance = account.GetBalance();
            var amountToDeposit = 1M;
            // Arrange - When
            account.Deposit(amountToDeposit);
            // Arrange - Then
            Assert.Equal(openingBalance + amountToDeposit, account.GetBalance());
        }

        [Fact]
        public void overDraftDoesNotIncreaseBalance()
        {
            var account = new BankAccount();
            var openingBalance = account.GetBalance();

            account.Withdraw(openingBalance + 1);

            Assert.Equal(openingBalance, account.GetBalance());
        }
    }

}
