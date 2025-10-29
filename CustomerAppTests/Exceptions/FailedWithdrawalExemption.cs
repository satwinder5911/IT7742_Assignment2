using System;

namespace CustomerAppTests.Exceptions
{
    public class FailedWithdrawalException : Exception
    {
        public string AccountType { get; }

        public FailedWithdrawalException(string message, string type)
            : base(message)
        {
            AccountType = type;
        }
    }
}
