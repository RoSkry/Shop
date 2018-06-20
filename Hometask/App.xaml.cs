using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Hometask
{
    static class Data
    {
        public static string LastName { set; get; }
        public static string FirstName { set; get; }
    }
    static class Confirm
    {
        public static string CustomerLastName { set; get; }
        public static string CustomerFirstName { set; get; }
        public static string SalesmanLastName { set; get; }
        public static string SalesmanFirstName { set; get; }
        public static List<string> Products { set; get; } = new List<string>();
        public static List<int> Count { set; get; } = new List<int>();

    }
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
    }
}
