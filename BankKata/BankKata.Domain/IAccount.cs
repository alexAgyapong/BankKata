namespace BankKata.Domain
{
    public interface IAccount
    {
        void Deposit(int amount);

        void PrintStatement();

        void Withdrawal(int amount);
    }
}