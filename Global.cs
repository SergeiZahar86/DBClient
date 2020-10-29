using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Data.SqlClient;
using Thrift.Transport;
using Thrift.Protocol;

namespace Example_SQLite
{
    class Global
    {
        private static Global instance;
        private Semaphore sem;
        TTransport transport ;
        
        /// //////////////////////////////////////////////////////////
        DBService.Client client;                                  ///
        public List<RowTab> DATA;                                 ///
        /// //////////////////////////////////////////////////////////
        

        private Global()
        {
            /*
            this.sem = new Semaphore(0, 1);
            this.conn = new SqliteConnection("Data Source= C:/Users/zsv/source/repos/Example-SQLite/Registration.db");
            this.conn.Open();
            */
            ////////////////////////////////////////////////////////////////////////////////////////
            this.transport = new TSocket("localhost", 9000); //  localhost - зарезервированное слово означающее что сервер и клиент на одной машине
                                                             // 9000 - порт, любое число до 65000
            TProtocol proto = new TBinaryProtocol(transport);                               ////////
            this.client = new DBService.Client(proto);                                      ////////
           //this.transport.Open();
            DATA = new List<RowTab>();
            ////////////////////////////////////////////////////////////////////////////////////////
        }
        /// ////////////////////////////////////////////////////////
        public List<Row> TestServer()                        ///////
        {
            List<Row> l =null;
            try
            {
                this.transport.Open();
                this.client.addUser("login", "password");
                l = this.client.listRow();
            } catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
            finally
            {
                this.transport.Close();
            }
                // this.transport.Close();
            return (l);                  ///////
        
        }    
        public SqliteCommand getCmd()
        {
            return null;
        }
        public SqliteConnection getConn()
        {
            return null;
        }
        
        public void addUser(String login, String password)
        {
           /* String log = login;
            String pass = password;
            SqliteCommand stmt = conn.CreateCommand();
            stmt.CommandText = "INSERT INTO RegistrationUsers (Login, Password) VALUES( '"+log+"', '"+pass+"')";
            stmt.ExecuteNonQuery();*/
        }
        public static Global getInstance()
        {
            if (instance == null)
                instance = new Global();
            return instance;
        }
    }
}

