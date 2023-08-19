using BusinessApp.BL;
using BusinessApp.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessApp.UI
{
    internal class AdminUI
    {
        public static ProductBL GetDetailsToAddProduct()
        {
            Console.WriteLine();
            Console.Write("\t\t\t\t\t\tENTER PRODUCT ID: ");
            string productIDAdmin = Console.ReadLine();
            Console.WriteLine();
            Console.Write("\t\t\t\t\t\tENTER PRODUCT NAME: ");
            string productName = Console.ReadLine();
            Console.WriteLine();
            Console.Write("\t\t\t\t\t\tENTER PRODUCT QUANTITY: ");
            string productQuantityAdmin = Console.ReadLine();
            Console.WriteLine();
            Console.Write("\t\t\t\t\t\tENTER PRODUCT PRICE: ");
            string productPriceAdmin = Console.ReadLine();
            Console.WriteLine();
            Console.Write("\t\t\t\t\t\tENTER PRODUCT CATEGORY: ");
            string productCategoryAdmin = Console.ReadLine();
            Console.WriteLine();
            ProductBL product = new ProductBL(ValidationsDL.IDValidationCheck(productIDAdmin), productName, ValidationsDL.PriceValidationCheck(productPriceAdmin), ValidationsDL.QuantityValidationCheck(productQuantityAdmin),productCategoryAdmin);
            if (product.GetProductID() != 0 && product.GetProductQuantity() != 0 && product.GetProductPrice() != 0 && product.GetProductCategory() != null)
            {
                Console.Write("\t\t\t\t\t\tPRODUCT ADDED SUCCESSFULLY!");
                Console.ReadKey();
                return product;
            }
            return null;
        }
        public static ProductBL GetDetailsToDeleteProduct(List<ProductBL> products)
        {
            Console.WriteLine();
            Console.Write("\t\t\t\t\t\tENTER PRODUCT ID: ");
            int productID = int.Parse(Console.ReadLine());

            foreach(var i in products)
            {
                if(productID==i.GetProductID())
                {
                    return i;
                }
            }
            return null;
        }
        public static ProductBL GetDetailsToUpdateProductQuantity(List<ProductBL> products)
        {
            ProductBL product = new ProductBL();
            Console.WriteLine();
            Console.Write("\t\t\t\t\t\tENTER PRODUCT ID: ");
            int productID = ValidationsDL.IDValidationCheck(Console.ReadLine());
            Console.WriteLine();

            if(productID>0 && ProductDL.isProductExist(productID))
            {
                for (int i = 0; i < products.Count; i++)
                {
                    if (productID == products[i].GetProductID())
                    {
                        product = products[i];
                        Console.WriteLine("\t\t\t\t\t\tPRODUCT NAME: {0}", products[i].GetProductName());
                        Console.WriteLine();
                        Console.WriteLine("\t\t\t\t\t\tPREVIOUS QUANTITY: {0}", products[i].GetProductQuantity());
                        Console.WriteLine();
                    }
                }

                Console.Write("\t\t\t\t\t\tENTER NEW QUANTITY: ");
                int productQuantity = int.Parse(Console.ReadLine());
                product.SetProductQuantity(productQuantity);
                return product;
            }
            return null;
        }
        public static ProductBL GetDetailsToUpdateProductPrice(List<ProductBL> products)
        {
            ProductBL product = new ProductBL();
            Console.WriteLine();
            Console.Write("\t\t\t\t\t\tENTER PRODUCT ID: ");
            int productID = ValidationsDL.IDValidationCheck(Console.ReadLine());

            if (productID > 0 && ProductDL.isProductExist(productID))
            {
                for (int i = 0; i < products.Count; i++)
                {
                    if (productID == products[i].GetProductID())
                    {
                        product = products[i];
                        Console.WriteLine();
                        Console.WriteLine("\t\t\t\t\t\tPRODUCT NAME: {0}", products[i].GetProductName());
                        Console.WriteLine();
                        Console.WriteLine("\t\t\t\t\t\tPREVIOUS PRICE: {0}", products[i].GetProductPrice());
                        Console.WriteLine();
                    }
                }
                Console.Write("\t\t\t\t\t\tENTER NEW PRICE: ");
                float productPrice = float.Parse(Console.ReadLine());
                product.SetProductPrice(productPrice);
                return product;
            }
            return null;
        }
    }
}
