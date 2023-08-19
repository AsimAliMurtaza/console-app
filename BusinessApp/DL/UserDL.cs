using BusinessApp.BL;
using BusinessApp.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace BusinessApp.DL
{
    internal class UserDL
    {
        //Attributes
        private static List<UserBL> userData = new List<UserBL>();
        private static List<string> Feedback = new List<string>();

        //Methods
        public static List<UserBL> getList()
        {
            return userData;
        }
        public static UserBL GetUserFromList(string u, string p)
        {
            foreach (var user in userData)
            {
                if (u == user.GetUsername() && p == user.GetPassword())
                {
                    return user;
                }
            }
            return null;
        }
        public static void addUserToList(UserBL user)
        {
            userData.Add(user);
        }
        public static void RemoveUserFromList(UserBL user)
        {
            if (user != null)
            {
                userData.Remove(user);
            }
        }
        public static void AddFeedback(string feedback)
        {
            Feedback.Add(feedback);
        }
        public static List<string> getFeedback()
        {
            return Feedback;
        }
        public static void changePasswordOfCustomer(string password)
        {
            if(password != null)
            {
                foreach (var user in userData)
                {
                    if (user.GetRole() == "customer" || user.GetRole() == "Customer")
                    {
                        {
                            user.SetPassword(password);
                        }
                    }
                }
            }
        }
        public static void changeEmailOfCustomer(string email)
        {
            if (email != null)
            {
                foreach (var user in userData)
                {
                    if (user is CustomerBL)
                    {
                        {
                            user.SetEmail(email);
                        }
                    }
                }
            }
        }
        public static void SaveUserDataIntoFile()
        {
            string path = "userData.txt";
            StreamWriter userDataFile = new StreamWriter(path);
            foreach (var user in userData)
            {
                userDataFile.WriteLine(user.GetUserDataString());
                userDataFile.Flush();

            }
            userDataFile.Close();
        }
        public static void ReadUserDataFromFile()
        {
            string path = "userData.txt";

            if (File.Exists(path))
            {
                StreamReader userDataFile = new StreamReader(path);
                string line;

                while ((line = userDataFile.ReadLine()) != null)
                {
                    string[] userDataArray = line.Split(',');

                    if (userDataArray.Length >= 3)
                    {
                        string name = userDataArray[0];
                        string psswrd = userDataArray[1];
                        string role = userDataArray[2];
                        if (role.Equals("Admin", StringComparison.OrdinalIgnoreCase))
                        {
                            AdminBL admin = new AdminBL(userDataArray[0], userDataArray[1], userDataArray[2]);
                            userData.Add(admin);
                        }
                        else if (role.Equals("Customer", StringComparison.OrdinalIgnoreCase))
                        {
                            CustomerBL customer = new CustomerBL(userDataArray[0], userDataArray[1], userDataArray[2], userDataArray[3], userDataArray[4]);
                            CustomerBL c = CustomerDL.GetCustomer(name);
                            if (c != null)
                            {
                                customer.setBill(c.GetBill());
                                customer.SetOrderList(c.GetProducts());
                            }
                            userData.Add(customer);
                        }
                    }
                }
                userDataFile.Close();
            }
        }
        public static void toString()
        {
            int count = 0;
            foreach (var item in userData)
            {
                if(item.GetRole().Equals("Customer", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("\t\t\t\t\t\tUSERNAME: {0}", item.GetUsername());
                    Console.WriteLine("\t\t\t\t\t\tROLE: {0}", item.GetRole());
                    Console.WriteLine();
                    count++;
                }
            }
            Console.WriteLine("\t\t\t\t\t\tTOTAL USERS REGISTERED: {0} ", count);
            Console.ReadKey();
        }
    }
}
