using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculator
{
    class Salary
    {
        public string EmployeeName { get; set; }
        public double BasicSalary { get; set; }
        public double HouseRentPercent { get; set; }
        public double MedicalAllowancePercent { get; set; }

        public double GetSalary()
        {
            return BasicSalary + GetHouseAmount() + GetMedicalAmount();

        }

       public double GetMedicalAmount()
        {
            return (HouseRentPercent * BasicSalary) / 100;
        }

        public double GetHouseAmount()
        {
            return (MedicalAllowancePercent * BasicSalary) / 100;
        }
    }
}
