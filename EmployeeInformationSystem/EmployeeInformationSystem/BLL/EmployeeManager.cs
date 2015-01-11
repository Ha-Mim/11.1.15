using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeInformationSystem.DAL.DAO;
using EmployeeInformationSystem.DAL.DBGateway;

namespace EmployeeInformationSystem.BLL
{
    class EmployeeManager
    {
        EmployeeDBGateway aDBGateway = new EmployeeDBGateway();
        public string Save(Employee aEmployee)
        {
            aDBGateway.Save(aEmployee);
            return "Saved";
        }
    }
}
