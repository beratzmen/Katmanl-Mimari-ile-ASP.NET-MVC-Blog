using Blog.Bll.MAKALE;
using Blog.Dal.Concrete.EntityFramework.Context;
using Blog.Dal.Concrete.EntityFramework.Repository;
using Blog.Entity.Models;
using Blog.Interfaces.ETIKET;
using Blog.Interfaces.KATEGORI;
using Blog.Interfaces.MAKALE;
using Blog.Interfaces.YORUM;
using Blog.UI.Models;
using System;
using System.IO;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Blog.UI.Controllers
{
    [Authorize]
    public class AdminMakaleController : Controller
    {
        IMakaleService _makaleService;
        IKategoriService _kategoriService;
        IEtiketService _etiketService;
        IYorumService _yorumService;

        IMakaleService aaa = new MakaleManager(new MakaleRepository());

        public AdminMakaleController(IMakaleService makaleService, IKategoriService kategoriService, IEtiketService etiketService, IYorumService yorumService)
        {
            this._makaleService = makaleService;
            this._kategoriService = kategoriService;
            this._etiketService = etiketService;
            this._yorumService = yorumService;
        }

        // GET: AdminMakale
        public ActionResult Index()
        {
            return View(_makaleService.Listele());
        }
        public ActionResult MakaleEkle()
        {
            //ViewBag.KID = _kategoriService.Listele();          
            return View(_kategoriService.Listele());
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult MakaleEkle(Makale makale, string Etiketler, HttpPostedFileBase Foto)
        {

            BlogContext context = new BlogContext();
            if (ModelState.IsValid)
            {
                if (Foto != null)
                {
                    WebImage img = new WebImage(Foto.InputStream);
                    FileInfo fotoinfo = new FileInfo(Foto.FileName);
                    string newfoto = Guid.NewGuid().ToString() + fotoinfo.Extension;
                    img.Resize(800, 400);
                    img.Save("~/Uploads/MakaleFoto/" + newfoto);
                    makale.Foto = "/Uploads/MakaleFoto/" + newfoto;
                }
                if (Etiketler != null && Etiketler != "" && Etiketler!=" ")
                {
                    string[] etiketdizi = Etiketler.Split(',');
                    foreach (var item in etiketdizi)
                    {
                        var yenietiket = new Etiket { EtiketAdi = item };
                        //db.Etikets.Add(yenietiket);
                        _etiketService.Kaydet(yenietiket);
                        makale.Etiket.Add(yenietiket);
                        //makale.Etikets.Add(yenietiket); 
                    }
                }
                makale.UyeID = 1;
                _makaleService.Kaydet(makale);
                return RedirectToAction("Index");
            }
            //return RedirectToAction("Index","Home");
            return View();
        }

        public ActionResult Sil(int id)
        {
            return View(_makaleService.Getir(id));
        }
        [HttpPost]
        public ActionResult Sil(int id, FormCollection collection)
        {
            //_makaleService.makaleYorumSil(id);
            //_makaleService.makaleEtiketSil(id);
            aaa.Sil(id);

            //try
            //{
            //    BlogContext context = new BlogContext();
            //    var makale = context.Makale.AsNoTracking().Where(x => x.MakaleId == id).SingleOrDefault();
            //    context.Makale.Remove(makale);
            //    context.SaveChanges();


            //    //_makaleService.Sil(makale);
            return RedirectToAction("Index");
            //}
            //catch (Exception error)
            //{

            //}

            //return null;

        }

    }
}