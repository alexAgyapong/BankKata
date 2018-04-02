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
    }
}