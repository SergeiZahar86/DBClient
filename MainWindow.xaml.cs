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

namespace Example_SQLite
{
    public partial class MainWindow : Window
    {
        PageMain pageMain;
        public MainWindow()
        {
            InitializeComponent();
            pageMain = new PageMain();
            MainFrame.Navigate(pageMain);
        }

        private void show_list_page1_Click(object sender, RoutedEventArgs e)
        {
            pageMain = new PageMain();
            MainFrame.Navigate(pageMain);
        }
        private void signUp_window(object sender, RoutedEventArgs e)
        {
            Sign_up sign_up = new Sign_up();
            sign_up.ShowDialog();
        }
        private void signIn_window(object sender, RoutedEventArgs e)
        {
            Sing_In sing_In = new Sing_In();
            sing_In.ShowDialog();
        }

        private void showDB_Click(object sender, RoutedEventArgs e)
        {
            ShowDB showDB = new ShowDB();
            MainFrame.Navigate(showDB);
        }
    }
}
