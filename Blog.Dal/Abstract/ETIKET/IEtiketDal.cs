using Blog.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Dal.Abstract.ETIKET
{
    public  interface IEtiketDal
    {
        Etiket Kaydet(Etiket entity);
        List<Etiket> Listele();
        Etiket Getir(int id);
        int Guncelle(Etiket entity);
        bool Sil(int id);
        bool Sil(Etiket entity);
    }
}
