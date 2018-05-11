
using Blog.Dal.Abstract.YETKI;
using Blog.Entity.Models;
using Blog.Interfaces.YETKI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Bll.YETKI
{
    public class YetkiManager : IYetkiService
    {
        IYetkiDal _yetkiDal;
        public YetkiManager(IYetkiDal yetkiDal)
        {
            this._yetkiDal = yetkiDal;
        }

        public Yetki Getir(int id)
        {
            return _yetkiDal.Getir(id);
        }

        public int Guncelle(Yetki entity)
        {
            return _yetkiDal.Guncelle(entity);
        }

        public Yetki Kaydet(Yetki entity)
        {
            return _yetkiDal.Kaydet(entity);
        }

        public List<Yetki> Listele()
        {
            return _yetkiDal.Listele();
        }

        public bool Sil(Yetki entity)
        {
            return _yetkiDal.Sil(entity);
        }

        public bool Sil(int id)
        {
            return _yetkiDal.Sil(id);
        }
    }
}
