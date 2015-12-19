using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using EasyUI.Liuy.Domain.Abstract;
using EasyUI.Liuy.Domain.Abstract.IService;
using EasyUI.Liuy.Domain.Models;
using EasyUI.Liuy.UI.Filters;
using EasyUI.Liuy.UI.ViewModels;

namespace EasyUI.Liuy.UI.Controllers
{
    public class HomeController : Controller
    {
        private ISysPersonService iSysPersonService;
        private IWorkOrderService iWorkOrderService;
        public HomeController(IWorkOrderService iService, ISysPersonService iPersonService)
        {
            iWorkOrderService = iService;
            iSysPersonService = iPersonService;
        }
        public ActionResult Index()
        {
            var user = Response.Cookies[".ASPXAUTH"];
            var model = iWorkOrderService.Search(c => c.State == "待处理");
            return View(model);
        }
        [InitializeSimpleMembership()]
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {    //验证码验证
            if (!string.IsNullOrEmpty(model.ValidateCode) && !CaptchaController.IsValidCaptchaValue(model.ValidateCode.ToUpper()))
            {
                ModelState.AddModelError("ValidateCode", "验证码错误！");
                return Content("Error");
            }
            SysPerson sysPerson = new SysPerson()
            {
                Name = model.UserName,
                Password = model.Password// EncryptAndDecrypte.EncryptString(model.Password)
            };
            if (ModelState.IsValid)
            {
                var person = iSysPersonService.Login(model.UserName, model.Password);

                if (person != null)
                {    //登录成功
                    AccountInfo account = new AccountInfo();
                    account.Name = person.Name;
                    account.MyName = person.MyName;
                    account.Id = person.Id.ToString();
                    account.RoleId = person.SysRoleId.ToString();
                    account.RoleName = person.SysRole.Name;
                    account.Department = person.SysDepartment.Name;
                    account.TEL = person.Password;
                    Session["account"] = account;

                    //创造票据
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(model.UserName, false, 1);
                    //加密票据
                    string ticString = FormsAuthentication.Encrypt(ticket);
                    //输出到客户端
                    Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, ticString));
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    //跳转到登录前页面
                    //  return Redirect(HttpUtility.UrlDecode(Request.QueryString["returnUrl"]));


                    return Content("OK");
                }
            }

            ModelState.AddModelError("UserName", "用户名或者密码出错。");
            return View();

            return View();
        }
    }
}
