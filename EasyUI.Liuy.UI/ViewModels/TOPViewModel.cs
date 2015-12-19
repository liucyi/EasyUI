using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyUI.Liuy.UI.ViewModels
{
    public class TOPViewModel
    {
        public string Url
        {
            get { return "http://gw.api.taobao.com/router/rest"; }
        }
        public string Appkey
        {
            get { return "21629303"; }
        }
        public string Appsecret
        {
            get { return "2f8cd7a88293887aee1b820370b2d8af"; }
        }
        public string SessionKey
        {
            get { return "6102406341f1781b694058aca8256683f191ec9a7c053241790727406"; }
        }
    }
}