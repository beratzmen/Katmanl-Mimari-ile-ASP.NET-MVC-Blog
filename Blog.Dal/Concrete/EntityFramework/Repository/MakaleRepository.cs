using Blog.Dal.Abstract.MAKALEDAL;
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
    public class MakaleRepository : IMakaleDal
    {
        BlogContext context = new BlogContext();

        public Makale Getir(int id)
        {
            var makale= context.Makale.Where(p => p.MakaleId == id).SingleOrDefault();
            return makale;
        }

        public int Guncelle(Makale entity)
        {
            context.Makale.AddOrUpdate(entity);
            return context.SaveChanges();
        }

        public Makale Kaydet(Makale entity)
        {
            context.Makale.Add(entity);
            context.SaveChanges();
            return entity;
        }

        public List<Makale> Listele()
        {
            //return context.Makale.AsNoTracking().ToList();
            return context.Makale.OrderByDescending(m => m.MakaleId).ToList();
        }

        public List<Makale> MakaleAra(string Ara)
        {
            var aranan = context.Makale.Where(m => m.Baslik.Contains(Ara)).ToList();
            return aranan;
        }

        public Makale makaleEtiketSil(int id)
        {
            var makales = context.Makale.Where(m => m.MakaleId == id).SingleOrDefault();
            if (makales != null)
            {
                foreach (var i in makales.Etiket.ToList())
                {
                    makales.Etiket.Remove(i);
                }
            }
            context.SaveChanges();
            return makales;
        }

        public Makale makaleYorumSil(int id)
        {
            var makales = context.Makale.Where(m => m.MakaleId == id).SingleOrDefault();
            if (makales != null)
            {
                foreach (var i in makales.Yorum.ToList())
                {
                    context.Yorum.Remove(i);
                }
            }
            context.SaveChanges();
            return makales;
        }

        public Makale OkunmaArttir(int Makaleid)
        {
            var makale = context.Makale.Where(m => m.MakaleId == Makaleid).SingleOrDefault();
            makale.Okunma += 1;
            context.SaveChanges();
            return makale;
        }

        public bool Sil(Makale entity)
        {
            context.Makale.Remove(entity);
            return context.SaveChanges() > 0;
        }

        public bool Sil(int id)
        {
            using (BlogContext aa=new BlogContext())
            {
                try
                {
                    //var makale = Getir(id);
                    var a = aa.Makale.AsNoTracking().Where(p => p.MakaleId == id).SingleOrDefault();
                    //context.Makale.Attach(a);
                    aa.Makale.Remove(a);
                    return aa.SaveChanges() > 0;
                }
                catch (Exception e)
                {

                    throw e;
                }
             
            }
            
        }
    }
}
