[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(BertoniTest.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(BertoniTest.Web.App_Start.NinjectWebCommon), "Stop")]

namespace BertoniTest.Web.App_Start
{
    using System;
    using System.Web;
    using Bertoni.Data;
    using Bertoni.Data.Abstraction;
    using Bertoni.Data.Entitites;
    using Bertoni.Domain;
    using Bertoni.Domain.Abstraction;
    using Bertoni.Domain.BusinessObjects;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application.
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
            kernel.Bind<IRepository<Albums>>().To<AlbumRepository>();
            kernel.Bind<IRepository<Photos>>().To<PhotoRepository>();
            kernel.Bind<IRepository<Comments>>().To<CommentRepository>();
            kernel.Bind<IService<Album>>().To<AlbumService>();
            kernel.Bind<IService<Photo>>().To<PhotoService>();
            kernel.Bind<IService<Comment>>().To<CommentService>();
        }
    }
}