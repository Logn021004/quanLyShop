using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace quanLyShop
{
    class LoginBUS
    {
        private static LoginBUS instance;
        public static LoginBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new LoginBUS();
                return instance;
            }
        }

        public bool checkLogin(TextBox username,TextBox pwd)
        {
            return LoginDAO.Instance.checkLogin(username.Text, pwd.Text);
        }
    }
}
