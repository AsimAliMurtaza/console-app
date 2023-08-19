using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BusinessApp.BL
{
    internal class AdminBL:UserBL
    {
        public AdminBL() { }
        public AdminBL(string u, string p) : base(u, p) { }
        public AdminBL(string u, string p, string r):base(u, p, r) { }
        public override string GetUserDataString()
        {
            return $"{username},{password},{role}";
        }
        public void SetPassword(string password)
        {
            this.password = password;
        }
        public string GetPassword()
        {
            return this.password;
        }
        public string GetUsername()
        {
            return this.username;
        }
    }
}
