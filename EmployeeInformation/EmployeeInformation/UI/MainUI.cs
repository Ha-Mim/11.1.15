using System;
using System.Windows.Forms;

namespace EmployeeInformation.UI
{
    public partial class MainUI : Form
    {
        public MainUI()
        {
            InitializeComponent();
        }

        private void addEmployeeButton_Click(object sender, EventArgs e)
        {
            EmployeeUI employee = new EmployeeUI();
            employee.Show();
        }

        private void addDesignationButton_Click(object sender, EventArgs e)
        {
            AddDesignation designation = new AddDesignation();
            designation.Show();
        }

        private void findEditButton_Click(object sender, EventArgs e)
        {
            FindEditUI aFindEditUi =new FindEditUI();
            aFindEditUi.Show();
        }
    }
}
