using BankingDomain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingTests
{
    class BankAccountTests
    {
        BankAccount account;

        public BankAccountTests()
        {
            account = new BankAccount();
        }

        [Fact]
        public void NewAccountHasCorrectBalance()
        {
            decimal currentBalance = account.GetBalance();

            Assert.Equal(5000M, currentBalance);
        }

        [Fact]
        public void WithdrawDecreasesBalance()
        {
            // Arrange - Given
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
            var openingBalance = account.GetBalance();
            var amountToDeposit = 1M;
            // Arrange - When
            account.Deposit(amountToDeposit);
            // Arrange - Then
            Assert.Equal(openingBalance + amountToDeposit, account.GetBalance());
        }

        [Fact]
        public void OverDraftDoesNotIncreaseBalance()
        {
            var openingBalance = account.GetBalance();

            try
            {
                account.Withdraw(openingBalance + 1);
            }
            catch (Exception)
            {

            }

            Assert.Equal(openingBalance, account.GetBalance());
        }

        [Fact]
        public void OverDraftThrowsException()
        {
            Assert.Throws<OverdraftException>(
                () => account.Withdraw(account.GetBalance() + 1));
        }
    }

}
