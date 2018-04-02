using System;

namespace BankKata.Domain
{
    public class Clock : IClock
    {
        public string TodaysDateAsString()
        {
            return TodaysDate().ToString("dd/MM/yyyy");
        }

        protected virtual DateTime TodaysDate()
        {
            return DateTime.Now;
        }
    }
}