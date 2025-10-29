using Microsoft.VisualStudio.TestTools.UnitTesting;
using CustomerAppTests.Model;
using CustomerAppTests.Exceptions;
using System;

namespace CustomerAppTests
{
    [TestClass]
    public class AccountTests
    {
        private class TestAccount : Account
        {
            public TestAccount(decimal start = 0m) : base(start) { }
        }

        [TestMethod]
        public void Deposit_ShouldIncreaseBalance()
        {
            var acc = new TestAccount(100m);
            acc.Deposit(50m);

            Assert.AreEqual(150m, acc.Balance, "Deposit failed to increase balance correctly.");
            StringAssert.Contains(acc.LastTransactionInfo, "Updated Balance", "Transaction info not updated properly.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Deposit_ShouldThrow_WhenAmountInvalid()
        {
            var acc = new TestAccount(100m);
            acc.Deposit(-10m);
        }

        [TestMethod]
        public void Withdraw_ShouldReduceBalance_WhenEnoughFunds()
        {
            var acc = new TestAccount(200m);
            var cust = new Customer("Alex");

            bool result = acc.Withdraw(cust, 50m);

            Assert.IsTrue(result, "Expected withdrawal to succeed.");
            Assert.AreEqual(150m, acc.Balance, "Balance not reduced correctly.");
            StringAssert.Contains(acc.LastTransactionInfo, "OK", "Transaction log not marked as OK.");
        }

        [TestMethod]
        public void Withdraw_ShouldApplyFee_WhenInsufficientFunds()
        {
            var acc = new TestAccount(30m);
            var cust = new Customer("John");

            try
            {
                acc.Withdraw(cust, 100m);
                Assert.Fail("Expected FailedWithdrawalException was not thrown.");
            }
            catch (FailedWithdrawalException ex)
            {
                Assert.AreEqual("TestAccount", ex.AccountType);
                Assert.IsTrue(acc.LastTransactionInfo.Contains("Fee"), "Fee was not recorded in transaction info.");
            }
        }

        [TestMethod]
        public void Withdraw_ShouldApplyHalfFee_ForStaffCustomer()
        {
            var acc = new TestAccount(50m);
            var staff = new Customer("Emma", true);

            try
            {
                acc.Withdraw(staff, 200m);
            }
            catch (FailedWithdrawalException)
            {
                Assert.IsTrue(acc.LastTransactionInfo.Contains("2.50"), "Staff discount fee not applied properly.");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Withdraw_ShouldThrow_WhenAmountIsZero()
        {
            var acc = new TestAccount(100m);
            var c = new Customer("Liam");
            acc.Withdraw(c, 0m);
        }

        [TestMethod]
        public void Info_ShouldReturnStringWithBalance()
        {
            var acc = new TestAccount(500m);
            string info = acc.Info();

            StringAssert.Contains(info, "Balance", "Info text missing balance data.");
            StringAssert.Contains(info, "TestAccount", "Account type name not included in Info().");
        }

        [TestMethod]
        public void AddInterest_ShouldReturnZeroAndMessage()
        {
            var acc = new TestAccount(400m);
            decimal val = acc.AddInterest();

            Assert.AreEqual(0m, val, "Default AddInterest should return 0.");
            StringAssert.Contains(acc.LastTransactionInfo, "Interest: Not supported", "Interest message missing.");
        }
    }
}
