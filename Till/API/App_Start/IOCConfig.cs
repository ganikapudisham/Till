//using System.ComponentModel;
using BLL;
using BLL.Impl;
using DAL;
using DAL.Impl;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using System.Web.Http;

namespace API
{
    public static class IocConfig
    {
        public static void RegisterServices(HttpConfiguration config)
        {

            // =========================================
            // 1. Create a new Simple Injector container
            // =========================================
            var container = new Container();

            container.Register<ICategoryRepository, CategoryRepository>(Lifestyle.Transient);
            container.Register<ISubCategoryRepository, SubCategoryRepository>(Lifestyle.Transient);
            container.Register<IProductRepository, ProductRepository>(Lifestyle.Transient);
            
            // Managers
            // ======== 

            // KashFlow.Accounting.Business <=> KashFlow.Accounting.Business.Imp;
            container.Register<ICategoryManager, CategoryManager>(Lifestyle.Transient);
            container.Register<ISubCategoryManager , SubCategoryManager>(Lifestyle.Transient);
            container.Register<IProductManager, ProductManager>(Lifestyle.Transient);
             
            // ===================================================
            // 3. Optionally verify the container's configuration.
            // ===================================================
            container.Verify();

            // =================================================
            // 4. Store the container for use by the application
            // =================================================
            config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);

        }
    }
}
