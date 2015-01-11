using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using EmployeeInformation.DAL.DAO;
using EmployeeInformation.DAL.DBGateway;

namespace EmployeeInformation.BLL
{
    class EmployeeManager
    {
       
        public List<Designation> Combobox()
        {
            EmployeeDBGateway aEmployeeDbGateway = new EmployeeDBGateway();
            return aEmployeeDbGateway.ComboboxLoad();
        }

        public string Save(Employee aEmployee)
        {
            EmployeeDBGateway aEmployeeDbGateway = new EmployeeDBGateway();
            if (aEmployeeDbGateway.UniqueCheker(aEmployee.Email)==null)
            {
               aEmployeeDbGateway.Save(aEmployee);
                return "Successfully Save";
            }
            else
            {
                return "Please Give a unique email!";
            }
        }

        public List<Employee> SearchEmployees(string name)
        {
            EmployeeDBGateway aEmployeeDbGateway = new EmployeeDBGateway();
            return aEmployeeDbGateway.Search(name);
        }

        public void RemoveEmployee(Employee anEmployee)
        {
            EmployeeDBGateway aEmployeeDbGateway = new EmployeeDBGateway();
            if (aEmployeeDbGateway.GetEmployee(anEmployee.Name) != null)
                
            aEmployeeDbGateway.RemoveEmployee(anEmployee);
        }
    }
}
 