using Blog.Interfaces.MAKALE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Entity.Models;
using Blog.Dal.Abstract.MAKALEDAL;

namespace Blog.Bll.MAKALE
{
    public class MakaleManager : IMakaleService
    {
        IMakaleDal _makaleDal;
        public MakaleManager(IMakaleDal makaleDal)
        {
            this._makaleDal = makaleDal;
        }

        public Makale makaleEtiketSil(int id)
        {
            return _makaleDal.makaleEtiketSil(id);
        }

        public Makale Getir(int id)
        {
            return _makaleDal.Getir(id);
        }

        public int Guncelle(Makale entity)
        {
            return _makaleDal.Guncelle(entity);
        }

        public Makale Kaydet(Makale entity)
        {
            return  _makaleDal.Kaydet(entity);
        }

        public List<Makale> Listele()
        {
            return _makaleDal.Listele();
        }

        public Makale makaleYorumSil(int id)
        {
            return _makaleDal.makaleYorumSil(id);
        }

        public bool Sil(Makale entity)
        {
            return _makaleDal.Sil(entity);
        }

        public bool Sil(int id)
        {
            return _makaleDal.Sil(id);
        }

        public List<Makale> MakaleAra(string Ara)
        {
            return _makaleDal.MakaleAra(Ara);
        }

        public Makale OkunmaArttir(int Makaleid)
        {
            return _makaleDal.OkunmaArttir(Makaleid);
        }
    }
}
