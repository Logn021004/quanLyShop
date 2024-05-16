using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;


namespace quanLyShop
{
    public partial class InHoaDon : Form
    {
     
        public int MAHD { get;set; }
        public string TENNV { get;set; }
        public string DATE { get; set; }
        public string TENKHACH { get; set; }
        public int GIAMGIA { get; set; }
        public float TIENTRA { get; set; }
        public float TIENTHUA { get; set; }
        public float TONGTIEN { get; set; }


        public InHoaDon()
        {
            InitializeComponent();
        } 

        private void InHoaDon_Load(object sender, EventArgs e)
        {
            bill.LocalReport.ReportEmbeddedResource = "quanLyShop.PhieuHoaDon.rdlc";
            ReportDataSource reportData = new ReportDataSource();
            reportData.Name = "DataSet1";
            string query = "exec getCTHDandSP "+MAHD+"";
            reportData.Value = Functions.Instance.ExecuteQuery(query);
            bill.LocalReport.DataSources.Add(reportData);


            ReportParameter maHDParameter = new ReportParameter("MAHD",MAHD.ToString());
            ReportParameter tenNVParameter = new ReportParameter("TENNV", TENNV);
            ReportParameter dateParameter = new ReportParameter("date", DATE);
            ReportParameter tenKHACHParameter = new ReportParameter("TENKHACH", TENKHACH);
            ReportParameter giamGiaParameter = new ReportParameter("GIAMGIA", GIAMGIA.ToString()+"%");
            ReportParameter tienTraParameter = new ReportParameter("TIENTRA", TIENTRA.ToString("#,#") + " ₫");
            ReportParameter tienThuaParameter = new ReportParameter("TIENTHUA", TIENTHUA.ToString("#,#") + " ₫");
            ReportParameter tongTienParameter = new ReportParameter("TONGTIEN", TONGTIEN.ToString("#,#") + " ₫");

            bill.LocalReport.SetParameters(new ReportParameter[] 
            {
            maHDParameter, tenNVParameter, dateParameter, tenKHACHParameter,
            giamGiaParameter, tienTraParameter, tienThuaParameter, tongTienParameter
            });

            this.bill.RefreshReport();
        }
    }
}
