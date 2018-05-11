using Blog.Dal.Concrete.EntityFramework.Context;
using System.Linq;
using System.Web.Mvc;


namespace Blog.UI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            BlogContext context = new BlogContext();
            ViewBag.MakaleSayisi = context.Makale.Count(); 
            ViewBag.KategoriSayisi = context.Kategori.Count();
            return View();
        }      
    }
}