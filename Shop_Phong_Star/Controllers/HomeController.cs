using My_Database;
using My_Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop_Phong_Star.Controllers
{
    public class HomeController : Controller
    {
     

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";
            if (Session["user"] != null)
            {
                Response.Redirect("http://localhost:64336/User/Index");
            }
            DBIO provider = new DBIO();
            List<San_Pham> sp = provider.GetListSanPham(); 
            return View(sp);
        }
        [HttpPost]
        public JsonResult SignIn(FormCollection data)
        {
            ThongTinKhachHang ttkh = new ThongTinKhachHang();
            JsonResult js = new JsonResult();
            DBIO provider = new DBIO();
            try
            {
                ttkh.Ten_Khanh_Hang = data["name"];
                ttkh.Email = data["email"];
                ttkh.Phone = data["phone"];
                ttkh.Password = data["password"];
                ttkh.Adress = data["adress"];    
            }
            catch (Exception e)
            {
                js.Data = new
                {
                    status = "er",
                    message = e
                };
                return Json(js, JsonRequestBehavior.AllowGet);
            }
            if (provider.CheckUserExit(ttkh.Email) == 1)
            {
                js.Data = new
                {
                    status = "exit",
                };
                return Json(js, JsonRequestBehavior.AllowGet);
            }
            provider.InsertNewUser(ttkh);
            provider.SaveChange();
            //provider.InsertUserByQuery(ttkh.Ten_Khanh_Hang, ttkh.Email, ttkh.Phone, ttkh.Password, ttkh.Adress);
            Session["user"] = ttkh;
            Session.Timeout = 5; 
            js.Data = new
            {
                status = "OK",
                name = ttkh.Ten_Khanh_Hang,
                email = ttkh.Email,
                phone = ttkh.Phone,
                pass = ttkh.Password,
                diachi = ttkh.Adress
            };
            return Json(js, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Login(FormCollection data)
        {
            String email = data["email"];
            String password = data["password"];
            DBIO database = new DBIO();
            JsonResult json = new JsonResult();
            ThongTinKhachHang ttkh = new ThongTinKhachHang();
            ttkh = database.CheckLogin(email, password);
            if (ttkh == null)
            {
                json.Data = new
                {
                    status = "er",
                };
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            Session["user"] = ttkh; 
           
            Session.Timeout = 5; // thời gian time out là 5 phút
            json.Data = new
            {
                status = "OK",
                name = ttkh.Ten_Khanh_Hang,
                phone = ttkh.Phone,
                email = ttkh.Email,
                adress = ttkh.Adress
            };
            return Json(json, JsonRequestBehavior.AllowGet);
        }
    }
}
