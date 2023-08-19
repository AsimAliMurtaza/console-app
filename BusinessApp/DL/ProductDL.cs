using BusinessApp.DL;
using BusinessApp.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessApp.BL
{
    internal class ProductDL
    {
        //Attributes
        private static List<ProductBL> products = new List<ProductBL>();

        //Methods
        public static List<ProductBL> GetProducts()
        {
            return products;
        }
        public static void AddProduct(ProductBL p)
        {
            if(p.GetProductQuantity() > 0 && p.GetProductPrice() >0)
            {
                products.Add(p);
            }
        }
        public static void RemoveProduct(ProductBL p)
        {
            products.Remove(p);
        }
        public static void UpdateProductPriceInList(ProductBL product)
        {
            foreach (ProductBL p in products)
            {
                if (p.GetProductID() == product.GetProductID())
                {
                    p.SetProductPrice(product.GetProductPrice());
                }
            }
        }
        public static void UpdateProductQuantityInList(ProductBL product)
        {
            foreach (ProductBL p in products)
            {
                if (p.GetProductID() == product.GetProductID())
                {
                    p.SetProductQuantity(product.GetProductQuantity());
                }
            }
        }
        public static bool isProductExist(int id)
        {
            foreach(ProductBL p in products)
            {
                if(id == p.GetProductID())
                {
                    return true;
                }
            }
            return false;
        }
        public static ProductBL GetProductByName(string name)
        {
            foreach (ProductBL p in products)
            {
                if (name.ToLower() == p.GetProductName())
                {
                    return p;
                }
            }
            return null;
        }
        public static List<ProductBL> GetProductByCategory(string category)
        {
            List<ProductBL> categoryList = new List<ProductBL>(); ;
            foreach (ProductBL p in products)
            {
                if (category == p.GetProductCategory())
                {
                    categoryList.Add(p);
                }
            }
            return categoryList;
        }
        public static ProductBL CheapestProduct()
        {
            if (products.Count > 0)
            {
                ProductBL cheapestItem = products[0];
                foreach (var p in products)
                {
                    if (p.GetProductPrice() < cheapestItem.GetProductPrice())
                    {
                        cheapestItem = p;
                    }
                }
                return cheapestItem;
            }
            return null;
        }
        public static ProductBL returnProduct(string productName, int quantity)
        {
            foreach (var i in products)
            {
                if (productName == i.GetProductName())
                {
                    int finalQuantity = i.GetProductQuantity() - quantity;
                    if (finalQuantity >= 0)
                    {
                        i.SetProductQuantity(finalQuantity);
                        ProductBL product = new ProductBL(i.GetProductID(), productName, i.GetProductPrice(), quantity, i.GetProductCategory());
                        return product;
                    }
                }
            }
            return null;
        }
        public static void SaveProductDataIntoFile()
        {
            string path = "productsData.txt";
            StreamWriter productsDataFile = new StreamWriter(path);
            foreach (ProductBL p in products)
            {
                productsDataFile.WriteLine(p.GetProductsDataString());
                productsDataFile.Flush();
            }
            productsDataFile.Close();
        }
        public static void ReadProductDataFromFile()
        {
            string path = "productsData.txt";

            if (File.Exists(path))
            {
                StreamReader productsDataFile = new StreamReader(path);
                string line;

                while ((line = productsDataFile.ReadLine()) != null)
                {
                    string[] productDataArray = line.Split(',');

                    if (productDataArray.Length >= 5)
                    {
                        string productCategory = productDataArray[0];
                        ProductBL product = new ProductBL(int.Parse(productDataArray[4]), productDataArray[1], float.Parse(productDataArray[2]), int.Parse(productDataArray[3]), productDataArray[0]);
                        products.Add(product);
                    }
                }
                productsDataFile.Close();
            }
        }
    }
}
