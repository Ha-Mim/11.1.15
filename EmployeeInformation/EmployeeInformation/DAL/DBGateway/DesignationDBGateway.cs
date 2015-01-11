using System.Configuration;
using System.Data.SqlClient;
using EmployeeInformation.DAL.DAO;

namespace EmployeeInformation.DAL.DBGateway
{
    internal class DesignationDBGateway
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["MyKey"].ConnectionString;
           

        private SqlConnection connection;

        public DesignationDBGateway()
        {
            connection = new SqlConnection(connectionString);
        }

        public void Save(Designation aDesignation)
        {
            connection.Open();
            string query = "INSERT INTO tbl_Designation VALUES('" + aDesignation.Code + "','" + aDesignation.Name + "')";
            SqlCommand command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
            connection.Close();

        }

        public Designation Find(string code)
        {
            connection.Open();
            string query = "SELECT * FROM tbl_Designation WHERE Code ='" + code + "';";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)

            {
                reader.Read();
                Designation aDesignation = new Designation();
                aDesignation.Id = (int) reader["Id"];
                aDesignation.Code = reader["Code"].ToString();
                aDesignation.Name = reader["title"].ToString();
                reader.Close();
                connection.Close();
                return aDesignation;

            }
            else
            {

                reader.Close();
                connection.Close();
                return null;
            }

        }

       

    }
}

