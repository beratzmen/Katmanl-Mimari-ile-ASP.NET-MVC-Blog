using Blog.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Dal.Abstract.MAKALEDAL
{
    public interface IMakaleDal
    {
        Makale Kaydet(Makale entity);
        Makale OkunmaArttir(int Makaleid);
        List<Makale> MakaleAra(string Ara);
        List<Makale> Listele();
        Makale Getir(int id);
        int Guncelle(Makale entity);
        bool Sil(int id);
        bool Sil(Makale entity);
        Makale makaleYorumSil(int id);
        Makale makaleEtiketSil(int id);
        //List<Aksesuar> Listele(Expression<Func<Aksesuar, bool>> predicate);
    }
}
