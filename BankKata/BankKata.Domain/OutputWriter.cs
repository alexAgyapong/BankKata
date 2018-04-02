using System;

namespace BankKata.Domain
{
    public class OutputWriter : IOutputWriter
    {
        public void PrintLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}