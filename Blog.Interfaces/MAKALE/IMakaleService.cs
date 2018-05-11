using Blog.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Interfaces.MAKALE
{
    public interface IMakaleService:IGenericService<Makale>
    {
        Makale makaleYorumSil(int id);
        Makale makaleEtiketSil(int id);
        List<Makale> MakaleAra(string Ara);
        Makale OkunmaArttir(int Makaleid);
    }
}
