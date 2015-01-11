using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace BankAccountApp
{
    [ TestFixture ]
   public class AccountFixture
    {
        private Account anAccount;

        [SetUp]
        public void Init()
        {
            anAccount= new Account();
        }
        [Test]
        public void InitialBalanceTest()
        {
            
            Assert.AreEqual(0,anAccount.Balance);
        }

        [Test]
        public void DepositTest()
        {
            anAccount.Deposite(500);
            Assert.AreEqual(500,anAccount.Balance);
        }

        [Test]
        public void WithdrawTest()
        {
            anAccount.Deposite(550);
            anAccount.Withdraw(200);
            Assert.AreEqual(350,anAccount.Balance);
        }

        [Test]
        public void InsufficientBalanceTest()
        {
            anAccount.Deposite(400);
            anAccount.Withdraw(230);
            anAccount.Withdraw(500);
            Assert.AreEqual(170,anAccount.Balance);
        }

        [TearDown]
        public void End()
        {
            anAccount = null;
        }
    }
}
