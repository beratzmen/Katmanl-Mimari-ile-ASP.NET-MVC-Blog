using Blog.Dal.Abstract.UYE;
using Blog.Dal.Concrete.EntityFramework.Context;
using Blog.Entity.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Dal.Concrete.EntityFramework.Repository
{
    public class UyeRepository : IUyeDal
    {
        BlogContext context = new BlogContext();

        public Uye Getir(int id)
        {
            return context.Uye.AsNoTracking().FirstOrDefault(p => p.UyeId == id);
        }

        public int Guncelle(Uye entity)
        {
            context.Uye.AddOrUpdate(entity);
            return context.SaveChanges();
        }

        public Uye Kaydet(Uye entity)
        {
            context.Uye.Add(entity);
            context.SaveChanges();
            return entity;
        }

        public Uye KullaniciGiris(string kullaniciAdi, string sifre)
        {
            return context.Uye.Where(x => x.KullaniciAdi == kullaniciAdi && x.Sifre == sifre).SingleOrDefault();
        }

        public List<Uye> Listele()
        {
            return context.Uye.AsNoTracking().ToList();
        }

        public bool Sil(Uye entity)
        {
            context.Uye.Remove(entity);
            return context.SaveChanges() > 0;
        }

        public bool Sil(int id)
        {
            var uye = Getir(id);
            return Sil(uye);
        }
    }
}
