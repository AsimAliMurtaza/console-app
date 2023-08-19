using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessApp.BL
{
    internal class ProductBL
    {
        //Attributes
        private int productID;
        private string productName;
        private float productPrice;
        private int productQuantity;
        private string productCategory;
        private float tax;
        //Constructors
        public ProductBL()
        { }
        public ProductBL(int ID)
        {
            productID = ID;
        }
        public ProductBL(string name,int quantity, float price, string category)
        {
            this.productName = name;
            this.productQuantity = quantity;
            this.productPrice = price;
            this.productCategory = category;
        }
        public ProductBL(int ID, string n, float p, int q, string c) 
        {
            productID = ID;
            productName = n;
            productPrice = p;
            productQuantity = q;
            productCategory = c;
            if (c.ToLower()=="fruit")
            {
                this.tax = 0.4F;
            }
            else if (c.ToLower() == "vegetable")
            {
                this.tax = 0.1F;
            }
            else if (c.ToLower() == "dairy")
            {
                this.tax = 0.3F;
            }
            else if (c.ToLower() == "meat")
            {
                this.tax = 0.5F;
            }
            else if (c.ToLower() == "other")
            {
                this.tax = 0.10F;
            }
        }

        //Methods
        public string GetProductName()
        { 
            return productName;
        }
        public void SetProductName(string name)
        {
            this.productName = name;
        }
        public float GetProductPrice() 
        {  
            return productPrice; 
        }
        public void SetProductPrice(float p)
        {  
            this.productPrice = p; 
        }
        public int GetProductQuantity() 
        {  
            return productQuantity;
        }
        public void SetProductQuantity(int q)
        { 
            productQuantity = q;
        }
        public int GetProductID()
        {  
            return productID; 
        }
        public void SetProductID(int id)
        {
            this.productID = id;
        }
        public string GetProductCategory()
        {
            return productCategory; 
        }
        public float getTax()
        {
            return this.tax;
        }
        public string GetProductsDataString()
        {
            return $"{productCategory},{productName},{productQuantity},{productPrice},{productID}";
        }
        public string toString()
        {
            return "\t\t" + productID + "\t\t" + " " + productName + "\t\t" + " " + productQuantity + "\t\t\t" + " " + productPrice + "\t\t" + " " + productCategory;
        }
    }
}
