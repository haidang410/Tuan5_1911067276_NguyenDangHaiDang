using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _1911067276_NguyenDangHaiDang.Models;

namespace _1911067276_NguyenDangHaiDang.Controllers

{ 
    public class GioHangController : Controller
{
    // GET: GioHang
    MyDataDataContext data = new MyDataDataContext();
    public List<Giohang> Laygiohang()
    {
        List<Giohang> lstGioHang = Session["GioHang"] as List<Giohang>;
        if (lstGioHang == null)
        {
            lstGioHang = new List<Giohang>();
            Session["GioHang"] = lstGioHang;
        }
        return lstGioHang;
    }
    public ActionResult ThemGioHang(int id, string strURL)
    {
        List<Giohang> lstGiohang = Laygiohang();
        Giohang sanpham = lstGiohang.Find(n => n.masach == id);
        if (sanpham == null)
        {
            sanpham = new Giohang(id);
            lstGiohang.Add(sanpham);
            return Redirect(strURL);
        }
        else
        {
            sanpham.iSoluong++;
            return Redirect(strURL);
        }
    }
    private int TongSoluong()
    {
        int tsl = 0;
        List<Giohang> lstGioHang = Session["GioHang"] as List<Giohang>;
        if (lstGioHang == null)
        {
            tsl = lstGioHang.Sum(n => n.iSoluong);
        }
        return tsl;
    }
    private int TongSoLuongSanPham()
    {
        int tsl = 0;
        List<Giohang> lstGioHang = Session["GioHang"] as List<Giohang>;
        if (lstGioHang != null)
        {
            tsl = lstGioHang.Count;
        }
        return tsl;
    }
    private double TongTien()
    {
        double tt = 0;
        List<Giohang> lstGiohang = Session["GioHang"] as List<Giohang>;
        if (lstGiohang != null)
        {
            tt = lstGiohang.Sum(n => n.dThanhtien);
        }
        return tt;
    }
    public ActionResult GioHang()
    {
        List<Giohang> lstGiohang = Laygiohang();
        ViewBag.Tongsoluong = TongSoluong();
        ViewBag.Tongtien = TongTien();
        ViewBag.Tongsoluongsanpham = TongSoLuongSanPham();
        return View(lstGiohang);
    }
    public ActionResult GioHangPartial()
    {
        ViewBag.Tongsoluong = TongSoluong();
        ViewBag.Tongtien = TongTien();
        ViewBag.Tongsoluongsanpham = TongSoLuongSanPham();
        return PartialView();
    }
    public ActionResult XoaGiohang(int id)
    {
        List<Giohang> lstGiohang = Laygiohang();
        Giohang sanpham = lstGiohang.SingleOrDefault(n => n.masach == id);
        if (sanpham != null)
        {
            lstGiohang.RemoveAll(n => n.masach == id);
            return RedirectToAction("GioHang");
        }
        return RedirectToAction("GioHang");
    }
    public ActionResult CapnhatGiohang(int id, FormCollection collection)
    {
        List<Giohang> lstGiohang = Laygiohang();
        Giohang sanpham = lstGiohang.SingleOrDefault(n => n.masach == id);
        if (sanpham != null)
        {
            sanpham.iSoluong = int.Parse(collection["txtSoLg"].ToString());
        }
        return RedirectToAction("GioHang");
    }
    public ActionResult XoaTatCaGioHang()
    {
        List<Giohang> lstGiohang = Laygiohang();
        lstGiohang.Clear();
        return RedirectToAction("GioHang");
    }
}
}