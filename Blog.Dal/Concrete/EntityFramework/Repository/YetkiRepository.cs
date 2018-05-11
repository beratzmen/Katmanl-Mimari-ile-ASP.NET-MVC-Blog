using Blog.Dal.Abstract.YETKI;
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
    public class YetkiRepository : IYetkiDal
    {
        BlogContext context = new BlogContext();

        public Yetki Getir(int id)
        {
            return context.Yetki.AsNoTracking().FirstOrDefault(p => p.YetkiId == id);
        }

        public int Guncelle(Yetki entity)
        {
            context.Yetki.AddOrUpdate(entity);
            return context.SaveChanges();
        }

        public Yetki Kaydet(Yetki entity)
        {
            context.Yetki.Add(entity);
            context.SaveChanges();
            return entity;
        }

        public List<Yetki> Listele()
        {
            return context.Yetki.AsNoTracking().ToList();
        }

        public bool Sil(Yetki entity)
        {
            context.Yetki.Remove(entity);
            return context.SaveChanges() > 0;
        }

        public bool Sil(int id)
        {
            var yetki = Getir(id);
            return Sil(yetki);
        }
    }
}
