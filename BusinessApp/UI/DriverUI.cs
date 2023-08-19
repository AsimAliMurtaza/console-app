using BusinessApp.BL;
using BusinessApp.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BusinessApp.UI
{
    internal class DriverUI
    {
        public static void Header()
        {
            Console.Clear();
            Console.WriteLine("###########################################################################################################");
            Console.WriteLine("################################                                             ##############################");
            Console.WriteLine("################################  WELCOME TO THE GROCERY MANAGEMENT SYSTEM   ##############################");
            Console.WriteLine("################################                                             ##############################");
            Console.WriteLine("###########################################################################################################");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------");
        }
        

        public static void ViewFeedbacks()
        {
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\t\tFEEDBACKS!");
            foreach(string f in UserDL.getFeedback())
            {
                Console.WriteLine(f);
            }
            Console.ReadKey();
        }
        public static void ShowCheapestProduct(ProductBL p)
        {
            Console.WriteLine("\t\tPRODUCT ID \t PRODUCT NAME \t PRODUCT QUANTITY \t PRODUCT PRICE \t PRODUCT CATEGORY");
            Console.WriteLine("\t\t" + p.GetProductID() + "\t\t" + " " + p.GetProductName() + "\t\t" + " " + p.GetProductQuantity() + "\t\t\t" + " " + p.GetProductPrice() + "\t\t" + " " + p.GetProductCategory());
            Console.ReadKey();
        }
        public static void ShowProductByName(ProductBL p)
        {
            Console.WriteLine();
            Console.WriteLine("\t\tPRODUCT ID \t PRODUCT NAME \t PRODUCT QUANTITY \t PRODUCT PRICE \t PRODUCT CATEGORY");
            Console.WriteLine("\t\t" + p.GetProductID() + "\t\t" + " " + p.GetProductName() + "\t\t" + " " + p.GetProductQuantity() + "\t\t\t" + " " + p.GetProductPrice() + "\t\t" + " " + p.GetProductCategory());
            Console.ReadKey();
        }
        public static void ShowProductByCategory(List<ProductBL> list)
        {
            Console.WriteLine();
            Console.WriteLine("\t\tPRODUCT ID \t PRODUCT NAME \t PRODUCT QUANTITY \t PRODUCT PRICE \t PRODUCT CATEGORY");
            foreach (var p in list)
            {
                Console.WriteLine("\t\t" + p.GetProductID() + "\t\t" + " " + p.GetProductName() + "\t\t" + " " + p.GetProductQuantity() + "\t\t\t" + " " + p.GetProductPrice() + "\t\t" + " " + p.GetProductCategory());
            }
            Console.ReadKey();
        }
        public static int GetChoice()
        {
            string option;
            int returnOpt = 0;
            Console.WriteLine();
            Console.Write("\t\t\t\t\tENTER CHOICE: ");
            option = Console.ReadLine();

            for (int i = 0; i < option.Length; i++)
            {
                if (option[i] >= 48 && option[i] <= 57)
                {
                    returnOpt = int.Parse(option);
                }
                else
                {
                    Console.WriteLine("\t\t\t\t\tENTER A VALID CHOICE!");
                    Console.ReadKey();
                    break;
                }
            }
            return returnOpt;
        }
        public static void Menu()
        {
            Console.WriteLine("");
            Console.WriteLine("\t\t\t\t\t1. \t LOGIN TO SYSTEM.");
            Console.WriteLine("\t\t\t\t\t2. \t REGISTER INTO SYSTEM.");
            Console.WriteLine("\t\t\t\t\t3. \t VISIT AS GUEST.");
            Console.WriteLine("\t\t\t\t\t4. \t EXIT SYSTEM.");
        }
        public static void AdminMenu()
        {
            Console.WriteLine("");
            Console.WriteLine("\t\t\t\t\t1. \t ADD AN ITEM.");
            Console.WriteLine("\t\t\t\t\t2. \t DELETE AN ITEM.");
            Console.WriteLine("\t\t\t\t\t3. \t UPDATE PRICE OF AN ITEM.");
            Console.WriteLine("\t\t\t\t\t4. \t UPDATE QUANTITY OF AN ITEM.");
            Console.WriteLine("\t\t\t\t\t5. \t VIEW ALL ITEMS.");
            Console.WriteLine("\t\t\t\t\t6. \t VIEW REGISTERED CUSTOMERS.");
            Console.WriteLine("\t\t\t\t\t7. \t VIEW CUSTOMER FEEDBACK.");
            Console.WriteLine("\t\t\t\t\t8. \t VIEW PREVIOUS CUSTOMER DATA");
            Console.WriteLine("\t\t\t\t\t9. \t LOGOUT FROM SYSTEM.");
        }
        public static void CustomerMenu()
        {
            Console.WriteLine("");
            Console.WriteLine("\t\t\t\t\t1. \t VIEW ALL AVAILABLE ITEMS.");
            Console.WriteLine("\t\t\t\t\t2. \t VIEW CHEAPEST PRODUCT.");
            Console.WriteLine("\t\t\t\t\t3. \t SEARCH PRODUCT BY NAME.");
            Console.WriteLine("\t\t\t\t\t4. \t SEARCH PRODUCT BY CATEGORY.");
            Console.WriteLine("\t\t\t\t\t5. \t ADD ITEM TO CART");
            Console.WriteLine("\t\t\t\t\t6. \t VIEW CART.");
            Console.WriteLine("\t\t\t\t\t7. \t REMOVE ITEM FROM CART.");
            Console.WriteLine("\t\t\t\t\t8. \t PROCEED TO PAYMENT.");
            Console.WriteLine("\t\t\t\t\t9. \t CHANGE PASSWORD.");
            Console.WriteLine("\t\t\t\t\t10.\t UPDATE EMAIL.");
            Console.WriteLine("\t\t\t\t\t11.\t DELETE ACCOUNT.");
            Console.WriteLine("\t\t\t\t\t12.\t GIVE FEEDBACK.");
            Console.WriteLine("\t\t\t\t\t13.\t LOGOUT FROM SYSTEM.");
        }
        public static void SetConsoleColor()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
        }

        public static void ShowBill(List<ProductBL> products, List<float> bill)
        {
            Console.WriteLine("\t\t\tPRODUCT NAME \t PRODUCT QUANTITY \t PRODUCT PRICE");
            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine("\t\t\t" + products[i].GetProductName() + "\t\t" + " " + products[i].GetProductQuantity().ToString() + "\t\t\t" + " " + products[i].GetProductPrice().ToString());
            }
            Console.WriteLine();
            Console.WriteLine("\t\t\t---------------------------------------------------------------");
            Console.WriteLine("\t\t\tTOTAL AMOUNT: " + bill[0]);
            Console.WriteLine();
            Console.WriteLine("\t\t\tGST: " + bill[1]);
            Console.WriteLine();
            Console.WriteLine("\t\t\tDISCOUNT: " + bill[2]);
            Console.WriteLine();
            Console.WriteLine("\t\t\tTOTAL PAYABLE: " + bill[3]);
            Console.WriteLine();
            ShowTime();
            Console.WriteLine();
        }
        public static void ShowTime()
        {
            DateTime currentDateTime = DateTime.Now;
            string formattedDateTime = currentDateTime.ToString("dddd, dd MMMM yyyy HH:mm:ss");
            Console.WriteLine("\t\t\t" + formattedDateTime);
        }

        public static string Payment()
        {
            Console.Write("\t\t\t\t\t\tCONFIRM PAYMENT (YES/NO)?: ");
            return Console.ReadLine();
        }

        public static string UserStringInput()
        {
            Console.WriteLine();
            Console.Write("\t\t\t\t\tENTER NAME TO VIEW HISTORY: ");
            return Console.ReadLine();
        }
        public static void ViewList(List<ProductBL> products)
        {
            Console.WriteLine("\t\tPRODUCT ID \t PRODUCT NAME \t PRODUCT QUANTITY \t PRODUCT PRICE \t PRODUCT CATEGORY");
            foreach (var product in products)
            {
                Console.WriteLine(product.toString());
                
            }
            Console.ReadKey();
        }
    }
}
