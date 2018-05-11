using Blog.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Dal.Abstract.YETKI
{
    public interface IYetkiDal
    {
        Yetki Kaydet(Yetki entity);
        List<Yetki> Listele();
        Yetki Getir(int id);
        int Guncelle(Yetki entity);
        bool Sil(int id);
        bool Sil(Yetki entity);
    }
}
