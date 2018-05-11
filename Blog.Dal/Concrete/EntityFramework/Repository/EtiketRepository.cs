using Blog.Dal.Abstract.ETIKET;
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
    public class EtiketRepository : IEtiketDal
    {
        BlogContext context = new BlogContext();

        public Etiket Getir(int id)
        {
            return context.Etiket.AsNoTracking().FirstOrDefault(p => p.EtiketId == id);
        }

        public int Guncelle(Etiket entity)
        {
            context.Etiket.AddOrUpdate(entity);
            return context.SaveChanges();
        }

        public Etiket Kaydet(Etiket entity)
        {
            context.Etiket.Add(entity);
            context.SaveChanges();
            return entity;
        }

        public List<Etiket> Listele()
        {
            return context.Etiket.AsNoTracking().ToList();
        }

        public bool Sil(Etiket entity)
        {
            context.Etiket.Remove(entity);
            return context.SaveChanges() > 0;
        }

        public bool Sil(int id)
        {
            var etiket = Getir(id);
            return Sil(etiket);
        }
    }
}
