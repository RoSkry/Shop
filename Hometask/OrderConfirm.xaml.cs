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
using System.Windows.Shapes;

namespace Hometask
{
    /// <summary>
    /// Interaction logic for OrderConfirm.xaml
    /// </summary>
    public partial class OrderConfirm : Window
    {
        DBShop dBShop;
        public OrderConfirm()
        {
            InitializeComponent();
            dBShop = new DBShop();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtcus.Text = Confirm.CustomerFirstName + " " + Confirm.CustomerLastName;
            txtsal.Text = Confirm.SalesmanFirstName + " " + Confirm.SalesmanLastName;
            lstprod.ItemsSource = Confirm.Products;

            foreach (var item in Confirm.Count)
            {
                lstcnt.Items.Add(item);
            }
            for (int i = 0; i < lstprod.Items.Count; i++)
            {
                lst1num.Items.Add(dBShop.FindPrice(Confirm.Products[i]));
                double pr = dBShop.FindPrice(Confirm.Products[i]) * Confirm.Count[i];
                lstpr.Items.Add(pr.ToString());
            }

            double totalsum = 0;
            for (int i = 0; i < lstpr.Items.Count; i++)
            {
                totalsum += Convert.ToDouble(lstpr.Items[i]);
            }

            txttotsum.Text = totalsum.ToString() + " грн.";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<string> products = new List<string>();
            for (int i = 0; i < lstprod.Items.Count; i++)
            {
                for (int j = 0; j < (int)lstcnt.Items[i]; j++)
                {
                    products.Add(lstprod.Items[i].ToString());

                }
            }
            string[] cust = txtcus.Text.Split(new char[] { ' ' });
            string[] salm = txtsal.Text.Split(new char[] { ' ' });

            Dictionary<string, int> dict = new Dictionary<string, int>();
            for (int i = 0; i < lstprod.Items.Count; i++)
            {
                dict.Add(lstprod.Items[i].ToString(), (int)lstcnt.Items[i]);
            }

            dBShop.AddOrder(cust[1], salm[1], dict);


            MessageBox.Show("Спасибо за покупку");
            this.Close();
            lst1num.Items.Clear();
            lstcnt.Items.Clear();
            lstpr.Items.Clear();
            lstprod.ItemsSource = null;
            Confirm.Products.Clear();
            Confirm.Count.Clear();

        }
    }
}
