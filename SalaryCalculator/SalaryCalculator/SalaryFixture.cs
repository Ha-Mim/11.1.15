using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SalaryCalculator
{
    class SalaryFixture
    {
        private Salary aSalary;
        [SetUp]
        public void Init()
        {
            aSalary = new Salary();
        }

        [Test]
        public void InitializeSalaryTest()
        {
            Assert.AreEqual(0,aSalary.GetSalary());
            Assert.AreEqual(0,aSalary.GetMedicalAmount());
            Assert.AreEqual(0,aSalary.GetHouseAmount());
        }

        [Test]
        public void BasicSalaryTest()
        {
            aSalary.BasicSalary = 12000;
            Assert.AreEqual(12000,aSalary.GetSalary());
        }

        [Test]
        public void MedicalAmountTest()
        {
            aSalary.BasicSalary = 12000;
            aSalary.MedicalAllowancePercent = 10;
            Assert.AreEqual(13200,aSalary.GetSalary());
        }

        [Test]
        public void HouseRentTest()
        {
            aSalary.BasicSalary = 12000;
            aSalary.HouseRentPercent = 20;
            Assert.AreEqual(14400,aSalary.GetSalary());
        }

        [Test]
        public void TotalSalaryTest()
        {
            aSalary.BasicSalary = 12000;
            aSalary.HouseRentPercent = 25;
            aSalary.MedicalAllowancePercent = 25;
            Assert.AreEqual(18000,aSalary.GetSalary());
        }

        [TearDown]
        public void End()
        {
            aSalary = null;
        }
    }
}
