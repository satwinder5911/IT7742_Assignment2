using System;
using CustomerAppTests.Exceptions;

namespace CustomerAppTests.Model
{
    public abstract class Account
    {
        private static int _nextId = 1;

        public int Id { get; private set; }
        public decimal Balance { get; protected set; }
        public string LastTransactionInfo { get; protected set; } = "";

        protected Account(decimal initialBalance = 0m)
        {
            if (initialBalance < 0m)
                initialBalance = 0m;

            Id = _nextId++;
            Balance = initialBalance;
            LastTransactionInfo = $"{GetType().Name} {Id} created. Balance: {Balance:0.00}";
        }

        public virtual void Deposit(decimal amount)
        {
            if (amount <= 0m)
            {
                LastTransactionInfo = $"{GetType().Name} {Id}; Deposit: {amount:0.00}; Status: Invalid; Balance: {Balance:0.00};";
                throw new ArgumentException("Deposit amount must be greater than zero.");
            }

            Balance += amount;
            LastTransactionInfo = $"{GetType().Name} {Id}; Deposit: {amount:0.00}; Updated Balance: {Balance:0.00};";
        }

        public bool Withdraw(Customer who, decimal amount)
        {
            if (amount <= 0m)
            {
                LastTransactionInfo = $"{GetType().Name} {Id}; Withdrawal: {amount:0.00}; Status: Invalid; Balance: {Balance:0.00};";
                throw new ArgumentException("Invalid withdrawal amount.");
            }

            if (!CanWithdraw(amount))
            {
                decimal fee = FailedFee(who);
                if (fee > 0m) Balance -= fee;

                LastTransactionInfo = $"{GetType().Name} {Id}; Withdrawal Attempt: {amount:0.00}; Failed; Fee: {fee:0.00}; Balance: {Balance:0.00};";
                throw new FailedWithdrawalException("Insufficient balance for withdrawal.", GetType().Name);
            }

            Balance -= amount;
            LastTransactionInfo = $"{GetType().Name} {Id}; Withdrawal: {amount:0.00}; OK; Balance: {Balance:0.00};";
            return true;
        }

        protected virtual bool CanWithdraw(decimal amount)
        {
            return Balance >= amount;
        }

        protected virtual decimal FailedFee(Customer who)
        {
            // Staff get 50% off failed withdrawal fee
            return who.IsStaff ? 2.5m : 5m;
        }

        public virtual decimal AddInterest()
        {
            LastTransactionInfo = $"{GetType().Name} {Id}; Interest: Not supported; Balance: {Balance:0.00};";
            return 0m;
        }

        public virtual string Info()
        {
            return $"{GetType().Name} {Id}; Current Balance: {Balance:0.00};";
        }
    }
}
