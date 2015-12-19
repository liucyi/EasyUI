using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using EasyUI.Liuy.Domain.Abstract.IService;
using EasyUI.Liuy.Domain.Service;

namespace EasyUI.Liuy.UI
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();
            SetupResolveRules(builder);
            //   builder.RegisterModule(new ConfigurationSettingsReader("autofac"));//xml
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
        }

        private void SetupResolveRules(ContainerBuilder builder)
        {
            builder.RegisterType<SysMenuService>().As<ISysMenuService>();
            builder.RegisterType<WorkOrderService>().As<IWorkOrderService>();
            builder.RegisterType<ReplyMessageService>().As<IReplyMessageService>();
            builder.RegisterType<SysPersonService>().As<ISysPersonService>();
           
        }
    }
}