using AutoMapper;
using System;

using Unity;
using Unity.AspNet.Mvc;
using Unity.Injection;
using ZavenDotNetInterview.App.AutoMapperProfiles;
using ZavenDotNetInterview.App.Models.Context;
using ZavenDotNetInterview.App.Repositories;
using ZavenDotNetInterview.App.Repositories._Interfaces;
using ZavenDotNetInterview.App.Services;
using ZavenDotNetInterview.App.Services._Interfaces;

namespace ZavenDotNetInterview.App
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            container.RegisterType<IJobsRepository, JobsRepository>();
            container.RegisterType<ILogsRepository, LogsRepository>();
            
            container.RegisterType<IZavenDotNetInterviewContext, ZavenDotNetInterviewContext>(new PerRequestLifetimeManager(), new InjectionConstructor("name=ZavenDotNetInterview"));
            
            container.RegisterType<IJobProcessorService, JobProcessorService>(new PerRequestLifetimeManager());
            container.RegisterType<IJobValueService, JobValueService>(new PerRequestLifetimeManager());

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new JobProfile());
                cfg.AddProfile(new LogProfile());
            });

            container.RegisterInstance<IMapper>(config.CreateMapper());
        }
    }
}