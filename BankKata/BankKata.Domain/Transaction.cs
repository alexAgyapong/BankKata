namespace BankKata.Domain
{
    public class Transaction
    {
        public string DateCreated { get; private set; }
        public int Amount { get; private set; }

        public Transaction(string date, int amount)
        {
            DateCreated = date;
            Amount = amount;
        }
    }
}