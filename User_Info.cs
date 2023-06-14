using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kwangwoon_Sugang_Practice_Project
{
    class User_Info
    {
        public static User_Info userinfo = new User_Info();
        private string id;
        private string pw;

        public User_Info()
        {
            id = string.Empty;
            pw = string.Empty;
        }

        public void SetId(string id)
        {
            this.id = id;
        }
        public void SetPw(string pw)
        {
            this.pw = pw;
        }
        public string GetId()
        {
            return this.id;
        }
        public string GetPw()
        {
            return this.pw;
        }
    }
}
