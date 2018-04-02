using BankKata.Domain;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace BankKata.Tests
{
    [TestFixture]
    public class AccountShould
    {
        private const int DepositAmount = 1000;
        private const int WithdrawalAmount = 100;
        private IAccount account;
        private Mock<ITransactionRepository> transactionRepository;
        private Mock<IStatementPrinter> statementPrinter;

        [SetUp]
        public void SetUp()
        {
            transactionRepository = new Mock<ITransactionRepository>();
            statementPrinter = new Mock<IStatementPrinter>();

            account = new Account(transactionRepository.Object, statementPrinter.Object);
        }

        [Test]
        public void Add_deposit_transaction()
        {
            account.Deposit(DepositAmount);

            transactionRepository.Verify(x => x.AddDeposit(DepositAmount));
        }

        [Test]
        public void Add_withdrawal_transaction()
        {
            account.Withdrawal(WithdrawalAmount);

            transactionRepository.Verify(x => x.AddWithdrawal(WithdrawalAmount));
        }

        [Test]
        public void Print_statement_for_transactions()
        {
            var transactions = new List<Transaction>();
            transactionRepository.Setup(x => x.GetAllTransactions()).Returns(transactions);

            account.PrintStatement();

            statementPrinter.Verify(x => x.Print(transactions));
        }

        private List<Transaction> GetTransactions()
        {
            var transactions = new List<Transaction>
            {
                new Transaction("10/04/2014",500),
                new Transaction("02/04/2014",-100),
                new Transaction("01/04/2014",1000)
            };
            return transactions;
        }
    }
}