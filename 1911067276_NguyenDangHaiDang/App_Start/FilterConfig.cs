using System.Web;
using System.Web.Mvc;

namespace _1911067276_NguyenDangHaiDang
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
