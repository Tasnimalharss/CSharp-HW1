using EmployeeInfo.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace EmployeeInfo
{

    public partial class frmEmployee : Form
    {
        private List<Employee> Employeelists = new List<Employee>();

        public frmEmployee()
        {
            InitializeComponent();
        }

        private void frmEmployee_Load(object sender, EventArgs e)
        {

        }

        private void Add_Click(object sender, EventArgs e)
        {
           /*dGVEmployeeList.Rows.Add(txtId.Text, 
                                    txtFirstName.Text,
                                    txtLastName.Text, 
                                    txtBirthDate.Text, 
                                    txtAddress.Text,
                                    deptComboBox.Text); */

           Employeelists.Add(new Employee(txtId.Text,txtFirstName.Text,txtLastName.Text,
                                       txtBirthDate.Text,txtAddress.Text, deptComboBox.Text));



            dGVEmployeeList.Columns.Clear();
            var columns = from emp in Employeelists
                          orderby emp.firstName ascending
                          select new {
                                        EmployeeId = emp.employeeId,
                                        emp.firstName,
                                        emp.lastName,
                                        emp.birthDate,
                                        emp.address,
                                        emp.dept
                          };

            dGVEmployeeList.DataSource = columns.ToList();
            clearFields();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        private void label5_Click(object sender, EventArgs e)
        {

        }
        private void SearchButton_Click(object sender, EventArgs e)
        {
            string name = SearchTextBox.Text;

            var columns = from emp in Employeelists
                          where emp.firstName == name
                          orderby emp.firstName ascending
                          select new
                          {
                              EmployeeId = emp.employeeId,
                              emp.firstName,
                              emp.lastName,
                              emp.birthDate,
                              emp.address,
                              emp.dept
                          };

            dGVEmployeeList.Columns.Clear();
            dGVEmployeeList.DataSource = columns.ToList();

        }

        public void clearFields()
        {
            foreach(Control ctrl in this.Controls){
                if (ctrl.GetType() == typeof(TextBox))
                {
                    ctrl.Text = "";
                }
            }
        }

      
        private void dGVEmployeeList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dGVEmployeeList.Rows[e.RowIndex];
                txtId.Text = row.Cells[0].Value.ToString();
                txtFirstName.Text = row.Cells[1].Value.ToString();
                txtLastName.Text = row.Cells[2].Value.ToString();
                txtBirthDate.Text = row.Cells[3].Value.ToString();
                txtAddress.Text = row.Cells[4].Value.ToString();
                deptComboBox.Text = row.Cells[5].Value.ToString();


            }
        }

        private Employee selectEmployee(String id)
        {
          
            foreach(Employee emp in Employeelists)
            {
                if(emp.employeeId == id)
                {
                  
                    return emp;
                }

               
            }

            return null;
        }

        private void dGVEmployeeList_DoubleClick(object sender, EventArgs e)
        {
           
            String id = dGVEmployeeList.CurrentRow.Cells[0].Value.ToString();
            Employee currentEmp = selectEmployee(id);
            txtId.Text = currentEmp.employeeId;
            txtFirstName.Text = currentEmp.firstName;
            txtLastName.Text = currentEmp.lastName;
            txtBirthDate.Text = currentEmp.birthDate;
            txtAddress.Text = currentEmp.address;
            deptComboBox.Text = currentEmp.dept;


        }
    }
}
