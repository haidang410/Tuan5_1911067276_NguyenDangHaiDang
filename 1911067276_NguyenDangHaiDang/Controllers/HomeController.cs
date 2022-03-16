using System;
using System.Collections.Generic;
using PagedList;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _1911067276_NguyenDangHaiDang.Models;



namespace _1911067276_NguyenDangHaiDang.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
            MyDataDataContext data =new MyDataDataContext();
            public ActionResult Index(int? page)
            {
                if (page == null) page = 1;
                var all_sach = (from s in data.Saches select s).OrderBy(m => m.masach);
                int pageSize = 2;
                int pageNum = page ?? 1;
                return View(all_sach.ToPagedList(pageNum, pageSize));
            }
        }
   
    }