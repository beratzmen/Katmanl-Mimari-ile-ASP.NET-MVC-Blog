using Blog.Bll.ETIKET;
using Blog.Bll.KATEGORI;
using Blog.Bll.MAKALE;
using Blog.Bll.UYE;
using Blog.Bll.YETKI;
using Blog.Bll.YORUM;
using Blog.Dal.Concrete.EntityFramework.Repository;
using Blog.Interfaces.ETIKET;
using Blog.Interfaces.KATEGORI;
using Blog.Interfaces.MAKALE;
using Blog.Interfaces.UYE;
using Blog.Interfaces.YETKI;
using Blog.Interfaces.YORUM;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Blog.UI.NinjectController
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private readonly IKernel ninjectKernel;

        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBllBindings();
        }
        private void AddBllBindings()
        {
            ninjectKernel.Bind<IMakaleService>()
                .To<MakaleManager>()
                .WithConstructorArgument("makaleDal", new MakaleRepository());


            ninjectKernel.Bind<IKategoriService>()
               .To<KategoriManager>()
               .WithConstructorArgument("kategoriDal", new KategoriRepository());

            ninjectKernel.Bind<IEtiketService>()
              .To<EtiketManager>()
              .WithConstructorArgument("etiketDal", new EtiketRepository());

            ninjectKernel.Bind<IUyeService>()
              .To<UyeManager>()
              .WithConstructorArgument("uyeDal", new UyeRepository());

            ninjectKernel.Bind<IYetkiService>()
              .To<YetkiManager>()
              .WithConstructorArgument("yetkiDal", new YetkiRepository());

            ninjectKernel.Bind<IYorumService>()
              .To<YorumManager>()
              .WithConstructorArgument("yorumDal", new YorumRepository());
        }
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);
        }

    }
}