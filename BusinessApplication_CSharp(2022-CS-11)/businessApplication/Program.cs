using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using businessApplication.BL;
using businessApplication.DL;
using businessApplication.UI;

namespace businessApplication
{
    class Program
    {
        
       
        static void Main(string[] args)
        {
               string option = MenuUI.takeInput();
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


        
       
    }
}
