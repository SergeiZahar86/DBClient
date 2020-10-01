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

namespace Example_SQLite
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Sign_up : Window
    {
        private Global global;
        public Sign_up()
        {
            InitializeComponent();
            global = Global.getInstance();
        }

        private void SingUp_click(object sender, RoutedEventArgs e)
        {
            String log = this.login.Text;
            String pass = this.password.Password;
            try
            {
                global.addUser(log, pass);
                CompletionOfRegistration ok = new CompletionOfRegistration();
                ok.ShowDialog();

                this.Close();
            }
            catch (Exception p)
            {
                textbox.Text = "Invalid username or password";
            }
            
            
        }

        private void close_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
