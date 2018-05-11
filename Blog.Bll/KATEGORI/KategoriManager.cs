using Blog.Interfaces.KATEGORI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Entity.Models;
using Blog.Dal.Abstract.KATEGORIDAL;

namespace Blog.Bll.KATEGORI
{
    public class KategoriManager : IKategoriService
    {
        IKategoriDal _kategoriDal;
        public KategoriManager(IKategoriDal kategoriDal)
        {
            this._kategoriDal = kategoriDal;
        }

        public Kategori Getir(int id)
        {
            return _kategoriDal.Getir(id);
        }

        public int Guncelle(Kategori entity)
        {
            return _kategoriDal.Guncelle(entity);
        }

        public Kategori Kaydet(Kategori entity)
        {
            return _kategoriDal.Kaydet(entity);
        }

        public List<Kategori> Listele()
        {
            return _kategoriDal.Listele();
        }

        public bool Sil(Kategori entity)
        {
            return _kategoriDal.Sil(entity);
        }

        public bool Sil(int id)
        {
            return _kategoriDal.Sil(id);
        }
    }
}
