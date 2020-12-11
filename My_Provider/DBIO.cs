using My_Database;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Provider
{ 
    public class DBIO
    {
        Shop_Phong_StartEntities bosstable = new Shop_Phong_StartEntities();
        // insert người mới đăng kí cách 1
        public void InsertNewUser(ThongTinKhachHang ttkh)
        {
            bosstable.ThongTinKhachHangs.Add(ttkh);
        }
        //insert vào một bảng bất kì
        public void InsertTable<T>(T obj)
        {
            bosstable.Set(obj.GetType()).Add(obj);
        }
        //insert bằng câu lệnh query
        public void InsertUserByQuery(String ten, String email, String phone, String password, String adress)
        {
            String query = @"INSERT dbo.ThongTinKhachHang
                           ( 
                              Ten_Khanh_Hang ,
                               Email ,
                              Phone ,
                              Password ,
                              Adress
                           )
                           VALUES  ( 
                             @name  , -- Ten_Khanh_Hang - nvarchar(50)
                             @email , -- Email - varchar(50)
                             @phone , -- Phone - varchar(20)
                             @password , -- Password - varchar(50)
                             @adress  -- Adress - nvarchar(50)
                           )";
            bosstable.Database.ExecuteSqlCommand(query, new SqlParameter("@name", ten), new SqlParameter("@email", email),
                new SqlParameter("@phone", phone), new SqlParameter("@password", password), new SqlParameter("@adress", adress));
        }
        // kiểm tra xem địa chỉ email này có tồn tại hay chưa
        public int CheckUserExit(String email)
        {
            String querry = @"SELECT COUNT(*) FROM dbo.ThongTinKhachHang kh WHERE kh.Email = @email ";
            return bosstable.Database.SqlQuery<int>(querry, new SqlParameter("@email", email)).FirstOrDefault();
        }
        // kiểm tra có tồn tại tài khoản này không
        public ThongTinKhachHang CheckLogin(String email, String password)
        {
            return bosstable.ThongTinKhachHangs.Where(c => c.Email == email && c.Password == password).FirstOrDefault();
        }
        //lấy danh sách sản phẩm
        public List<San_Pham> GetListSanPham()
        {
            return bosstable.San_Pham.ToList();
        }
        public void SaveChange()
        {

            bosstable.SaveChanges();
        }
    }
}
