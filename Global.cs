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
        private String name = "";
        private Semaphore sem;
        SqliteConnection conn;
        /// //////////////////////////////////////////////////////////
        DBService.Client client;                                  ///
        public List<RowTab> DATA;                                 ///
        /// //////////////////////////////////////////////////////////
        public string Name
        {
            get => name;
            set
            {
                sem.WaitOne();
                name = value;
                sem.Release();
            }
        }

        private Global()
        {
            this.sem = new Semaphore(0, 1);
            this.conn = new SqliteConnection("Data Source= C:/Users/zsv/source/repos/Example-SQLite/Registration.db");
            this.conn.Open();
            ////////////////////////////////////////////////////////////////////////////////////////
            TTransport transport = new TSocket("localhost", 9090);                          ////////
            TProtocol proto = new TBinaryProtocol(transport);                               ////////
            this.client = new DBService.Client(proto);                                      ////////
            transport.Open();
            DATA = new List<RowTab>();
            ////////////////////////////////////////////////////////////////////////////////////////
        }
        /// ////////////////////////////////////////////////////////
        public List<Row> TestServer()                        ///////
        {                                                    ///////
            return (this.client.listRow());                  ///////
        }                                                    ///////
        /// ////////////////////////////////////////////////////////
        public SqliteCommand getCmd()
        {
            return this.conn.CreateCommand();
        }
        public SqliteConnection getConn()
        {
            return this.conn;
        }
        
        public void addUser(String login, String password)
        {
            String log = login;
            String pass = password;
            SqliteCommand stmt = conn.CreateCommand();
            stmt.CommandText = "INSERT INTO RegistrationUsers (Login, Password) VALUES( '"+log+"', '"+pass+"')";
            stmt.ExecuteNonQuery();
        }
        public static Global getInstance()
        {
            if (instance == null)
                instance = new Global();
            return instance;
        }
    }
}

