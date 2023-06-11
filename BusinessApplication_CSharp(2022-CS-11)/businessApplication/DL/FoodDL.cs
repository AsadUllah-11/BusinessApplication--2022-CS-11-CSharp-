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
    class FoodDL
    {
        public static List<Food> FoodMenu = new List<Food>();
        public static void changeFoodItem(List<Food> FoodMenu)
        {
            Console.Clear();
            MenuUI.printHeader();
            Console.WriteLine(" Admin Menu > Change Food Item           ");
            Console.WriteLine("__________________________________________________");
            string foodname;
            Console.Write("Enter Food Name: ");
            foodname = Console.ReadLine();

            //Checking that Food Item Already Exists or Not 
            int check = 0;
            int idx = 0;
            for (int x = 0; x < FoodMenu.Count; x++)
            {
                if (foodname == FoodMenu[x].foodName)
                {
                    check++;
                    idx = x;
                    break;
                }
            }

            if (check == 1)
            {
                char yerOrNo;
                Console.Write("Are you sure you want to change the Food Item(Y/N): ");
                yerOrNo = char.Parse(Console.ReadLine());
                if (yerOrNo == 'Y')
                {
                    string newFoodName;
                    float newFoodPrice;

                    Console.Write("Enter New Name of the Food: ");
                    newFoodName = Console.ReadLine();
                    Console.Write("Enter New Price of the Food: ");
                    newFoodPrice = float.Parse(Console.ReadLine());
                    FoodMenu[idx].foodName = newFoodName;
                    FoodMenu[idx].foodPrice = newFoodPrice;

                    //Changing From File
                    string path = "E:\\second\\Object Oriented Programming\\WeekThree\\PD\\businessApplication\\foodMenu.txt";
                    if (File.Exists(path))
                    {
                        StreamWriter file = new StreamWriter(path);
                        for (int x = 0; x < FoodMenu.Count; x++)
                        {
                            file.WriteLine("{0},{1}", FoodMenu[x].foodName, FoodMenu[x].foodPrice);
                        }
                        file.Flush();
                        file.Close();
                    }

                    Console.WriteLine("Item Changed Successfully!!!");
                    MenuUI.adminReturnMenu();
                }
                else
                {
                    Console.WriteLine("Item Not Changed!!!");
                    MenuUI.adminReturnMenu();
                }

            }
            else
            {
                Console.WriteLine("Food Item Not Found!!!");
                Console.WriteLine("TRY AGAIN...");
                MenuUI.adminReturnMenu();
            }


        }
        public static void deleteItemFromMenu(List<Food> FoodMenu)
        {
            Console.Clear();
            MenuUI.printHeader();
            Console.WriteLine(" Admin Menu > Delete Item From Menu           ");
            Console.WriteLine("__________________________________________________");
            string foodname;
            Console.Write("Enter Food Name: ");
            foodname = Console.ReadLine();

            //Checking that food already exists or not
            int check = 0;
            int idx = 0;
            for (int x = 0; x < FoodMenu.Count; x++)
            {
                if (foodname == FoodMenu[x].foodName)
                {
                    check++;
                    idx = x;
                    break;
                }
            }

            if (check == 0)
            {
                Console.WriteLine("Item Not Exists!!!");
                Console.WriteLine("TRY AGIAN...");
                MenuUI.adminReturnMenu();
            }
            else
            {
                char yerOrNo;
                Console.WriteLine("Item Found Successfully!!!");
                Console.Write("Are you sure you want to delete Food Item(Y/N): ");
                yerOrNo = char.Parse(Console.ReadLine());
                if (yerOrNo == 'Y')
                {
                    FoodMenu.RemoveAt(idx);
                    //Removing From File
                    string path = "E:\\second\\Object Oriented Programming\\WeekThree\\PD\\businessApplication\\foodMenu.txt";
                    if (File.Exists(path))
                    {
                        StreamWriter file = new StreamWriter(path);
                        for (int x = 0; x < FoodMenu.Count; x++)
                        {
                            file.WriteLine("{0},{1}", FoodMenu[x].foodName, FoodMenu[x].foodPrice);
                        }
                        file.Flush();
                        file.Close();
                    }

                    Console.WriteLine("Item Removed Successfully!!!");
                    MenuUI.adminReturnMenu();
                }
                else
                {
                    MenuUI.adminReturnMenu();
                }
            }


        }
        public static void addItemInMenu(List<Food> FoodMenu)
        {
            Console.Clear();
            MenuUI.printHeader();
            Console.WriteLine(" Admin Menu > Add Item In Menu           ");
            Console.WriteLine("__________________________________________________");
            string foodname;
            float foodprice;
            Console.Write("Enter Food Name: ");
            foodname = Console.ReadLine();
            //Checking If Data Already Exists or Not
            int check = 0;
            for (int x = 0; x < FoodMenu.Count; x++)
            {
                if (foodname == FoodMenu[x].foodName)
                {
                    check++;
                    break;
                }
            }
            if (check == 1)
            {
                Console.WriteLine("Food Item Already Exist!!!");
                Console.WriteLine("TRY AGAIN!!!");
                MenuUI.adminReturnMenu();
            }
            else
            {
                Console.Write("Enter Food Price: ");
                foodprice = float.Parse(Console.ReadLine());
                //Storing the Data in the List
                Food info = new Food();
                info.foodName = foodname;
                info.foodPrice = foodprice;
                FoodMenu.Add(info);

                //Storing Food item in File
                string path = "E:\\second\\Object Oriented Programming\\WeekThree\\PD\\businessApplication\\foodMenu.txt";
                if (File.Exists(path))
                {
                    StreamWriter file = new StreamWriter(path, true);
                    file.WriteLine("{0},{1}", foodname, foodprice);
                    file.Flush();
                    file.Close();
                    Console.WriteLine("Item Added Successfully!!!");
                }


                MenuUI.adminReturnMenu();
            }
        }
        public static void viewFoodMenu(List<Food> FoodMenu)
        {
            Console.Clear();
            MenuUI.printHeader();
            Console.WriteLine(" Admin Menu > Food Menu           ");
            Console.WriteLine("__________________________________________________");
            Console.WriteLine(" Product Name           Price         ");
            Console.WriteLine("__________________________________________________");
            for (int x = 0; x < FoodMenu.Count; x++)
            {
                Console.WriteLine("{0}\t\t\tRs.{1}", FoodMenu[x].foodName, FoodMenu[x].foodPrice);
            }
            MenuUI.adminReturnMenu();
        }
        public static void loadFoodMenu(List<Food> FoodMenu)
        {
            string path = "E:\\second\\Object Oriented Programming\\WeekThree\\PD\\businessApplication\\foodMenu.txt";
            if (File.Exists(path))
            {
                StreamReader file = new StreamReader(path);
                string record;
                while ((record = file.ReadLine()) != null)
                {
                    Food info = new Food();
                    info.foodName = MenuUI.parseData(record, 1);
                    info.foodPrice = float.Parse(MenuUI.parseData(record, 2));
                    FoodMenu.Add(info);
                }
                file.Close();
            }
        }

    }
}
