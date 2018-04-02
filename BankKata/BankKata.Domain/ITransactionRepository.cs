using System.Collections.Generic;

namespace BankKata.Domain
{
    public interface ITransactionRepository
    {
        void AddDeposit(int amount);

        void AddWithdrawal(int amount);

        List<Transaction> GetAllTransactions();
    }
}