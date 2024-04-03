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
        public void AnbtnAddClose(Button btnSaveCa,Button btnCloseAddCa,TextBox txtAddCa)
        {
            if (btnSaveCa.Visible == true && btnCloseAddCa.Visible == true&& txtAddCa.Visible==true)
            {
                txtAddCa.Visible = false;
                btnSaveCa.Visible = false;
                btnCloseAddCa.Visible = false;
            }
        }
        public void HienbtnAddClose(Button btnSaveCa, Button btnCloseAddCa,TextBox txtAddCa)
        {
            if (btnSaveCa.Visible == false && btnCloseAddCa.Visible == false && txtAddCa.Visible==false)
            {
                txtAddCa.Visible = true;
                btnSaveCa.Visible = true;
                btnCloseAddCa.Visible = true;
            }
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
        public bool themCa(TextBox txtAddCa,TextBox timeBD,TextBox timeKT)
        {
            return PhanCongDAO.Instance.ThemCa(txtAddCa.Text,timeBD.Text,timeKT.Text);
        }

        public bool suaCa(string nameCa,TextBox timeBD,TextBox timeKT)
        {   
            return PhanCongDAO.Instance.SuaCa(nameCa, timeBD.Text, timeKT.Text);
        }
        public bool IsValidHourFormat(string time)
        {
            
            string[] temp = time.Split(':');
            int hour=0,minute=0;
            if (time[time.Length - 3] != ':')
                return false;
            if(temp.Length != 2){
                return false;
            }
            if (!int.TryParse(temp[0],out hour) && !int.TryParse(temp[1],out minute))
            {
                return false;
            }
            if (hour < 0 || hour > 24 || minute < 0 || minute > 60)
            {
                return false;
            }
            return true;
        }

    }
}
