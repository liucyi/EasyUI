using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;
using EasyUI.Liuy.Domain.Abstract.IService;
using EasyUI.Liuy.Domain.Models;
using WebMatrix.WebData;
using EasyUI.Liuy.Domain.Abstract;
namespace EasyUI.Liuy.UI.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class InitializeSimpleMembershipAttribute : ActionFilterAttribute
    {
        private static SimpleMembershipInitializer _initializer;
        private static object _initializerLock = new object();
        private static bool _isInitialized;
        private ISysPersonService iService;
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {


            var fcinfo = new FilterContextInfo(filterContext);
            //fcinfo.actionName;//获取域名
            //fcinfo.controllerName;获取 controllerName 名称

            bool isstate = true;

            if (iService.IsLogin(filterContext.HttpContext.Session))//如果满足
            {
                //逻辑代码
                // filterContext.Result = new HttpUnauthorizedResult();//直接URL输入的页面地址跳转到登陆页  
                // filterContext.Result = new RedirectResult("http://www.baidu.com");//也可以跳到别的站点
                //filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { Controller = "product", action = "Default" }));
            }
            else
            {
                filterContext.Result = new ContentResult { Content = @"抱歉,你不具有当前操作的权限！" };// 直接返回 return Content("抱歉,你不具有当前操作的权限！")
            }


        }



        private class SimpleMembershipInitializer
        {
            public SimpleMembershipInitializer()
            {
                Database.SetInitializer<WorkOrderContext>(null);

                try
                {
                    using (var context = new WorkOrderContext())
                    {
                        if (!context.Database.Exists())
                        {
                            // 创建不包含 Entity Framework 迁移架构的 SimpleMembership 数据库
                            ((IObjectContextAdapter)context).ObjectContext.CreateDatabase();
                        }
                    }

                    WebSecurity.InitializeDatabaseConnection("WorkOrderContext", "SysPerson", "Id", "Name", autoCreateTables: true);
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("无法初始化 ASP.NET Simple Membership 数据库。有关详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=256588", ex);
                }
            }
        }
    }
    public class FilterContextInfo
    {
        public FilterContextInfo(ActionExecutingContext filterContext)
        {
            #region 获取链接中的字符
            // 获取域名
            domainName = filterContext.HttpContext.Request.Url.Authority;

            //获取模块名称
            //  module = filterContext.HttpContext.Request.Url.Segments[1].Replace('/', ' ').Trim();

            //获取 controllerName 名称
            controllerName = filterContext.RouteData.Values["controller"].ToString();

            //获取ACTION 名称
            actionName = filterContext.RouteData.Values["action"].ToString();

        

            #endregion
        }
        /// <summary>
        /// 获取域名
        /// </summary>
        public string domainName { get; set; }
        /// <summary>
        /// 获取模块名称
        /// </summary>
        public string module { get; set; }
        /// <summary>
        /// 获取 controllerName 名称
        /// </summary>
        public string controllerName { get; set; }
        /// <summary>
        /// 获取ACTION 名称
        /// </summary>
        public string actionName { get; set; }



    }

}

