using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hometask
{
    class DBShop
    {
        ShopModelContainer shopModelContainer;
        public DBShop()
        {
            shopModelContainer = new ShopModelContainer();
        }
        public bool IsExist()
        {
            if (shopModelContainer.Customers.Count() > 0) return true;
            else return false;
        }

        public void AddSeller(string fName, string lName)
        {
            try
            {
                shopModelContainer.Sellers.Add(new Seller { FirstName = fName, LastName = lName });
                shopModelContainer.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void AddCustomer(List<Customer> customers)
        {
            try

            {
                shopModelContainer.Customers.AddRange(customers);
                shopModelContainer.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

        public void AddDepartment(string depName, List<Product> products)
        {
            try
            {
                if (!shopModelContainer.Departments.Any(r => r.DeptName == depName))
                {
                    shopModelContainer.Departments.Add(new Department { DeptName = depName, Products = products });
                    shopModelContainer.SaveChanges();
                }
                else MessageBox.Show("This department has already been created!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void AddOrder(string CustomerLastName, string SalesmanLastName, Dictionary<string, int> dict)
        {
            try
            {
                if (shopModelContainer.Sellers.Any(r => r.LastName == SalesmanLastName) && shopModelContainer.Customers.Any(r => r.LastName == CustomerLastName))
                {

                    List<ProductCheck> productChecks = new List<ProductCheck>();
                    decimal totsum = 0;
                    foreach (var item in dict)
                    {
                        if (shopModelContainer.Products.Any(r => r.ProductName == item.Key))
                        {
                            productChecks.Add(new ProductCheck
                            {
                                Product = shopModelContainer.Products.FirstOrDefault(r => r.ProductName == item.Key),
                                Count = item.Value
                            });
                            totsum += shopModelContainer.Products.FirstOrDefault(r => r.ProductName == item.Key).Price * item.Value;
                        }
                        else
                        {
                            MessageBox.Show("This product doesn't exist!");
                            return;
                        }
                    }
                   
                    shopModelContainer.Checks.Add(new Check
                    {
                       Customer= shopModelContainer.Customers.FirstOrDefault(r => r.LastName == CustomerLastName),
                       Seller= shopModelContainer.Sellers.FirstOrDefault(r => r.LastName == SalesmanLastName),
                        SaleDate = DateTime.Now,
                        AllSumm = totsum,
                        ProductCheck=productChecks
                    });
                    shopModelContainer.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Customer or Salesman doesn't exist");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        public List<string> CustomersList()
        {
            List<string> str = new List<string>();
            foreach (var item in shopModelContainer.Customers)
            {
                str.Add(item.FirstName + " " + item.LastName);
            }

            return str.ToList();
        }

        public List<string> SalasmenList()
        {
            List<string> str = new List<string>();
            foreach (var item in shopModelContainer.Sellers)
            {
                str.Add(item.FirstName + " " + item.LastName);
            }

            return str.ToList();

        }

        public List<string> ProductsList()
        {
            return shopModelContainer.Products.Select(r => r.ProductName).ToList();
        }

        public List<string> DepartmentList()
        {
            try
            {
                return shopModelContainer.Departments.Select(r => r.DeptName).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }

        public List<string> FindProducts(int a)
        {
            if (a == 0) return ProductsList();
            return shopModelContainer.Products.Where(p=>p.Department.Id==a).Select(r=>r.ProductName).ToList();
        }

        public double FindPrice(string ProductName)
        {
            try
            {
                double pr = (double)shopModelContainer.Products.FirstOrDefault(R => R.ProductName == ProductName).Price;
                return pr;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            return 1;
    }
}
    }

