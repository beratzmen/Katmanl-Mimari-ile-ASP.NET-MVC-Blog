using Blog.Dal.Abstract.UYE;
using Blog.Entity.Models;
using Blog.Interfaces.UYE;
using SiparisTakip.Bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Bll.UYE
{
    public class UyeManager : IUyeService
    {
        IUyeDal _uyeDal;
        public UyeManager(IUyeDal uyeDal)
        {
            this._uyeDal = uyeDal;
        }

        public Uye Getir(int id)
        {
            return _uyeDal.Getir(id);
        }

        public int Guncelle(Uye entity)
        {
            return _uyeDal.Guncelle(entity);
        }

        public Uye Kaydet(Uye entity)
        {
            return _uyeDal.Kaydet(entity);
        }

        public Uye KullaniciGiris(string kullaniciAdi, string parola)
        {
            try
            {
                if (string.IsNullOrEmpty(kullaniciAdi.Trim()) || string.IsNullOrEmpty(parola.Trim()))
                {
                    throw new Exception("Kullanıcı Adı veya Parola Boş Geçilemez.");
                }

                //var sifre = new ToPasswordRepository().Md5(parola);
                var kullanici = _uyeDal.KullaniciGiris(kullaniciAdi, parola);
                if (kullanici == null)
                {
                    throw new Exception("Kullanıcı ve Parola Uyuşmuyor.");
                }
                else
                {
                    return kullanici;
                }
            }
            catch (Exception error)
            {
                throw new Exception("Kullanıcı Giriş Hata:" + error.Message);
            }
        }

        public List<Uye> Listele()
        {
            return _uyeDal.Listele();
        }

        public bool Sil(Uye entity)
        {
            return _uyeDal.Sil(entity);
        }

        public bool Sil(int id)
        {
            return _uyeDal.Sil(id);
        }
    }
}
