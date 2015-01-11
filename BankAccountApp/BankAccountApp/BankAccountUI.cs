using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankAccountApp
{
    public partial class BankAccountUI : Form
    {
        public BankAccountUI()
        {
            InitializeComponent();
        }

        private Customer aCustomer;
        
        private void saveButton_Click(object sender, EventArgs e)
        {
            aCustomer = new Customer();
            
            aCustomer.Name = nameEntryTextBox.Text;
            aCustomer.Email = emailEntryTextBox.Text;

            Account aAccount = new Account();
            aAccount.AccountNo = accountNoEntryTextBox.Text;
            aAccount.OpeningDate = openningDateEntryTextBox.Text;

            aCustomer.CustomerAccount = aAccount;
            MessageBox.Show("Account Crreated");
        }

        private void depositButton_Click(object sender, EventArgs e)
        {
            if (aCustomer != null)
            {
                aCustomer.CustomerAccount.Deposite(Convert.ToDouble(amountTextBox.Text));
                MessageBox.Show("Money Deposited");
            }
            else
            {
                MessageBox.Show("Create an Account");
            }

        }

        private void withdrawButton_Click(object sender, EventArgs e)
        {
            if (aCustomer!=null)
            {
                aCustomer.CustomerAccount.Withdraw(Convert.ToDouble(amountTextBox.Text));
                MessageBox.Show("Money Withdrawed");
            }
            else
            {
                MessageBox.Show("Create an Account");
            }
            
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            customerNameDisplayTextBox.Text = aCustomer.Name;
            emailDisplayTextBox.Text = aCustomer.Email;
            accountnoDisplayTextBox.Text = aCustomer.CustomerAccount.AccountNo;
            openingDateDisplayTextBox.Text = aCustomer.CustomerAccount.OpeningDate;
            balanceDisplayTextBox.Text = aCustomer.CustomerAccount.Balance.ToString();
        }
    }
}
