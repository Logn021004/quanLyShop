using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanLyShop
{
     class userBUS
    {
        private static userBUS instance;
        public static userBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new userBUS();
                return instance;
            }
        }
        public bool add(TextBox username, TextBox pwd ,TextBox manv , string quyen)
        {
            if(!string.IsNullOrEmpty(username.Text)&& !string.IsNullOrEmpty(manv.Text) && !userDAO.Instance.checkUsername(username.Text))
            {
                return userDAO.Instance.add(username.Text, pwd.Text, manv.Text, quyen);
            }
            else
                return false;
        }
    }
}
