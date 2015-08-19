using System;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using ManteqCodeTest.App_Start;
using NServiceBus;


namespace ManteqCodeTest
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static IBus bus;
        protected void Application_Start()
        {
            #region SetAutofacContainer
            //Create Autofac builder
            var builder = new ContainerBuilder();
            //Now register all depedencies to your custom IoC container


            //register mvc controller
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterAssemblyTypes(typeof(MvcApplication).Assembly)
               .AsImplementedInterfaces();

            builder.RegisterModelBinderProvider();

            // Register the Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType(typeof(IHandleMessages<>));
            builder.RegisterType(typeof(ICommand));
            builder.RegisterType(typeof(IMessage));


            var containerBuilder = builder.Build();

            BusConfiguration busConfiguration = new BusConfiguration();
            // ExistingLifetimeScope() ensures that IBus is added to the container as well,
            // allowing you to resolve IBus from your own components.
            busConfiguration.UseContainer<AutofacBuilder>(c => c.ExistingLifetimeScope(containerBuilder));
            busConfiguration.UseSerialization<JsonSerializer>();
            busConfiguration.UsePersistence<InMemoryPersistence>();
            // busConfiguration.EnableInstallers();
            bus = Bus.Create(busConfiguration).Start();

            //MVC resolver
            DependencyResolver.SetResolver(new AutofacDependencyResolver(containerBuilder));

            // Create the depenedency resolver for Web Api
            // Configure Web API with the dependency resolver.
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(containerBuilder);
            var config = new HttpConfiguration();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(containerBuilder);

            #endregion SetAutofacContainer

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

        }
        protected void Application_BeginRequest()
        {
            if (Request.ApplicationPath != "/"
                    && Request.ApplicationPath.Equals(Request.Path, StringComparison.CurrentCultureIgnoreCase))
            {
                var redirectUrl = VirtualPathUtility.AppendTrailingSlash(Request.ApplicationPath);
                Response.RedirectPermanent(redirectUrl);
            }
        }


    }
}
