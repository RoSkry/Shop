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
    /// Interaction logic for AddCust.xaml
    /// </summary>
    public partial class AddCust : Window
    {
        public AddCust()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (!String.IsNullOrWhiteSpace(txtfn.Text) && !String.IsNullOrWhiteSpace(txtln.Text))
            {
                Data.FirstName = txtfn.Text;
                Data.LastName = txtln.Text;
            }
            else
            {
                MessageBox.Show("LastName or FirstName is empty");
              
            }
           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
