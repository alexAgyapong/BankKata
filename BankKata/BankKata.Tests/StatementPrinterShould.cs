using BankKata.Domain;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace BankKata.Tests
{
    public class StatementPrinterShould
    {
        private const string StatementHeader = "DATE | AMOUNT | BALANCE";
        private IStatementPrinter statemenPrinter;
        private Mock<IOutputWriter> outputWriter;

        [SetUp]
        public void SetUp()
        {
            outputWriter = new Mock<IOutputWriter>();
            statemenPrinter = new StatementPrinter(outputWriter.Object);
        }

        [Test]
        public void Always_print_the_header()
        {
            var noTransactions = new List<Transaction>();
            statemenPrinter.Print(noTransactions);
            outputWriter.Verify(x => x.PrintLine(StatementHeader));
        }

        [Test]
        public void Print_statement_of_all_transactions()
        {
            var transactions = GetTransactions();
            statemenPrinter.Print(transactions);

            outputWriter.Verify(m => m.PrintLine("DATE | AMOUNT | BALANCE"));
            outputWriter.Verify(m => m.PrintLine("10/04/2014 | 500.00 | 1400.00"));
            outputWriter.Verify(m => m.PrintLine("02/04/2014 | -100.00 | 900.00"));
            outputWriter.Verify(m => m.PrintLine("01/04/2014 | 1000.00 | 1000.00"));
        }

        private List<Transaction> GetTransactions()
        {
            var transactions = new List<Transaction>
            {
                new Transaction("01/04/2014",1000),
                new Transaction("02/04/2014",-100),
                new Transaction("10/04/2014",500)
            };
            return transactions;
        }
    }
}