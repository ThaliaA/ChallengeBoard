using Autofac;
using ProjectFuchsia.Models;
using Raven.Client;
using Raven.Client.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ProjectFuchsia
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static DocumentStore Store;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Store = new DocumentStore() { ConnectionStringName = "ProjectFuchsia" };
            Store.Initialize();
            var builder = new ContainerBuilder();

            Store.Conventions.RegisterIdConvention<User>((dbname, commands, user) => "users/" + user.UserName);

            builder.Register(c =>
            {
                IDocumentStore store = new DocumentStore
                {
                    ConnectionStringName = "ProjectFuchsia",
                    DefaultDatabase = "ProjectFuchsia"
                }.Initialize();

                return store;

            }).As<IDocumentStore>().SingleInstance();

            builder.Register(c => c.Resolve<IDocumentStore>().OpenAsyncSession()).As<IAsyncDocumentSession>().InstancePerLifetimeScope();

        }
    }
}