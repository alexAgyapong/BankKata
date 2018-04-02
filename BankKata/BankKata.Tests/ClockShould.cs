using BankKata.Domain;
using NUnit.Framework;

namespace BankKata.Tests
{
    [TestFixture]
    public class ClockShould
    {
        private const string ExpectedDate = "01/04/2014";

        [Test]
        public void Return_todays_date_as_string_in_dd_MM_yyyy_format()
        {
            var clock = new TestableClock();
            var todaysDate = clock.TodaysDateAsString();
            Assert.That(todaysDate, Is.EqualTo(ExpectedDate));
        }
    }
}