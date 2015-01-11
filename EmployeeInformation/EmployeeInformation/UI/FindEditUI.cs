using System;
using System.Collections.Generic;
using System.Windows.Forms;
using EmployeeInformation.BLL;
using EmployeeInformation.DAL.DAO;

namespace EmployeeInformation.UI
{
    public partial class FindEditUI : Form
    {
        
        public FindEditUI()
        {
            InitializeComponent();
            
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
           EmployeeManager aEmployeeManager=new EmployeeManager();
               Employee aEmploye=new Employee();
               aEmploye.Name = searchTextBox.Text;
            List<Employee> aEmployee=new List<Employee>();
            aEmployee = aEmployeeManager.SearchEmployees(aEmploye.Name);
            showlistView.Items.Clear();
              
            foreach (Employee employee in aEmployee)
            {
                ListViewItem myView = new ListViewItem();  
                myView.Text = (employee.SerialNo.ToString());
                myView.SubItems.Add(employee.Name);
                myView.SubItems.Add(employee.Email);
                myView.SubItems.Add(employee.Address);
                myView.SubItems.Add(employee.ADesignation.Code);
                myView.SubItems.Add(employee.ADesignation.Name);
                myView.Tag = employee;
                 showlistView.Items.Add(myView);
            }
              
                

               
            }

        private void showlistView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                showListcontextMenuStrip.Show(showlistView, e.Location);
        }

        private void showListcontextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            EmployeeManager aEmployeeManager = new EmployeeManager();
            if (e.ClickedItem == editToolStripMenuItem)
            {
                showListcontextMenuStrip.Hide();
                ListViewItem aListViewItem = showlistView.SelectedItems[0];
                Employee anEmployee = (Employee)aListViewItem.Tag;
                EmployeeUI aEmployeeUi =new EmployeeUI(anEmployee);
                aEmployeeUi.Show();
            }
            else if (e.ClickedItem == deleteToolStripMenuItem)
            {
                showListcontextMenuStrip.Hide();
                ListViewItem aListViewItem = showlistView.SelectedItems[0];
                Employee anEmployee = (Employee) aListViewItem.Tag;
                aEmployeeManager.RemoveEmployee(anEmployee);
                MessageBox.Show(@"Selected Employee has been removed.");
                showlistView.Items.Remove(aListViewItem);
            }
        }
           

        }

       
 
        
       
        
    }

