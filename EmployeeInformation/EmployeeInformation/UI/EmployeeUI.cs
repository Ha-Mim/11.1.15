using System;
using System.Collections.Generic;
using System.Windows.Forms;
using EmployeeInformation.BLL;
using EmployeeInformation.DAL.DAO;

namespace EmployeeInformation.UI
{
    public partial class EmployeeUI : Form
    {
        private Employee aEmployee;

        public EmployeeUI()
        {
            InitializeComponent();
        }
        
        public EmployeeUI(Employee anEmployee)
        {
            aEmployee = anEmployee;
            InitializeComponent();
            anEmployee=new Employee();
        }

        private EmployeeManager aEmployeeManager=new EmployeeManager();
        private void groupBox1_Enter(object sender, EventArgs e)
        {
            List<Designation> aDesignationList=new List<Designation>();
            aDesignationList = aEmployeeManager.Combobox();
            foreach (Designation aDesignation in aDesignationList)
            {
                designationComboBox.Items.Add(aDesignation);
            }
            designationComboBox.DisplayMember = "Code";
            designationComboBox.ValueMember = "Id";
        }

     
        private void saveButton_Click(object sender, EventArgs e)
        {
            Employee aEmployee=new Employee();
            aEmployee.Name = nameTextBox.Text;
            aEmployee.Address = addressTextBox.Text;
            aEmployee.Email = emailTextBox.Text;
           
   
            Designation selectedDesignation = (Designation)designationComboBox.SelectedItem;
            aEmployee.DesignationId = selectedDesignation.Id;
            string msg=aEmployeeManager.Save(aEmployee);
            MessageBox.Show(msg);

        }

        private void EmployeeUI_Load(object sender, EventArgs e)
        {
            if (aEmployee != null)
            {
                nameTextBox.Text = aEmployee.Name;
                addressTextBox.Text = aEmployee.Address;
                emailTextBox.Text = aEmployee.Email;
                designationComboBox.SelectedText = aEmployee.ADesignation.Code;
            }
           
        }

        
    }
}
