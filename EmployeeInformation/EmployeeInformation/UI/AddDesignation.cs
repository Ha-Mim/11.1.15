using System;
using System.Windows.Forms;
using EmployeeInformation.BLL;
using EmployeeInformation.DAL.DAO;

namespace EmployeeInformation.UI
{
    public partial class AddDesignation : Form
    {
        public AddDesignation()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Designation aDesignation = new Designation();
            aDesignation.Code = codeTextBox.Text;
            aDesignation.Name = titleTextBox.Text;
            DesignationManager aDesignationManager = new DesignationManager();
            string msg = aDesignationManager.Save(aDesignation);
            MessageBox.Show(msg);

        }
    }
}
