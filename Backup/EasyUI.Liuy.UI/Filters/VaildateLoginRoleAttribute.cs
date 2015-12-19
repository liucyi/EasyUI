using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using EasyUI.Liuy.UI.Filters;

namespace EasyUI.Liuy.UI.Filters
{
    ///
    /// 角色认证
    ///
    public class VaildateLoginRoleAttribute : ActionFilterAttribute
    {
        ///
        /// 角色名称
        ///
        public string Role { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
        //    if (!string.IsNullOrEmpty(Role))
        //    {
                if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
                {
                    string redirectOnSuccess = filterContext.HttpContext.Request.RawUrl;
                    string redirectUrl = string.Format("?ReturnUrl={0}", redirectOnSuccess);
                    string loginUrl = FormsAuthentication.LoginUrl + redirectUrl;
                    filterContext.HttpContext.Response.Redirect(loginUrl, true);
                }
                else
                {
                    //判断是否存在角色
                    FormsIdentity id = (FormsIdentity)HttpContext.Current.User.Identity;
                    FormsAuthenticationTicket ticket = id.Ticket;
                    string roles = ticket.UserData;
                    string[] chkRoles = this.Role.Split(',');
                    bool isAuthorized = false;
                    if (Array.IndexOf(chkRoles, roles) > -1)
                        isAuthorized = true;
                    else
                        isAuthorized = false;

                    if (!isAuthorized)
                        filterContext.Result = new RedirectToRouteResult("Default", new RouteValueDictionary(new { controller = "Manage", action = "AdminLogin" }));
                    //throw new UnauthorizedAccessException("你没有权限访问该页面");
                }
            //}
           // else
           // {
            //    throw new InvalidOperationException("没有指定角色");
           // }
        }
    }


    public class VaildateLogin : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext httpcontext = HttpContext.Current;
            // 確認目前要求的HttpSessionState
            if (httpcontext.Session != null)
            {
                //確認Session是否為新建立
                if (httpcontext.Session.IsNewSession)
                {
                    ////確認是否已存在cookies
                    //String sessioncookie = httpcontext.Request.Headers["Cookie"];
                    //if ((sessioncookie != null) && (sessioncookie.IndexOf("ASP.NET_SessionId") >= 0))
                    //{
                        Logon(filterContext);
                   // }
                }
            }
            base.OnActionExecuting(filterContext);
            //if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            //{
            //    filterContext.Result = new RedirectToRouteResult("Default", new RouteValueDictionary(new { controller = "Home", action = "Login" }));
            //}
        }
        private void Logon(ActionExecutingContext filterContext)
        {
            RouteValueDictionary dictionary = new RouteValueDictionary
                (new
                {
                    controller = "Home",
                    action = "Logon",
                    returnUrl = filterContext.HttpContext.Request.RawUrl
                });
            filterContext.Result = new RedirectToRouteResult(dictionary);
        }   
    }
}



