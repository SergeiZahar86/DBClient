using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_SQLite
{
    class RowTab
    {
        public RowTab(int Id, bool isOk, String VagNum, float Tara, float TaraNSI, float TaraDelta)
        {
            this.Id = Id;
            this.isOk = isOk;
            this.VagNum = VagNum;
            this.Tara = Tara;
            this.TaraNSI = TaraNSI;
            this.TaraDelta = TaraDelta;
            this.Video = "OK";
        }
        public RowTab(int Id, string Login, string Password)
        {
            this.Id = Id;
            this.Login = Login;
            this.Password = Password;
        }


        public string Login { get; set; }
        public string Password { get; set; }


        /// //////////////////////////////////////////
        public int Id { get; set; }
        public bool isOk { get; set; }
        public string VagNum { get; set; }
        public float Tara { get; set; }
        public float TaraNSI { get; set; }
        public float TaraDelta { get; set; }
        public string Video { get; set; }
    }
}
