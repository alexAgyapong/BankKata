using System.Collections.Generic;

namespace BankKata.Domain
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly IClock clock;
        private List<Transaction> transactions = new List<Transaction>();

        public TransactionRepository(IClock clock)
        {
            this.clock = clock;
        }

        public void AddDeposit(int amount)
        {
            var todaysDate = clock.TodaysDateAsString();
            var deposit = new Transaction(todaysDate, amount);
            transactions.Add(deposit);
        }

        public void AddWithdrawal(int amount)
        {
            var todaysDate = clock.TodaysDateAsString();
            var withdrawal = new Transaction(todaysDate, -amount);
            transactions.Add(withdrawal);
        }

        public List<Transaction> GetAllTransactions()
        {
            return transactions;
        }
    }
}