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
            PrintStatementHeader();
            PrintStatementLines(FormatStatementLines(allTransactions));
        }

        private void PrintStatementHeader()
        {
            outputWriter.PrintLine(StatementHeader);
        }

        private void PrintStatementLines(IList<string> statementLines)
        {
            foreach (var line in statementLines)
            {
                outputWriter.PrintLine(line);
            }
        }

        private IList<string> FormatStatementLines(IList<Transaction> transactions)
        {
            var statementLines = new List<string>();
            var balance = 0;

            foreach (var transaction in transactions)
            {
                balance += transaction.Amount;
                statementLines.Add(($"{transaction.DateCreated} | {transaction.Amount:F} | {balance:F}"));
            }
            statementLines.Reverse();
            return statementLines;
        }
    }
}