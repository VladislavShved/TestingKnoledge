using System;
using System.Data.Entity;
using System.Web;
using BLL.Interfaces.Services;
using BLL.Services;
using DAL;
using DAL.Interfaces;
using DAL.Interfaces.Repositories;
using DAL.Repositories;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using MvcPL;
using Ninject;
using Ninject.Web.Common;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(NinjectWebCommon), "Stop")]

namespace MvcPL
{
    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {

            kernel.Bind<DbContext>().To<TestingDbEntities>().InRequestScope();

            kernel.Bind<IRepository<User>>().To<UserRepository>();
            kernel.Bind<IRepository<Test>>().To<TestRepository>();
            kernel.Bind<IRepository<Question>>().To<QuestionRepository>();
            kernel.Bind<IRepository<Variant>>().To<VariantRepository>();
            kernel.Bind<IRepository<Role>>().To<RoleRepository>();

            kernel.Bind<IUnitOfWork>().To<UnitOfWork>();

            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<ITestService>().To<TestService>();
            kernel.Bind<IVariantService>().To<VariantService>();
            kernel.Bind<IQuestionService>().To<QuestionService>();
            kernel.Bind<IRoleService>().To<RoleService>();
        }     
    }
}
