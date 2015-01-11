using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountApp
{
    class Account
    {
        public string AccountNo { set; get; }
        public double Balance { set; get; }

        public string OpeningDate { set; get; }

        public Account()
        {
            Balance = 0;
        }

        public double Deposite(double amount)
        {
           return Balance += amount;
        }

        public double Withdraw(double amount)

        {
            if (amount < Balance)
            {
                return Balance -= amount;
            }
            else
            {
                return Balance;
            }
        }
    }
}
