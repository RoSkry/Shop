using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hometask
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DBShop dBShop;
        public MainWindow()
        {
            InitializeComponent();
            dBShop = new DBShop();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (!dBShop.IsExist())
            {
                dBShop.AddSeller("Cristiano", "Ronaldo");
                dBShop.AddSeller("Andrey", "Shevchenko");

                dBShop.AddCustomer(new List<Customer>
            {
                new Customer {LastName="Bale", FirstName="Gareth"},
                new Customer{LastName="Benzema",FirstName="Karim"},
                new Customer {LastName="Asensio",FirstName="Marco"},
                new Customer {LastName="Pogba",FirstName="Paul"},
                new Customer {LastName="Kylian",FirstName="Mbappe"}
            });

                dBShop.AddDepartment("MobilePhones", new List<Product> {
                new Product{ProductName="IPHONE 10",Price=20000},
                new Product{ProductName="SAMSUNG S9",Price=18000},
                new Product{ProductName="HUAWEI P20 Lite",Price=14000}
            });
                dBShop.AddDepartment("TV", new List<Product> {
                new Product{ProductName="LG 43UJ630V",Price=25000},
                new Product{ProductName="SAMSUNG UE40J5200AUXUA",Price=22000},
                new Product{ProductName="SONY KD43XE7096BR",Price=19000}
            });
                dBShop.AddDepartment("Laptops", new List<Product> {
                new Product{ProductName="LENOVO Legion Y520-15IKBN",Price=11000},
                new Product{ProductName="APPLE A1466 MacBook Air",Price=15000},
                new Product{ProductName="ASUS F541NA-GO188",Price=12000}
            });
                dBShop.AddDepartment("Friges", new List<Product> {
                new Product{ProductName="GORENJE NRK 611 PS4",Price=16000},
                new Product{ProductName="SAMSUNG RB37J5220SA",Price=12000},
                new Product{ProductName="LG GA-B499YLUZ",Price=22000}
            });
             dBShop.AddOrder("Benzema", "Shevchenko", new Dictionary<string, int>
            {
                { "IPHONE 10", 2},
                { "ASUS F541NA-GO188", 3}
            });
            }

            cmbcus.ItemsSource = dBShop.CustomersList();         
            cmbdpt.Items.Add("Все товары");
            cmbsal.ItemsSource = dBShop.SalasmenList();
           // cmbdpt.ItemsSource = dBShop.DepartmentList();
            dBShop.DepartmentList().ForEach(item=>cmbdpt.Items.Add(item));
            cmbcnt.ItemsSource = new List<int> { 1, 2, 3, 4, 5 };
            cmbdpt.SelectedIndex = 0;
            cmbprod.SelectedIndex = 0;
            cmbcnt.SelectedIndex = 0;
            cmbcus.SelectedIndex = 0;
            cmbsal.SelectedIndex = 0;
        }

        private void addcust_Click(object sender, RoutedEventArgs e)
        {
            AddCust addCust = new AddCust();
            addCust.ShowDialog();
            if (!String.IsNullOrWhiteSpace(Data.FirstName) && !String.IsNullOrWhiteSpace(Data.LastName))
            {
                dBShop.AddCustomer(new List<Customer> { new Customer { FirstName=Data.FirstName,LastName=Data.LastName} });
            }
            else MessageBox.Show("Empty");
            cmbcus.Items.Clear();
            dBShop.CustomersList().ForEach(item => cmbcus.Items.Add(item));

        }

        private void addcart_Click(object sender, RoutedEventArgs e)
        {

            if (!String.IsNullOrWhiteSpace(cmbcnt.Text) && !String.IsNullOrWhiteSpace(cmbprod.Text))
            {
                lstnam.Items.Add(cmbprod.Text);
                lstcnt.Items.Add(cmbcnt.Text);
                Confirm.Count.Add(Convert.ToInt32(cmbcnt.Text));
                cmbcnt.SelectedIndex = 0;
            }
        }

        private void cmbdpt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cmbprod.Items.Clear();
            ComboBox comboBox = sender as ComboBox;          
            dBShop.FindProducts(comboBox.SelectedIndex).ForEach(item=>cmbprod.Items.Add(item));
            cmbprod.SelectedIndex = 0;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(cmbcnt.Text) && !String.IsNullOrWhiteSpace(cmbsal.Text) && lstcnt.Items.Count > 0 && lstnam.Items.Count > 0)
            {
                string[] cust = cmbcus.Text.Split(new char[] { ' ' });
                Confirm.CustomerFirstName = cust[0];
                Confirm.CustomerLastName = cust[1];
                string[] salesm = cmbsal.Text.Split(new char[] { ' ' });
                Confirm.SalesmanFirstName = salesm[0];
                Confirm.SalesmanLastName = salesm[1];
                Confirm.Products.AddRange(lstnam.Items.OfType<string>().ToArray());


                OrderConfirm orderConfirm = new OrderConfirm();
                orderConfirm.ShowDialog();
                lstcnt.Items.Clear();
                lstnam.Items.Clear();
            }
            else MessageBox.Show("Choose products");
        }
    }
}
