using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection.WebForms;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using DIDemo.Web.Extensions;

namespace DIDemo.Web
{
    public class Global : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            string configFileName = EnvironmentExtension.IsDevelopment() ? "appsettings.development.json" : "appsettings.json";

            IConfiguration Configuration = new ConfigurationBuilder()
            .AddJsonFile(path: configFileName, optional: false, reloadOnChange: true)
            .Build();

            var services = new ServiceCollection();
            services.AddSingleton(Configuration);

            services.AddControllersAsServices(typeof(Global).Assembly.GetExportedTypes()
                .Where(t => !t.IsAbstract && !t.IsGenericTypeDefinition)
                .Where(t => typeof(IController).IsAssignableFrom(t) || t.Name.EndsWith("Controller", StringComparison.OrdinalIgnoreCase)));

            ServiceProvider serviceProvider = services.BuildServiceProvider(validateScopes: true);
            var resolver = new DefaultDependencyResolver(serviceProvider);
            DependencyResolver.SetResolver(resolver);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
            HttpRuntime.WebObjectActivator = new WebFormsServiceProvider(serviceProvider);
        }
    }
}
