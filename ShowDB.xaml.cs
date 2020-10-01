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
    /// <summary>
    /// Логика взаимодействия для ShowDB.xaml
    /// </summary>
    public partial class ShowDB : Page
    {
        private Global global;
        List<RowTab> DATA = new List<RowTab>();
        //MainWindow mainWindow;
        public ShowDB()
        {
            InitializeComponent();
            global = Global.getInstance();
        }
        
        private void DataGridMain_Loaded(object sender, RoutedEventArgs e)
        {
            //List<RowTab> result = new List<RowTab>();
            /*
            for (int i = 0; i < 25; i++)
            {
                bool c = false;
                if (i % 2 == 0) c = true;
                result.Add(new RowTab(i + 1, c, (88345634 + i).ToString(), (float)(i + 0.5), (float)(i + 1.5), (float)(i + 2.5)));
            }
            */
            /* var cmd = global.getCmd();

             cmd.CommandText = "select * from RegistrationUsers";
             var ret = cmd.ExecuteReader();
             //textbox.Text = "";
             DATA.Clear();
             while (ret.Read())
             {
                 int id = ret.GetInt32(0);
                 String log_db = ret.GetString(1);
                 String pass_db = ret.GetString(2);
                 //textbox.Text = textbox.Text + id + " " + log_db + " " + pass_db + "\n";
                 DATA.Add(new RowTab(id, log_db, pass_db));
             }
            */

            List<Row> data = global.TestServer();

            DataGridMain.ItemsSource = data;// DATA;


        }

        private void upload_Click(object sender, RoutedEventArgs e)
        {
            //Datagrid.Items.Refresh();

            DataGridMain.ItemsSource = null;
            //DataGridMain.ItemsSource = DataGridMain.UpdateDefaultStyle();
            DataGridMain_Loaded(null,null);

        }
        private void removeButton_Click(object sender, RoutedEventArgs e)
        {
            var cmd = global.getCmd();
            
            RowTab row = (RowTab)DataGridMain.SelectedItem;
            //System.Windows.MessageBox.Show(row.Id.ToString());
            //DataGridMain.Items.RemoveAt(DataGridMain.SelectedIndex);
            cmd.CommandText = "delete from RegistrationUsers where ID = @id";
            cmd.Parameters.AddWithValue("@id", row.Id);
            cmd.ExecuteNonQuery();
            
            int idx = DataGridMain.SelectedIndex;
            this.DATA.RemoveAt(idx);
            DataGridMain.ItemsSource = null;
            DataGridMain.ItemsSource = this.DATA;
        }
        private void download_insert(object sender, RoutedEventArgs e)
        {

            string login = "Nic22";
            string pass = "MyPass";

            var cmd = global.getCmd();
            // cmd.CommandText = "insert into RegistrationUsers (Login, Password) values ('"+login+"','"+pass+"');"+
            //                    "select last_insert_rowid();" ;
            cmd.CommandText = "insert into RegistrationUsers (Login, Password) values (@login,@pass);" +
                              "select last_insert_rowid();";
            cmd.Parameters.AddWithValue("@login", login);
            cmd.Parameters.AddWithValue("@pass", pass);
            int id = Convert.ToInt32(cmd.ExecuteScalar());
            DATA.Add(new RowTab(id, login, pass));

        }
    }
}
