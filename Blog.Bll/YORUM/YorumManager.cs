using Blog.Dal.Abstract.YORUM;
using Blog.Entity.Models;
using Blog.Interfaces.YORUM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Bll.YORUM
{
    public class YorumManager : IYorumService
    {
        IYorumDal _yorumDal;
        public YorumManager(IYorumDal yorumDal)
        {
            this._yorumDal = yorumDal;
        }

        public Yorum Getir(int id)
        {
            return _yorumDal.Getir(id);
        }

        public int Guncelle(Yorum entity)
        {
            return _yorumDal.Guncelle(entity);
        }

        public Yorum Kaydet(Yorum entity)
        {
            return _yorumDal.Kaydet(entity);
        }

        public List<Yorum> Listele()
        {
            return _yorumDal.Listele();
        }

        public bool Sil(Yorum entity)
        {
            return _yorumDal.Sil(entity);
        }

        public bool Sil(int id)
        {
            return _yorumDal.Sil(id);
        }
      
    }
}

