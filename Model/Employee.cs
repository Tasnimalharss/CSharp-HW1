namespace EmployeeInfo.Model
{
    class Employee
    {

        public string employeeId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string birthDate { get; set; }
        public string address { get; set; }
        public string dept { get; set; }

        public Employee(string employeeId, string firstName, string lastName, string birthDate, string address, string dept)
        {
            this.employeeId = employeeId;
            this.firstName = firstName;
            this.lastName = lastName;
            this.birthDate = birthDate;
            this.address = address;
            this.dept = dept;
        }
    }
}
