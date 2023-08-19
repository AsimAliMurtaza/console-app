using BusinessApp.BL;
using BusinessApp.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessApp.UI
{
    internal class UserUI
    {
        public static UserBL GetSignUpDetails()
        {
            Console.WriteLine("");
            Console.Write("\t\t\t\t\t\tENTER USERNAME: ");
            string usernames = Console.ReadLine();
            bool isValid = ValidationsDL.checkComma(usernames);
            if (isValid)
            {
                Console.WriteLine("");
                Console.Write("\t\t\t\t\t\tENTER PASSWORD: ");
                string passwords = Console.ReadLine();
                isValid = ValidationsDL.checkComma(passwords);
                if (isValid)
                {
                    Console.WriteLine("");
                    Console.Write("\t\t\t\t\t\tENTER ROLE: ");
                    string roles = Console.ReadLine().ToLower();
                    Console.WriteLine();
                    isValid = roles.All(char.IsLetter);
                    if (isValid)
                    {
                        if (roles.Equals("Customer", StringComparison.OrdinalIgnoreCase))
                        {
                            Console.Write("\t\t\t\t\t\tENTER PHONE NUMBER: ");
                            string contact = Console.ReadLine();
                            Console.WriteLine("");
                            Console.Write("\t\t\t\t\t\tENTER EMAIL: ");
                            string email = Console.ReadLine();
                            isValid = ValidationsDL.checkEmail(email);
                            if (isValid)
                            {
                                UserBL c = new CustomerBL(usernames, passwords, roles, contact, email);
                                Console.WriteLine("\t\t\t\t\t\tSIGNED UP SUCCESSFULLY!");
                                Console.ReadKey();
                                return c;
                            }
                        }
                    }
                    else
                    {
                        UserBL a = new AdminBL(usernames, passwords, roles);
                        Console.WriteLine("\t\t\t\t\t\tSIGNED UP SUCCESSFULLY!");
                        Console.ReadKey();
                        return a;
                    }
                }
            }
            return null;
        }


        public static UserBL GetSignInDetails()
        {
            string username;
            string password;

            Console.WriteLine("");
            Console.Write("\t\t\t\t\t\tENTER USERNAME: ");
            username = Console.ReadLine();
            Console.WriteLine("");
            Console.Write("\t\t\t\t\t\tENTER PASSWORD: ");
            password = Console.ReadLine();

            UserBL signInData = new UserBL(username, password);
            return signInData;
        }
    }
}
