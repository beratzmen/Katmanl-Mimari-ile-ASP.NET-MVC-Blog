using Blog.Entity.Models;
using Blog.Interfaces.UYE;
using SiparisTakip.AspNetMvcUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using static SiparisTakip.AspNetMvcUI.Models.IslemSonucuEnum;

namespace Blog.UI.Controllers
{
    public class KullaniciController : Controller
    {
        IUyeService _uyeService;

        public KullaniciController(IUyeService uyeService)
        {
            this._uyeService = uyeService;
        }
        // GET: Kullanici
        public ActionResult KullaniciGiris()
        {
            return View();
        }
        [HttpPost]
        public JsonResult KullaniciGiris(Uye kullanici)
        {
            IslemSonucModel islemSonucu;
            try
            {
                var _kullanici = _uyeService.KullaniciGiris(kullanici.KullaniciAdi, kullanici.Sifre);
                if (_kullanici != null)
                {
                    FormsAuthentication.SetAuthCookie("KullaniciId", false);
                    Session["KullaniciId"] = _kullanici.UyeId;
                    Session["KullaniciAdi"] = _kullanici.KullaniciAdi;
                    islemSonucu = new IslemSonucModel(IslemSonucKodlari.Basarili, "Kullanıcı Giriş Başarılı");
                }
                else
                {
                    islemSonucu = new IslemSonucModel(IslemSonucKodlari.Uyari, "Kullanıcı Giriş Başarısız");
                }
            }
            catch (System.Exception error)
            {
                islemSonucu = new IslemSonucModel(IslemSonucKodlari.Hata, "Kullanıcı Giriş Kontrol Sırasında Hata Oluştu." + error.Message);
            }

            return Json(islemSonucu);
        }
    }
}