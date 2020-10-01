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
    
    public partial class Sing_In : Window
    {
        PageMain page1;
        private Global global;
        public Sing_In()
        {
            InitializeComponent();
            global = Global.getInstance();
        }
        private void SignIn(object sender, RoutedEventArgs e)
        {
            String log = this.login.Text;
            String pass = this.password.Password;
            var cmd = global.getCmd();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            cmd.CommandText = "select * from RegistrationUsers";
            var ret = cmd.ExecuteReader();
            textbox.Text = "";
            while (ret.Read())
               {
                int id = ret.GetInt32(0);
                String log_db = ret.GetString(1);
                String pass_db = ret.GetString(2);
                //textbox.Text = textbox.Text + id + " " + log_db + " " + pass_db + "\n";
                if(log == log_db & pass == pass_db)
                {
                    this.Close();
                }
                else
                {
                    textbox.Text = "Login or password is entered incorrectly";
                }
             }
            
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
