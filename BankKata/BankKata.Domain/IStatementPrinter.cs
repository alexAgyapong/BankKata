using System.Collections.Generic;

namespace BankKata.Domain
{
    public interface IStatementPrinter
    {
        void Print(List<Transaction> allTransactions);
    }
}