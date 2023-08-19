using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessApp.BL
{
    internal class ValidationsDL
    {
        public static bool checkName(string nameItem, List<ProductBL> productData)
        {
            for (int i = 0; i < productData.Count; i++)
            {
                if (nameItem == productData[i].GetProductName())
                {
                    return true;
                }
            }
            return false;
        }

        public static bool checkEmail(string emails)
        {
            bool isEmail = false;

            for (int i = 0; i < emails.Length; i++)
            {
                if (emails[i] == 64 && emails[emails.Length - 1] == 'm' && emails[emails.Length - 2] == 'o' && emails[emails.Length - 3] == 'c' && emails[emails.Length - 4] == '.')
                {
                    isEmail = true;
                    break;
                }
            }
            return isEmail;
        }

        public static int QuantityValidationCheck(string productQuantityAdmin)
        {
            int intQuantity = 0;

            if (productQuantityAdmin.All(char.IsDigit))
            {
                intQuantity = int.Parse(productQuantityAdmin);
            }
            return intQuantity;
        }
        public static float PriceValidationCheck(string productPriceAdmin)
        {
            float floatPrice = 0.0F;
            bool temp = false;

            if(productPriceAdmin.All(char.IsDigit))
            {
                floatPrice = float.Parse(productPriceAdmin);
            }
            else if (!temp)
            {
                Console.WriteLine("\t\t\t\t\t\tENTER VALID PRICE!");
                Console.ReadKey();
            }
            return floatPrice;
        }
        public static bool checkComma(string usernames)
        {
            bool temp = true;

            for (int i = 0; i < usernames.Length; i++)
            {
                if (usernames[i] == 44)
                {
                    temp = false;
                }
            }
            return temp;
        }

        public static int IDValidationCheck(string productIDAdmin)
        {
            int ID = 0;
            if (productIDAdmin.All(char.IsDigit))
            {
                ID = int.Parse(productIDAdmin);
            }
            return ID;
        }

    }
}
