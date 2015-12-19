using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyUI.Liuy.UI.ViewModels
{
    public class AccountViewModel
    {
    }
    /// <summary>
    /// 登陆
    /// </summary>
    public class LoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ValidateCode { get; set; }
    }

    /// <summary>
    /// session存放的用户信息
    /// </summary>
    public class AccountInfo
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string MyName { get; set; }
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public string Department { get; set; }
        public string TEL { get; set; }
    }
}