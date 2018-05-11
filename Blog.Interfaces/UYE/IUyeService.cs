using Blog.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Interfaces.UYE
{
    public interface IUyeService : IGenericService<Uye>
    {      
        Uye KullaniciGiris(string kullaniciAdi,string parola);
    }
}
