using BusinessApp.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BusinessApp.BL
{
    internal class CustomerDL
    {
        //Attributes
        public static List<CustomerBL> list = new List<CustomerBL>();

        //Methods
        public static CustomerBL GetCustomer(string name)
        {
            foreach(var i in list)
            {
                if(i.GetUsername()==name)
                {
                    return i;
                }
            }
            return null;
        }
        public static void viewPreviousData()
        {
            foreach (var user in list)
            {
                if (user != null)
                {
                    CustomerUI.ShowCustomerNameForBillHistory(user);
                }

            }
        }
        public static void ReadUserHistoryDataFromFile()
        {
            string path = "transactionhistory.txt";
            list.Clear();
            if (File.Exists(path))
            {
                StreamReader userDataFile = new StreamReader(path);
                string line;

                while ((line = userDataFile.ReadLine()) != null)
                {
                    string[] userDataArray = line.Split(',');
                    string name = userDataArray[0];
                    float bill = float.Parse(userDataArray[1]);
                    string[] productData = userDataArray[2].Split('!');
                    CustomerBL c = new CustomerBL(name, "");
                    c.setBill(bill);

                    for (int i = 0; i < productData.Length - 1; i++)
                    {
                        string[] data = productData[i].Split(';');
                        string dish = data[0];
                        int quan = int.Parse(data[1]);
                        float price = float.Parse(data[2]);
                        string category = data[3];
                        ProductBL p = new ProductBL(0, name, price, quan, category);
                        if (p != null)
                        {
                            c.AddProductToCart(p);
                        }
                        list.Add(c);
                    }
                }
                userDataFile.Close();
            }
        }
    }
}
