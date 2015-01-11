using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using EmployeeInformation.DAL.DAO;

namespace EmployeeInformation.DAL.DBGateway
{
    internal class EmployeeDBGateway
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["Mykey"].ConnectionString;
        private SqlConnection connection;

        public EmployeeDBGateway()
        {
            connection=new SqlConnection(connectionString);
        }
        public List<Designation> ComboboxLoad()
        {


            List<Designation> designationList = new List<Designation>();
           
            
            connection.Open();
            string query = "SELECT * FROM tbl_Designation";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Designation aDesignation = new Designation();
                aDesignation.Id = (int) reader["Id"];
                aDesignation.Code = reader["Code"].ToString();
                aDesignation.Name = reader["title"].ToString();
                designationList.Add(aDesignation);

            }
            reader.Close();
            connection.Close();
            return designationList;
        }

        public void Save(Employee aEmployee)
        {

            connection.Open();
            string query = "INSERT INTO tbl_Employee VALUES('" + aEmployee.Name + "','" + aEmployee.Email + "','" +
                           aEmployee.Address + "','" + aEmployee.DesignationId + "')";
            SqlCommand command = new SqlCommand(query, connection);
           command.ExecuteNonQuery();
            connection.Close();

        }

        public Employee UniqueCheker(string email)
        {


            connection.Open();
            string query = "SELECT * FROM tbl_Employee WHERE Email='" + email + "';";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();



                Employee aEmployee = new Employee();
                aEmployee.Name = reader["Name"].ToString();
                aEmployee.Email = reader["Email"].ToString();
                aEmployee.Address = reader["Address"].ToString();
                reader.Close();
                connection.Close();
                return aEmployee;
            }
            else
            {
                reader.Close();
                connection.Close();
                return null;
            }


    
            
        }
        public List<Employee> Search(string name)
        {

            string query = "";
            Employee aEmploye = new Employee();


            connection.Open();
            if (name != string.Empty)
            {
                query = "SELECT  Emp.Serial,Emp.Name,Emp.Email,Emp.Address,Des.Code,Des.title FROM tbl_Employee As Emp JOIN tbl_Designation AS Des ON Emp.designationId=Des.Id WHERE Name='" + name + "';";
            }
            else
            {
                query = "SELECT  Emp.Serial,Emp.Name,Emp.Email,Emp.Address,Des.Code,Des.title FROM tbl_Employee As Emp JOIN tbl_Designation AS Des ON Emp.designationId=Des.Id ";
            }
            List<Employee> employees = new List<Employee>();
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Employee aEmployee = new Employee();
                aEmployee.SerialNo = (int)reader["serial"];
                aEmployee.Name = reader["Name"].ToString();
                aEmployee.Email = reader["Email"].ToString();
                aEmployee.Address = reader["Address"].ToString();
                aEmployee.ADesignation.Code = reader["Code"].ToString();
                aEmployee.ADesignation.Name = reader["title"].ToString();


                employees.Add(aEmployee);

            }
            reader.Close();
            connection.Close();
            return employees;
        }

        internal void RemoveEmployee(Employee Employee)
        {
            string deleteQuery = "delete from tbl_employee where serial='" + Employee.SerialNo+"';";
            connection.Open();
             SqlCommand command = new SqlCommand(deleteQuery, connection);
            command.ExecuteNonQuery();
         connection.Close();
        }
        public Employee GetEmployee(string employeename)
        {
            foreach (Employee employee in Search(employeename))
            {
                if (employee.Name == employeename)
                    return employee;
            }
            return null;
        }
    }

}
