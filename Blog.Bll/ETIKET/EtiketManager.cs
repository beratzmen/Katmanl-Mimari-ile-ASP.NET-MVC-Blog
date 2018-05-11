using Blog.Dal.Abstract.ETIKET;
using Blog.Entity.Models;
using Blog.Interfaces.ETIKET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Bll.ETIKET
{
    public class EtiketManager : IEtiketService
    {
        IEtiketDal _etiketDal;
        public EtiketManager(IEtiketDal etiketDal)
        {
            this._etiketDal = etiketDal;
        }

        public Etiket Getir(int id)
        {
            return _etiketDal.Getir(id);
        }

        public int Guncelle(Etiket entity)
        {
            return _etiketDal.Guncelle(entity);
        }

        public Etiket Kaydet(Etiket entity)
        {
            return _etiketDal.Kaydet(entity);
        }

        public List<Etiket> Listele()
        {
            return _etiketDal.Listele();
        }

        public bool Sil(Etiket entity)
        {
            return _etiketDal.Sil(entity);
        }

        public bool Sil(int id)
        {
            return _etiketDal.Sil(id);
        }
    }
}
