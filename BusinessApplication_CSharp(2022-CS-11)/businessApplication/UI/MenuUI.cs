using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using businessApplication.BL;
using businessApplication.DL;

namespace businessApplication.UI
{
    class MenuUI
    {
       public  static string takeInput()
        {
            string option;
            MenuUI.printAdminMenu();
            option = MenuUI.menu();
            return option;
        }
        public static void adminMenu()
        {
            string option = takeInput();
            FoodDL.loadFoodMenu(FoodDL.FoodMenu);
            CustomerDL.loadCustomerData(CustomerDL.customer);
            EmployeeDL.loadEmployeeData(EmployeeDL.employee);
            do
            {
                if (option == "1")
                {
                    FoodDL.viewFoodMenu(FoodDL.FoodMenu);
                }
                else if (option == "2")
                {
                    FoodDL.addItemInMenu(FoodDL.FoodMenu);
                }
                else if (option == "3")
                {
                    FoodDL.deleteItemFromMenu(FoodDL.FoodMenu);
                }
                else if (option == "4")
                {
                    FoodDL.changeFoodItem(FoodDL.FoodMenu);
                }
                else if (option == "5")
                {
                    CustomerDL.addCustomerData(CustomerDL.customer);
                }
                else if (option == "6")
                {
                    CustomerDL.viewCustomerInformation(CustomerDL.customer);
                }
                else if (option == "7")
                {
                    CustomerDL.changeCustomerInformation(CustomerDL.customer);
                }
                else if (option == "8")
                {
                    EmployeeDL.addEmployeeInformation(EmployeeDL.employee);
                }
                else if (option == "9")
                {
                    EmployeeDL.viewEmployeeInformation(EmployeeDL.employee);
                }
                else if (option == "10")
                {
                    EmployeeDL.changeEmployeeInformation(EmployeeDL.employee);
                }
                else if (option == "11")
                {
                    break;
                }

            }
            while (option != "11");
        }
        public static void adminReturnMenu()
        {
            int choice;
            Console.WriteLine("__________________________________________________");
            Console.WriteLine("1) Return to Admin Menu ");
            Console.Write("Enter Your Choice...");
            choice = int.Parse(Console.ReadLine());
            if (choice == 1)
            {
                Console.Clear();
                adminMenu();
            }
        }
        public static string parseData(string record, int field)
        {
            int comma = 1;
            string item = "";
            for (int x = 0; x < record.Length; x++)
            {
                if (record[x] == ',')
                {
                    comma++;
                }
                else if (comma == field)
                {
                    item = item + record[x];
                }
            }
            return item;
        }
        public static string menu()
        {
            string option;
            Console.Write("Enter your Choice...");
            option = (Console.ReadLine());
            return option;
        }
        public static void printAdminMenu()
        {
            printHeader();
            Console.WriteLine(" Admin Menu            ");
            Console.WriteLine("           1) View Food Menu         ");
            Console.WriteLine("           2) Add item in Menu  ");
            Console.WriteLine("           3) Delete item from Menu  ");
            Console.WriteLine("           4) Change food item   ");
            Console.WriteLine("           5) Add Customer Information ");
            Console.WriteLine("           6) View Customer Information ");
            Console.WriteLine("           7) Change Customer Information ");
            Console.WriteLine("           8) Add Employee ");
            Console.WriteLine("           9) View Employee Information");
            Console.WriteLine("          10) Change Employee Information");
            Console.WriteLine("          11) Exit");
        }
        public static void printHeader()
        {
            Console.WriteLine("**************************************************");
            Console.WriteLine("*          RESTAURANT MANAGEMENT SYSTEM          *");
            Console.WriteLine("**************************************************");
        }
    }
}
