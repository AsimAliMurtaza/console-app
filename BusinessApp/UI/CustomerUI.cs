using BusinessApp.BL;
using BusinessApp.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;

namespace BusinessApp.UI
{
    internal class CustomerUI
    {
        public static ProductBL GetProductDetailsFromCustomer()
        {

            string productName;
            string productQuantity;
            Console.WriteLine();
            Console.Write("\t\t\t\t\t\tENTER PRODUCT NAME: ");
            productName = Console.ReadLine();
            productName = productName.ToLower();
            Console.WriteLine();
            Console.Write("\t\t\t\t\t\tENTER PRODUCT QUANTITY: ");
            productQuantity = Console.ReadLine();

            bool isNameValid = ValidationsDL.checkName(productName, ProductDL.GetProducts());
            int productQuantityInt = ValidationsDL.QuantityValidationCheck(productQuantity);
            if (isNameValid)
            {
                if (productQuantityInt >= 0)
                {
                    ProductBL prod = ProductDL.returnProduct(productName, productQuantityInt);
                    return prod;
                }
            }

            return null;

        }
        public static void ShowCustomerNameForBillHistory(CustomerBL user)
        {
            Console.WriteLine("\t\t\t\t\t\t" + user.GetUsername() + "\t" + user.GetBill());
        }

        public static ProductBL GetProductDetailsFromCustomerToRemoveProduct(List<ProductBL> products)
        {
            Console.WriteLine();
            Console.Write("\t\t\t\t\t\tENTER PRODUCT ID: ");
            int index = int.Parse(Console.ReadLine());

            foreach (var product in products)
            {
                if (product.GetProductID() == index)
                {
                    return product;
                }
            }
            return null;
        }
        public static string ChangePassword()
        {
            Console.WriteLine();
            Console.Write("\t\t\t\t\t\tENTER NEW PASSWORD: ");
            string newPassword = Console.ReadLine();
            Console.WriteLine();
            Console.Write("\t\t\t\t\t\tRE-ENTER NEW PASSWORD: ");
            string newPasswordConfirm = Console.ReadLine();
            if (newPasswordConfirm == newPassword)
            { return newPassword; }
            return null;
        }
        public static string ChangeEmail()
        {
            Console.WriteLine();
            Console.Write("\t\t\t\t\t\tENTER NEW EMAIL: ");
            string email = Console.ReadLine();
            if (ValidationsDL.checkEmail(email))
            { return email; }
            return null;
        }
        public static UserBL PromptToDeleteUser()
        {
            Console.WriteLine();
            Console.Write("\t\t\t\t\t\tENTER USERNAME: ");
            string username = Console.ReadLine();
            Console.WriteLine();
            Console.Write("\t\t\t\t\t\tENTER PASSWORD: ");
            string password = Console.ReadLine();
            Console.WriteLine();
            Console.Write("\t\t\t\t\t\tRE-NETER PASSWORD TO CONFIRM: ");
            string passwordTwo = Console.ReadLine();
            if (passwordTwo == password)
            {
                Console.WriteLine();
                Console.WriteLine("\t\t\t\t\t\tDELETE ACOOUNT PERMANENTLY?");
                Console.WriteLine("\t\t\t\t\t\tTHIS ACTION CANNOT BE UNDONE!.");
                Console.WriteLine("\t\t\t\t\t\tTYPE YES OR NO TO CONTINUE...");
                string yesOrNo = Console.ReadLine().ToLower();
                if (yesOrNo == "yes")
                {
                    UserBL user = new UserBL(username, password);
                    return user;
                }
            }
            return null;
        }
        public static string GiveFeedback()
        {
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\t\tGIVE FEEDBACK");
            return Console.ReadLine();
        }
        public static void ViewCart(List<ProductBL> products)
        {
            Console.WriteLine("\t\t\t\t\t\t  CART");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------");
            Console.WriteLine("\t\t\t\t PRODUCT ID \t PRODUCT NAME \t PRODUCT QUANTITY");
            foreach (var i in products)
            {
                Console.WriteLine("\t\t\t\t " + i.GetProductID() + "\t\t " + i.GetProductName() + "\t\t " + i.GetProductQuantity());
            }
            Console.ReadKey();
        }
        public static void ShowPreviousPassword(string password)
        {
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\t\tPREVIOUS PASSWORD: " + password);
        }
        public static void ShowPreviousEmail(string email)
        {
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\t\tPREVIOUS EMAIL: " + email);
        }
        public static string SearchByName()
        {
            Console.WriteLine();
            Console.Write("\t\t\t\t\t\tENTER PRODUCT NAME: ");
            string name = Console.ReadLine();
            if (name != null)
            { return name.ToLower(); }
            return null;
        }
        public static string SearchByCategory()
        {
            Console.WriteLine();
            Console.Write("\t\t\t\t\t\tENTER PRODUCT CATEGORY: ");
            string category = Console.ReadLine();
            if (category != null)
            { return category.ToLower(); }
            return null;
        }
    }
}
