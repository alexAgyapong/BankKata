using System;

namespace BankKata.Domain
{
    public class TestableClock : Clock
    {
        protected override DateTime TodaysDate()
        {
            return new DateTime(2014, 04, 01);
        }
    }
}