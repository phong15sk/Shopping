using System.Web;
using System.Web.Mvc;

namespace Shop_Phong_Star
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}