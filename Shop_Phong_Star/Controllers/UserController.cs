using My_Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop_Phong_Star.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        public ActionResult Index()
        {
            if (Session["user"] != null)
            {
                ThongTinKhachHang ttkh = (ThongTinKhachHang)Session["user"];
                return View(ttkh);
            }
            return View();
        }

    }
}
