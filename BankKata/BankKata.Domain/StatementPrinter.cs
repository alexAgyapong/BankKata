using System.Collections.Generic;

namespace BankKata.Domain
{
    public class StatementPrinter : IStatementPrinter
    {
        private const string StatementHeader = "DATE | AMOUNT | BALANCE";
        private readonly IOutputWriter outputWriter;

        public StatementPrinter(IOutputWriter outputWriter)
        {
            this.outputWriter = outputWriter;
        }

        public void Print(List<Transaction> allTransactions)
        {
            outputWriter.PrintLine(StatementHeader);
        }
    }
}