using BankKata.Domain;
using Moq;
using NUnit.Framework;

namespace BankKata.Tests
{
    [TestFixture]
    public class TransactionRepositoryShould
    {
        private const string TodaysDate = "01/04/2014";
        private const int DepositAmount = 1000;
        private const int WithdrawalAmount = 100;
        private ITransactionRepository transactionRepository;
        private Mock<IClock> clock;

        [SetUp]
        public void SetUp()
        {
            clock = new Mock<IClock>();
            clock.Setup(x => x.TodaysDateAsString()).Returns(TodaysDate);
            transactionRepository = new TransactionRepository(clock.Object);
        }

        [Test]
        public void Process_deposit_transaction()
        {
            transactionRepository.AddDeposit(DepositAmount);
            var transactions = transactionRepository.GetAllTransactions();

            Assert.That(transactions.Count, Is.EqualTo(1));
            Assert.That(transactions[0].DateCreated, Is.EqualTo(TodaysDate));
            Assert.That(transactions[0].Amount, Is.EqualTo(DepositAmount));
        }

        [Test]
        public void Process_withdrawal_transaction()
        {
            transactionRepository.AddWithdrawal(WithdrawalAmount);
            var transactions = transactionRepository.GetAllTransactions();

            Assert.That(transactions.Count, Is.EqualTo(1));
            Assert.That(transactions[0].DateCreated, Is.EqualTo(TodaysDate));
            Assert.That(transactions[0].Amount, Is.EqualTo(-WithdrawalAmount));
        }

        [Test]
        public void Get_a_list_of_all_transactions()
        {
            transactionRepository.AddDeposit(DepositAmount);
            transactionRepository.AddWithdrawal(WithdrawalAmount);

            var transactions = transactionRepository.GetAllTransactions();

            Assert.That(transactions.Count, Is.EqualTo(2));
        }
    }
}