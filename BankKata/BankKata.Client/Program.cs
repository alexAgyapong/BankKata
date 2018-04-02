using BankKata.Domain;
using System;

namespace BankKata.Client
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var clock = new Clock();
            var outputWriter = new OutputWriter();
            var transactionRepository = new TransactionRepository(clock);
            var statementPrinter = new StatementPrinter(outputWriter);
            var account = new Account(transactionRepository, statementPrinter);

            Console.WriteLine();
            account.Deposit(1000);
            account.Withdrawal(100);
            account.Deposit(500);

            account.PrintStatement();

            Console.ReadLine();
        }
    }
}