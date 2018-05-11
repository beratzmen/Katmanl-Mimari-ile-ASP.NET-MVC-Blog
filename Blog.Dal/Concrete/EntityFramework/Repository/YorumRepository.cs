using Blog.Dal.Abstract.YORUM;
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
    public class YorumRepository : IYorumDal
    {
        BlogContext context = new BlogContext();

        public Yorum Getir(int id)
        {
            return context.Yorum.AsNoTracking().FirstOrDefault(p => p.YorumId == id);
        }

        public int Guncelle(Yorum entity)
        {
            context.Yorum.AddOrUpdate(entity);
            return context.SaveChanges();
        }

        public Yorum Kaydet(Yorum entity)
        {
            context.Yorum.Add(entity);
            context.SaveChanges();
            return entity;
        }

        public List<Yorum> Listele()
        {
            return context.Yorum.AsNoTracking().ToList();
        }

        public bool Sil(Yorum entity)
        {
            context.Yorum.Remove(entity);
            return context.SaveChanges() > 0;
        }

        public bool Sil(int id)
        {
            var yorum = Getir(id);
            return Sil(yorum);
        }

     
    }
}
