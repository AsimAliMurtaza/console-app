using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BusinessApp.BL;
using BusinessApp.DL;
using BusinessApp.UI;

namespace BusinessApp
{
    internal class Program
    {
        static int choice = 0;
        static void Main(string[] args)
        {
            DriverUI.SetConsoleColor();
            ProductDL.ReadProductDataFromFile();
            UserDL.ReadUserDataFromFile();
            CustomerDL.ReadUserHistoryDataFromFile();
            UserBL returnedUser;

            while (choice != 4)
            {
                DriverUI.Header();
                DriverUI.Menu();
                choice = DriverUI.GetChoice();

                if (choice == 1)
                {
                    DriverUI.Header();
                    returnedUser = UserUI.GetSignInDetails();
                    UserBL user = UserDL.GetUserFromList(returnedUser.GetUsername(), returnedUser.GetPassword());
                    if (user != null)
                    {
                        if(user is AdminBL)
                        {
                            while (choice != 9)
                            {
                                DriverUI.Header();
                                DriverUI.AdminMenu();
                                choice = DriverUI.GetChoice();

                                if (choice == 1)
                                {
                                    DriverUI.Header();
                                    DriverUI.ViewList(ProductDL.GetProducts());
                                    ProductBL product = AdminUI.GetDetailsToAddProduct();
                                    if (product != null)
                                    {
                                        ProductDL.AddProduct(product);
                                        ProductDL.SaveProductDataIntoFile();
                                    }
                                    else
                                    {
                                        ValidationsUI.InvalidProductDetails();
                                    }
                                }
                                else if (choice == 2)
                                {
                                    DriverUI.Header();
                                    DriverUI.ViewList(ProductDL.GetProducts());

                                    ProductBL product = AdminUI.GetDetailsToDeleteProduct(ProductDL.GetProducts());
                                    if (product != null)
                                    {
                                        ProductDL.RemoveProduct(product);
                                        ProductDL.SaveProductDataIntoFile();
                                    }
                                    else
                                    {
                                        ValidationsUI.ProductDoesNotExist();
                                    }
                                }
                                else if (choice == 3)
                                {
                                    DriverUI.Header();
                                    DriverUI.ViewList(ProductDL.GetProducts());
                                    ProductBL product = AdminUI.GetDetailsToUpdateProductPrice(ProductDL.GetProducts());
                                    if(product != null)
                                    {
                                        ProductDL.UpdateProductPriceInList(product);
                                        ProductDL.SaveProductDataIntoFile();
                                    }
                                    else
                                    {
                                        ValidationsUI.InvalidProductID();
                                    }
                                }
                                else if (choice == 4)
                                {
                                    DriverUI.Header();
                                    DriverUI.ViewList(ProductDL.GetProducts());
                                    ProductBL product = AdminUI.GetDetailsToUpdateProductQuantity(ProductDL.GetProducts());
                                    if(product != null)
                                    {
                                        ProductDL.UpdateProductQuantityInList(product);
                                        ProductDL.SaveProductDataIntoFile();
                                    }
                                    else
                                    {
                                        ValidationsUI.InvalidProductID();
                                    }
                                }
                                else if (choice == 5)
                                {
                                    DriverUI.Header();
                                    DriverUI.ViewList(ProductDL.GetProducts());
                                }
                                else if (choice == 6)
                                {
                                    DriverUI.Header();
                                    UserDL.toString();
                                }
                                else if (choice == 7)
                                {
                                    DriverUI.Header();
                                    DriverUI.ViewFeedbacks();
                                }
                                else if (choice == 8)
                                {
                                    CustomerDL.ReadUserHistoryDataFromFile();
                                    DriverUI.Header();
                                    CustomerDL.viewPreviousData();
                                    string name = DriverUI.UserStringInput();
                                    CustomerBL c = CustomerDL.GetCustomer(name);
                                    if (c != null)
                                    {
                                        Console.Clear();
                                        DriverUI.ShowBill(c.GetProducts(), c.CalculateBill());
                                        Console.ReadKey();
                                    }
                                }
                            }
                        }
                        user.ClearList("yes");
                        if (user is CustomerBL)
                        {
                            while (choice != 13)
                            {
                                DriverUI.Header();
                                DriverUI.CustomerMenu();
                                choice = DriverUI.GetChoice();

                                if (choice == 1)
                                {
                                    DriverUI.Header();
                                    DriverUI.ViewList(ProductDL.GetProducts());
                                }
                                else if (choice == 2)
                                {
                                    DriverUI.Header();
                                    ProductBL prod = ProductDL.CheapestProduct();
                                    if (prod != null)
                                        DriverUI.ShowCheapestProduct(prod);
                                }
                                else if (choice == 3)
                                {
                                    DriverUI.Header();
                                    string name = CustomerUI.SearchByName();
                                    if (name != null)
                                    {
                                        ProductBL product = ProductDL.GetProductByName(name);
                                        if (product != null)
                                        {
                                            DriverUI.ShowProductByName(product);
                                        }
                                        else
                                        {
                                            ValidationsUI.ProductDoesNotExist();
                                        }
                                    }
                                    else
                                        ValidationsUI.ProductDoesNotExist();
                                }
                                else if (choice == 4)
                                {
                                    DriverUI.Header();
                                    string category = CustomerUI.SearchByCategory();
                                    if (category != null)
                                        DriverUI.ShowProductByCategory(ProductDL.GetProductByCategory(category));
                                    else
                                        ValidationsUI.ProductDoesNotExist();
                                }
                                else if (choice == 5)
                                {
                                    DriverUI.Header();
                                    DriverUI.ViewList(ProductDL.GetProducts());
                                    ProductBL product = CustomerUI.GetProductDetailsFromCustomer();
                                    if (product != null)
                                    {
                                        user.AddProductToCart(product);
                                    }
                                    else
                                    {
                                        ValidationsUI.ProductDoesNotExist();
                                    }
                                }
                                else if (choice == 6)
                                {
                                    DriverUI.Header();
                                    CustomerUI.ViewCart(user.GetProducts());
                                }
                                if (choice == 7)
                                {
                                    DriverUI.Header();
                                    CustomerUI.ViewCart(user.GetProducts());
                                    ProductBL product = CustomerUI.GetProductDetailsFromCustomerToRemoveProduct(user.GetProducts());
                                    if(product != null)
                                    {
                                        user.RemoveProductFromCart(product);
                                    }
                                    else
                                    {
                                        ValidationsUI.InvalidProductID();
                                    }
                                    
                                }
                               else if (choice == 8)
                                {
                                    DriverUI.Header();
                                    DriverUI.ShowBill(user.GetProducts(), user.CalculateBill());
                                    user.SaveCustomerTransactionHistoryIntoFile();
                                    user.ClearList(DriverUI.Payment());
                                }
                                else if (choice == 9)
                                {
                                    DriverUI.Header();
                                    CustomerUI.ShowPreviousPassword(user.GetPassword());
                                    string newPssword = CustomerUI.ChangePassword();
                                    if(newPssword != null)
                                    {
                                        user.SetPassword(newPssword);
                                        UserDL.SaveUserDataIntoFile();
                                    }
                                    else
                                    {
                                        ValidationsUI.InvalidPassword();
                                    }
                                    
                                }
                                else if (choice == 10)
                                {
                                    DriverUI.Header();
                                    CustomerUI.ShowPreviousEmail(user.GetEmail());
                                    string email = CustomerUI.ChangeEmail();
                                    if (email != null)
                                    {
                                        user.SetEmail(email);
                                        UserDL.SaveUserDataIntoFile();
                                    }
                                    else
                                    {
                                        ValidationsUI.InvalidEmail();
                                    }

                                }
                                else if (choice == 11)
                                {
                                    DriverUI.Header();
                                    UserBL deleteUser = CustomerUI.PromptToDeleteUser();
                                    UserBL Delete = UserDL.GetUserFromList(deleteUser.GetUsername(), deleteUser.GetPassword());
                                    if(Delete != null)
                                    {
                                        UserDL.RemoveUserFromList(Delete);
                                        UserDL.SaveUserDataIntoFile();
                                    }
                                    else
                                    {
                                        ValidationsUI.InvalidUserOrPassword();
                                    }
                                }
                                else if (choice == 12)
                                {
                                    DriverUI.Header();
                                    UserDL.AddFeedback(CustomerUI.GiveFeedback());
                                }
                            }
                        }
                    }
                    else
                    {
                        ValidationsUI.InvalidUserOrPassword();
                    }
                }
                else if (choice == 2)
                {
                    DriverUI.Header();
                    UserBL user = UserUI.GetSignUpDetails();
                    if (user != null)
                    {
                        UserDL.addUserToList(user);
                        UserDL.SaveUserDataIntoFile();
                    }
                    else
                    {
                        ValidationsUI.InvalidCredentials();
                    }
                }
                else if (choice == 3)
                {
                    DriverUI.Header();
                    DriverUI.ViewList(ProductDL.GetProducts());
                }
            }
        }       
    }
}