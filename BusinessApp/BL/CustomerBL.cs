using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BusinessApp.BL
{
    internal class CustomerBL:UserBL
    {
        //Attributes
        private List<ProductBL> products = new List<ProductBL>();
        private string contact;
        private string email;
        private float bill;
        public CustomerDL customerDL = new CustomerDL();

        //Constructors
        public CustomerBL(string u, string p) : base(u, p) { }
        public CustomerBL(string u, string p, string r, string ph, string e):base(u, p, r)
        {
        
            this.contact = ph;
            this.email = e;
        }

        //Methods
        public void SetContact(string contact)
        {
            this.contact = contact;
        }
        public override string GetContact()
        {
            return this.contact;
        }
        public override void SetEmail(string email)
        {
            this.email = email;
        }
        public override string GetEmail()
        {
            return this.email;
        }
        public override float GetBill()
        {
            return this.bill;
        }
        public void setBill(float bill)
        {
            this.bill = bill;
        }
        public void SetOrderList(List<ProductBL> m)
        {
            this.products = m;
        }
        public override List<ProductBL> GetProducts()
        {
            return this.products;
        }
        public override void AddProductToCart(ProductBL product)
        {
            products.Add(product);
        }
        public override void RemoveProductFromCart(ProductBL product)
        {
            products.Remove(product);
        }
        public override void ClearList(string confirm)
        {
            if (confirm != null)
            {
                if (confirm.ToLower() == "yes")
                {
                    products.Clear();
                }
            }
        }
        public override string GetUserDataString()
        {
            return $"{username},{password},{role},{contact},{email}";
        }
        public override void SaveCustomerTransactionHistoryIntoFile()
        {
            string path = "transactionhistory.txt";
            StreamWriter HistoryDataFile = new StreamWriter(path, true);
            HistoryDataFile.Write(GetUsername() + "," + GetBill() + ",");
            foreach (var item in products)
            {
                HistoryDataFile.Write(item.GetProductName() + ";" + item.GetProductQuantity() +";" + item.GetProductPrice() + ";" + item.GetProductCategory() + "!");
            }
            HistoryDataFile.WriteLine();
            HistoryDataFile.Close();
        }
        public override List<float> CalculateBill()
        {
            List<float> result = new List<float>();
            float totalAmount = 0.0F;
            float tax = 0.0F;
            foreach (var i in products)
            {
                totalAmount = totalAmount + (i.GetProductPrice() * i.GetProductQuantity());
                tax = tax + (i.getTax() * i.GetProductQuantity());
            }

            float discount = totalAmount * 0.02F;          // 2% fix discount.
            float payableAmount = (totalAmount + tax) - discount; // payable amount after discount
            result.Add(totalAmount);
            result.Add(tax);
            result.Add(discount);
            result.Add(payableAmount);
            setBill(payableAmount);
            return result;
        }


    }
}
