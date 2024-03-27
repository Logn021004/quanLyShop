using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.Collections;

namespace quanLyShop
{
    internal class NhanvienDAO
    {
        private static NhanvienDAO instance;
        public static NhanvienDAO Instance
        {

            get
            {
                if (instance == null)
                {
                    instance = new NhanvienDAO();
                }
                return instance;
            }
            //set { instance = value; }
        }

        private NhanvienDAO()
        {

        }
        public DataTable Xem()
        {
            string query = "select MANV as N'Mã nhân viên',TENNV as N'Tên nhân viên',CMND,SDT AS N'Số điện thoại',DCHI as N'Địa chỉ',NGAYSINH as N'Ngày sinh',LUONG as N'Lương', NGAYBDLAM as N'Ngày bắt đầu làm', NGAYBDNGHI as N'Ngày bắt đầu nghỉ',TRANGTHAI as N'Trạng Thái',SEX as N'Giới tính'\r\nfrom NHANVIEN where TRANGTHAI = N'Nhân viên' ";
            return Functions.Instance.ExecuteQuery(query);
        }
        public DataTable XemDSDaNghi()
        {
            string query = "select MANV as N'Mã nhân viên',TENNV as N'Tên nhân viên',CMND,SDT AS N'Số điện thoại',DCHI as N'Địa chỉ',NGAYSINH as N'Ngày sinh',LUONG as N'Lương', NGAYBDLAM as N'Ngày bắt đầu làm', NGAYBDNGHI as N'Ngày bắt đầu nghỉ',TRANGTHAI as N'Trạng Thái',SEX as N'Giới tính'\r\nfrom NHANVIEN where TRANGTHAI = N'Đã nghỉ' ";
            return Functions.Instance.ExecuteQuery(query);
        }
        public DataTable Timkiem(TextBox text)
        {
            string query = "select MANV as N'Mã nhân viên',TENNV as N'Tên nhân viên',CMND,SDT AS N'Số điện thoại',DCHI as N'Địa chỉ',NGAYSINH as N'Ngày sinh',LUONG as N'Lương', NGAYBDLAM as N'Ngày bắt đầu làm', NGAYBDNGHI as N'Ngày bắt đầu nghỉ',TRANGTHAI as N'Trạng Thái',SEX as N'Giới tính'\r\n from NHANVIEN where  TENNV like N'%'+ @TENNV +N'%' and TRANGTHAI = N'Nhân viên' ";
            object[] para = new object[] { text.Text };
            return Functions.Instance.ExecuteQuery(query, para);
        }
        public bool Xoa(TextBox Id,DateTime date)
        {
            string id = Id.Text;   
            string query = "update NHANVIEN SET TRANGTHAI=N'Đã nghỉ',NGAYBDNGHI= @NGAYBDNGHI WHERE MANV= @MANV";
            object[] para = new object[] { date, id };
            if (Functions.Instance.ExecuteNonQuery(query, para) > 0)
                return true;
            return false;
        }

        public bool Sua(NhanvienDTO user)
        {
            string query = "update NHANVIEN set TENNV= @TENNV ,CMND= @CMNND ,SDT= @SDT ,DCHI= @DCHI ,NGAYSINH= @NGAYSINH ,LUONG= @LUONG ,NGAYBDLAM= @NGAYBDLAM ,SEX= @GIOITINH  WHERE MANV= @MANV ";
            object[] para = new object[] {user.ten,user.cmnd,user.sdt,user.dchi,user.ngaysinh,user.luong,user.ngaybdlam,user.gioitinh,user.maNV };
            if (Functions.Instance.ExecuteNonQuery(query, para) > 0)
                return true;
            return false;
        }
        public bool Them(NhanvienDTO user)
        {
            string query = "insert into NHANVIEN(TENNV,CMND,SDT,DCHI,NGAYSINH,LUONG,NGAYBDLAM,NGAYBDNGHI,TRANGTHAI,SEX) \r\n              values( @TENNV , @CMND , @SDT , @DCHI , @NGAYSINH , @LUONG , @NGAYBDLAM ,NULL,'Nhân viên', @SEX )";
            object[] para = new object[] { user.ten, user.cmnd, user.sdt, user.dchi, user.ngaysinh, user.luong, user.ngaybdlam, user.gioitinh };
            if(checkTT(user.sdt,user.cmnd))        
                return false;  
            if (Functions.Instance.ExecuteNonQuery(query, para) > 0)
                return true;
            return false;
        }

        public bool ThemNVDaNghi(NhanvienDTO user)
        {
            string query = "select MANV,NGAYBDNGHI,TRANGTHAI from NHANVIEN where MANV= @MANV and TRANGTHAI=N'Đã nghỉ'";
            object[] para = new object[] { user.maNV };
            if(Functions.Instance.ExecuteQuery(query, para).Rows.Count > 0)
            {
                query = "update NHANVIEN set TRANGTHAI=N'Nhân viên',NGAYBDNGHI=NULL where MANV= @MANV";
                Functions.Instance.ExecuteNonQuery(query,para);
                return true;
            }
            return false;
        }
        public bool checkTT(int SDT,int CMND)
        {
            string query = "select * from NHANVIEN where SDT= @SDT OR CMND= @CMND ";
            object[] para=new object[] {SDT,CMND};
            
            if (Functions.Instance.ExecuteQuery(query,para).Rows.Count > 0)
                return true;
            return false;
        }   
    }
}
