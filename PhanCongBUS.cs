using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanLyShop
{
    class PhanCongBUS
    {
        private static PhanCongBUS instance;
        public static PhanCongBUS Instance
        {

            get
            {
                if (instance == null)
                {
                    instance = new PhanCongBUS();
                }
                return instance;
            }
            //set { instance = value; }
        }

        private PhanCongBUS()
        {

        }

        public void cboTenCa(ComboBox cbotenCa)
        {
            cbotenCa.Items.Clear();
            foreach (var item in PhanCongDAO.Instance.cboTenCa().Items)
            {
                cbotenCa.Items.Add(item);
            }         
            cbotenCa.SelectedIndex = 0;  
        }
        public void timeCa(TextBox timeBD,TextBox timeKT,string tenca)
        {
            string[] time = PhanCongDAO.Instance.timeCa(tenca);
            timeBD.Text = time[0];
            timeKT.Text = time[1];
        }

    }
}
