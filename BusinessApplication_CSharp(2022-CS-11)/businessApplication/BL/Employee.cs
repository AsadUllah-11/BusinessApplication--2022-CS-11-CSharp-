using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace businessApplication.BL
{
    class Employee
    {
        public string employeeName;
        public string employeeJoinDate;
        public string employeeSalary;
        public Employee()
        {

        }
        public Employee(string name, string date, string salary)
        {
            employeeName = name;
            employeeJoinDate = date;
            employeeSalary = salary;

        }
    }
}
