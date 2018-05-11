using Blog.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Dal.Abstract.KATEGORIDAL
{
   public interface IKategoriDal
    {
        Kategori Kaydet(Kategori entity);
        List<Kategori> Listele();
        Kategori Getir(int id);
        int Guncelle(Kategori entity);
        bool Sil(int id);
        bool Sil(Kategori entity);
    }
}
