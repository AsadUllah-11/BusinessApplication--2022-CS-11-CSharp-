using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using businessApplication.BL;
using businessApplication.DL;
using businessApplication.UI;
using System.IO;


namespace businessApplication.DL
{
    class EmployeeDL
    {
        public static List<Employee> employee = new List<Employee>();

        public static void changeEmployeeInformation(List<Employee> employee)
        {
            Console.Clear();
            MenuUI.printHeader();
            Console.WriteLine(" Admin Menu > Change Employee Information           ");
            Console.WriteLine("__________________________________________________");
            string emplName;
            Console.Write("Enter Employee Name: ");
            emplName = Console.ReadLine();

            //Checking that Customer Already Exists or Not 
            int check = 0;
            int idx = 0;
            for (int x = 0; x < employee.Count; x++)
            {
                if (emplName == employee[x].employeeName)
                {
                    check++;
                    idx = x;
                    break;
                }
            }

            if (check == 1)
            {
                char yerOrNo;
                Console.Write("Are you sure you want to change the Employee Information(Y/N): ");
                yerOrNo = char.Parse(Console.ReadLine());
                if (yerOrNo == 'Y')
                {
                    string newEmplName;
                    string newEmplDate;
                    string newEmplSalary;
                    Console.Write("Enter New Name of the Employee: ");
                    newEmplName = Console.ReadLine();
                    Console.Write("Enter New Join Date of the Employee: ");
                    newEmplDate = Console.ReadLine();
                    Console.Write("Enter New Salary of the Employee: ");
                    newEmplSalary = Console.ReadLine();
                    employee[idx].employeeName = newEmplName;
                    employee[idx].employeeJoinDate = newEmplDate;
                    employee[idx].employeeSalary = newEmplSalary;

                    //Changing From File
                    string path = "E:\\second\\Object Oriented Programming\\WeekThree\\PD\\businessApplication\\employeeData.txt";
                    if (File.Exists(path))
                    {
                        StreamWriter file = new StreamWriter(path);
                        for (int x = 0; x < employee.Count; x++)
                        {
                            file.WriteLine("{0},{1},{2}", employee[x].employeeName, employee[x].employeeJoinDate, employee[x].employeeSalary);
                        }
                        file.Flush();
                        file.Close();
                    }
                    loadEmployeeData(employee);
                    Console.WriteLine("Employee Changed Successfully!!!");
                    MenuUI.adminReturnMenu();
                }
            }
            else if (check == 0)
            {
                Console.WriteLine("Employee Not Found!!!");
                Console.WriteLine("TRY AGAIN...");
                MenuUI.adminReturnMenu();
            }

        }

        public static void loadEmployeeData(List<Employee> employee)
        {
            string path = "E:\\second\\Object Oriented Programming\\WeekThree\\PD\\businessApplication\\employeeData.txt";
            if (File.Exists(path))
            {
                StreamReader file = new StreamReader(path);
                string record;
                while ((record = file.ReadLine()) != null)
                {
                    Employee info = new Employee();
                    info.employeeName = MenuUI.parseData(record, 1);
                    info.employeeJoinDate = MenuUI.parseData(record, 2);
                    info.employeeSalary = MenuUI.parseData(record, 3);
                    employee.Add(info);
                }
                file.Close();

            }
        }
        public static void viewEmployeeInformation(List<Employee> employee)
        {
            Console.Clear();
            MenuUI.printHeader();
            Console.WriteLine(" Admin Menu > View Employee Information           ");
            Console.WriteLine("__________________________________________________");
            Console.WriteLine("Employee Name           Join Date           Salary");
            Console.WriteLine("__________________________________________________");
            for (int x = 0; x < employee.Count; x++)
            {
                Console.WriteLine("{0}\t\t\t{1}\t  Rs.{2}", employee[x].employeeName, employee[x].employeeJoinDate, employee[x].employeeSalary);
            }
            MenuUI.adminReturnMenu();

        }
        public static void addEmployeeInformation(List<Employee> employee)
        {
            Console.Clear();
            MenuUI.printHeader();
            Console.WriteLine(" Admin Menu > Add Employee Information           ");
            Console.WriteLine("__________________________________________________");
            string emplName;
            string emplDate;
            string emplSalary;
            Console.Write("Enter Employee Name: ");
            emplName = Console.ReadLine();

            //Checking if Customer Already Exist or Not
            int check = 0;
            for (int x = 0; x < employee.Count; x++)
            {
                if (employee[x].employeeName == emplName)
                {
                    check++;
                    break;
                }
            }
            if (check == 1)
            {
                Console.WriteLine("Employee Already Exist!!!");
                Console.WriteLine("TRY AGAIN!!!");
                MenuUI.adminReturnMenu();
            }
            else
            {
                Console.Write("Enter Employee Join Date: ");
                emplDate = Console.ReadLine();
                Console.Write("Enter Employee Salary: ");
                emplSalary = Console.ReadLine();
                Employee info = new Employee();
                info.employeeName = emplName;
                info.employeeJoinDate = emplDate;
                info.employeeSalary = emplSalary;
                employee.Add(info);

                //Storing Data in the File
                string path = "E:\\second\\Object Oriented Programming\\WeekThree\\PD\\businessApplication\\employeeData.txt";
                if (File.Exists(path))
                {
                    StreamWriter file = new StreamWriter(path, true);
                    file.WriteLine("{0},{1},{2}", emplName, emplDate, emplSalary);
                    file.Flush();
                    file.Close();
                    Console.WriteLine("Employee Added Successfully!!!");
                }

                MenuUI.adminReturnMenu();


            }


        }

    }
}
