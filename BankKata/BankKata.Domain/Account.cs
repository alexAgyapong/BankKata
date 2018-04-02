namespace BankKata.Domain
{
    public class Account : IAccount
    {
        private readonly ITransactionRepository transactionRepository;
        private readonly IStatementPrinter statementPrinter;

        public Account(ITransactionRepository transactionRepository,
                       IStatementPrinter statementPrinter)
        {
            this.transactionRepository = transactionRepository;
            this.statementPrinter = statementPrinter;
        }

        public void Deposit(int amount)
        {
            transactionRepository.AddDeposit(amount);
        }

        public void Withdrawal(int amount)
        {
            transactionRepository.AddWithdrawal(amount);
        }

        public void PrintStatement()
        {
            statementPrinter.Print(transactionRepository.GetAllTransactions());
        }
    }
}