using Blog.Dal.Concrete.EntityFramework.Context;
using Blog.Entity.Models;
using Blog.Interfaces.KATEGORI;
using Blog.Interfaces.MAKALE;
using Blog.Interfaces.YORUM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace Blog.UI.Controllers
{
    //[HandleError]
    public class HomeController : Controller
    {
        IMakaleService _makaleService;
        IKategoriService _kategoriService;
        IYorumService _yorumService;
        public HomeController(IMakaleService makaleService, IKategoriService kategoriService, IYorumService yorumService)
        {
            this._makaleService = makaleService;
            this._kategoriService = kategoriService;
            this._yorumService = yorumService;
        }
        // GET: Home
        public ActionResult Giris()
        {
            return View();
        }
        [Route("Anasayfa")]
        public ActionResult Index(int Page = 1)
        {
            return View(_makaleService.Listele().ToPagedList(Page, 5));
        }
        [Route("makaleler")]
        public ActionResult BlogAra(string Ara = null)
        {
            var aranan = _makaleService.MakaleAra(Ara);
            return View(aranan.OrderByDescending(m => m.Tarih));
        }

        [ValidateInput(false)]
        [Route("makale/{kategori}/{baslik}-{id:int}")]
        public ActionResult MakaleDetay(int id, string kategori, string baslik)
        {
            var makaledetay = _makaleService.Getir(id);
            if (makaledetay==null)
            {
                return RedirectToAction("NotFound","Error");
            }
            return View(makaledetay);
        }
        public JsonResult YorumYap(string yorum, int Makaleid)
        {
            if (yorum == null)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            //_yorumService.Kaydet(Icerik);
            BlogContext context = new BlogContext();
            context.Yorum.Add(new Yorum()
            {
                MakaleID = Makaleid,
                Tarih = DateTime.Now,
                Icerik = yorum
            });
            context.SaveChanges();
            return Json(false, JsonRequestBehavior.AllowGet);
        }
        public ActionResult OkunmaArttir(int Makaleid)
        {
            _makaleService.OkunmaArttir(Makaleid);
            return View();
        }
        public ActionResult KategoriPartial()
        {

            return View(_kategoriService.Listele());
        }
        [Route("kategori/{kategori}/-{id:int}")]
        public ActionResult KategoriMakale(int id, string kategori)
        {
            //_makaleService.Getir(id)            
            BlogContext context = new BlogContext();
            var makaleler = context.Makale.Where(m => m.KategoriID == id).ToList();
            return View(makaleler);
        }
        public ActionResult PopulerMakaleler()
        {
            BlogContext context = new BlogContext();
            return View(context.Makale.OrderByDescending(m => m.Okunma).Take(5));
        }

    }
}