using Blog.Dal.Abstract.KATEGORIDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Entity.Models;
using System.Data.Entity.Migrations;
using Blog.Dal.Concrete.EntityFramework.Context;

namespace Blog.Dal.Concrete.EntityFramework.Repository
{
    public class KategoriRepository : IKategoriDal
    {
        BlogContext context = new BlogContext();

        public Kategori Getir(int id)
        {
            return context.Kategori.AsNoTracking().FirstOrDefault(p => p.KategoriId == id);
        }

        public int Guncelle(Kategori entity)
        {
            context.Kategori.AddOrUpdate(entity);
            return context.SaveChanges();
        }

        public Kategori Kaydet(Kategori entity)
        {
            context.Kategori.Add(entity);
            context.SaveChanges();
            return entity;
        }

        public List<Kategori> Listele()
        {
            return context.Kategori.AsNoTracking().ToList();
        }

        public bool Sil(Kategori entity)
        {
            context.Kategori.Remove(entity);
            return context.SaveChanges() > 0;
        }

        public bool Sil(int id)
        {
            var kategori = Getir(id);          
            return Sil(kategori);
          
        }
    }
}
