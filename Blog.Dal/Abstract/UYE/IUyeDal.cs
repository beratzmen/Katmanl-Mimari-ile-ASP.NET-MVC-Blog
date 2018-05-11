using Blog.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Dal.Abstract.UYE
{
    public interface IUyeDal
    {
        Uye Kaydet(Uye entity);
        List<Uye> Listele();
        Uye Getir(int id);
        int Guncelle(Uye entity);
        bool Sil(int id);
        bool Sil(Uye entity);
        Uye KullaniciGiris(string kullaniciAdi, string sifre);
    }
}
