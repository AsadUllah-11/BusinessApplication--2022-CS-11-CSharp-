using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using businessApplication.BL;
using businessApplication.UI;
using System.IO;

namespace businessApplication.DL
{
    class CustomerDL
    {
        public static List<Customer> customer = new List<Customer>();
        public static void changeCustomerInformation(List<Customer> customer)
        {
            Console.Clear();
            MenuUI.printHeader();
            Console.WriteLine(" Admin Menu > Change Customer Information           ");
            Console.WriteLine("__________________________________________________");
            string custName;
            Console.Write("Enter Customer Name: ");
            custName = Console.ReadLine();

            //Checking that Customer Already Exists or Not 
            int check = 0;
            int idx = 0;
            for (int x = 0; x < customer.Count; x++)
            {
                if (custName == customer[x].customerName)
                {
                    check++;
                    idx = x;
                    break;
                }
            }

            if (check == 1)
            {
                char yerOrNo;
                Console.Write("Are you sure you want to change the Customer Information(Y/N): ");
                yerOrNo = char.Parse(Console.ReadLine());
                if (yerOrNo == 'Y')
                {
                    string newCustName;
                    string newCustDate;

                    Console.Write("Enter New Name of the Customer: ");
                    newCustName = Console.ReadLine();
                    Console.Write("Enter New Date of the Customer: ");
                    newCustDate = Console.ReadLine();
                    customer[idx].customerName = newCustName;
                    customer[idx].customerDate = newCustDate;

                    //Changing From File
                    string path = "E:\\second\\Object Oriented Programming\\WeekThree\\PD\\businessApplication\\customerData.txt";
                    if (File.Exists(path))
                    {
                        StreamWriter file = new StreamWriter(path);
                        for (int x = 0; x < customer.Count; x++)
                        {
                            file.WriteLine("{0},{1}", customer[x].customerName, customer[x].customerDate);
                        }
                        file.Flush();
                        file.Close();
                    }
                    loadCustomerData(customer);
                    Console.WriteLine("Customer Changed Successfully!!!");
                    MenuUI.adminReturnMenu();
                }
            }
            else if (check == 0)
            {
                Console.WriteLine("Customer Not Found!!!");
                Console.WriteLine("TRY AGAIN...");
                MenuUI.adminReturnMenu();
            }

        }
        public static void addCustomerData(List<Customer> customer)
        {
            Console.Clear();
            MenuUI.printHeader();
            Console.WriteLine(" Admin Menu > Add Customer Information           ");
            Console.WriteLine("__________________________________________________");
            string custName;
            string custDate;
            Console.Write("Enter Customer Name: ");
            custName = Console.ReadLine();

            //Checking if Customer Already Exist or Not
            int check = 0;
            for (int x = 0; x < customer.Count; x++)
            {
                if (customer[x].customerName == custName)
                {
                    check++;
                    break;
                }
            }
            if (check == 1)
            {
                Console.WriteLine("Customer Already Exist!!!");
                Console.WriteLine("TRY AGAIN!!!");
                MenuUI.adminReturnMenu();
            }
            else
            {
                Console.Write("Enter Customer Visit Date: ");
                custDate = Console.ReadLine();
                Customer info = new Customer();
                info.customerName = custName;
                info.customerDate = custDate;
                customer.Add(info);

                //Storing Data in the File
                string path = "E:\\second\\Object Oriented Programming\\WeekThree\\PD\\businessApplication\\customerData.txt";
                if (File.Exists(path))
                {
                    StreamWriter file = new StreamWriter(path, true);
                    file.WriteLine("{0},{1}", custName, custDate);
                    file.Flush();
                    file.Close();
                    Console.WriteLine("Customer Added Successfully!!!");
                }


                MenuUI.adminReturnMenu();


            }


        }
        public static void viewCustomerInformation(List<Customer> customer)
        {
            Console.Clear();
            MenuUI.printHeader();
            Console.WriteLine(" Admin Menu > View Customer Information           ");
            Console.WriteLine("__________________________________________________");
            Console.WriteLine(" Customer Name           Visit Date         ");
            Console.WriteLine("__________________________________________________");
            for (int x = 0; x < customer.Count; x++)
            {
                Console.WriteLine("{0}\t\t\t{1}", customer[x].customerName, customer[x].customerDate);
            }
            MenuUI.adminReturnMenu();
        }
        public static void loadCustomerData(List<Customer> customer)
        {
            string path = "E:\\second\\Object Oriented Programming\\WeekThree\\PD\\businessApplication\\customerData.txt";
            if (File.Exists(path))
            {
                StreamReader file = new StreamReader(path);
                string record;
                while ((record = file.ReadLine()) != null)
                {
                    Customer info = new Customer();
                    info.customerName = MenuUI.parseData(record, 1);
                    info.customerDate = MenuUI.parseData(record, 2);
                    customer.Add(info);
                }
                file.Close();

            }
        }

    }
}
