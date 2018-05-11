using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Interfaces
{
    public interface IGenericService<T>
    {
        T Kaydet(T entity);
        List<T> Listele();
        
        T Getir(int id);
        int Guncelle(T entity);
        bool Sil(int id);
        bool Sil(T entity);
        //List<T> Listele(Expression<Func<T, bool>> predicate);
    }
}
