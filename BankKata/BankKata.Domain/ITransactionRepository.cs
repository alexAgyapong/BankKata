using System.Collections.Generic;

namespace BankKata.Domain
{
    public interface ITransactionRepository
    {
        bool AddDeposit(int amount);

        void AddWithdrawal(int amount);

        List<Transaction> GetAllTransactions();
    }
}