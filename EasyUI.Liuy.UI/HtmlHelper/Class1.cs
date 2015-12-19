using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyUI.Liuy.UI.HtmlHelper
{
    public class HtmlHelper
    {
        public static MvcHtmlString Image(System.Web.Mvc.HtmlHelper helper, string src, string alt)
        {
            var builder = new TagBuilder("img");
            builder.MergeAttribute("src", src);
            builder.MergeAttribute("alt", alt);
            builder.ToString(TagRenderMode.SelfClosing);
            return MvcHtmlString.Create(builder.ToString());
        }
    }
}