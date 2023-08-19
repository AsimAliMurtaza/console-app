using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessApp.UI
{
    internal class ValidationsUI
    {
        public static void InvalidUserOrPassword ()
        {
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\t\tINCORRECT USERNAME OR PASSWORD");
            Console.ReadKey();
        }
        public static void InvalidPassword()
        {
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\t\tPASSWORD DID NOT MATCH");
            Console.ReadKey();
        }
        public static void InvalidEmail()
        {
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\t\tINVALID EMAIL ENTERED");
            Console.ReadKey();
        }
        public static void InvalidProductID()
        {
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\t\tINCORRECT PRODUCT ID ENTERED");
            Console.ReadKey();
        }
        public static void InvalidProductDetails()
        {
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\t\tINCORRECT PRODUCT DETAILS ENTERED");
            Console.ReadKey();
        }
        public static void ProductDoesNotExist()
        {
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\t\tPRODUCT DOES NOT EXIST");
            Console.ReadKey();
        }
        public static void InvalidCredentials()
        {
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\t\tINCORRECT DETAILS ENTERED");
            Console.ReadKey();
        }
    }
}
