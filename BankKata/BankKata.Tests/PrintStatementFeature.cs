﻿using BankKata.Domain;
using Moq;
using NUnit.Framework;

namespace BankKata.Tests
{
    [TestFixture]
    public class PrintStatementFeature
    {
        private Mock<IOutputWriter> outputWriter;
        private Account account;
        private ITransactionRepository transactionRepository;
        private IStatementPrinter statementPrinter;

        [SetUp]
        public void SetUp()
        {
            outputWriter = new Mock<IOutputWriter>();

            account = new Account(transactionRepository, statementPrinter);
        }

        [Test]
        public void Print_statement_of_all_transactions()
        {
            account.Deposit(1000);
            account.Withdrawal(100);
            account.Deposit(500);

            account.PrintStatement();

            outputWriter.Verify(m => m.PrintLine(" DATE | AMOUNT | BALANCE"));
            outputWriter.Verify(m => m.PrintLine("10/04/2014 | 500.00 | 1400.00"));
            outputWriter.Verify(m => m.PrintLine("02/04/2014 | -100.00 | 900.00"));
            outputWriter.Verify(m => m.PrintLine("01/04/2014 | 1000.00 | 1000.00"));
        }
    }
}