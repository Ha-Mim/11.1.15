namespace EmployeeInformation.DAL.DAO
{
    public class Employee
    {
        public string Name { set; get; }
        public string Email { set; get; }
        public string Address { set; get; }
        public int DesignationId { set; get; }

        public int SerialNo { set; get; }
        public Designation ADesignation { set; get; }



    }
}
