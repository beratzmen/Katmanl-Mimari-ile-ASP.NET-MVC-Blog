using Blog.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Dal.Abstract.YORUM
{
    public interface IYorumDal
    {
        Yorum Kaydet(Yorum entity);
        List<Yorum> Listele();
        
        Yorum Getir(int id);
        int Guncelle(Yorum entity);
        bool Sil(int id);
        bool Sil(Yorum entity);

    }
}
