using BusinessApp.BL;
using BusinessApp.DL;
using BusinessApp.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BusinessApp
{
    internal class UserBL
    {
        //Attributes
        protected string username;
        protected string password;
        protected string role;
        
        //Constructors
        public UserBL() { }
        public UserBL(string u, string p)
        {
            username = u;
            password = p;
        }
        public UserBL(string u, string p, string r)
        {
            username = u;
            password = p;
            role = r;
        }
        //Methods

        public string GetRole()
        {
            return role;
        }
        public void SetRole(string role)
        {
            this.role = role;
        }
        public string GetUsername()
        { return  username; }
        public void SetUsername(string name)
        {
            username = name;
        }
        public string GetPassword()
        {
            return password;
        }
        public void SetPassword(string password)
        {
            this.password = password;
        }
        public virtual string GetContact()
        {
            return "";
        }
        public virtual string GetEmail()
        {
            return "";
        }
        public virtual void SetEmail(string email)
        {

        }
        public virtual float GetBill()
        {
            return 0;
        }
        public virtual string GetUserDataString()
        {
            return "";
        }
        public virtual List<ProductBL> GetProducts()
        {
            return null;
        }
        public virtual void ClearList(string confirm)
        {

        }
        public virtual void SaveCustomerTransactionHistoryIntoFile()
        {

        }
        public virtual List<float> CalculateBill()
        {
            return null;
        }
        public virtual void AddProductToCart(ProductBL product)
        {
        }
        public virtual void RemoveProductFromCart(ProductBL product)
        {
        }
    }
}
