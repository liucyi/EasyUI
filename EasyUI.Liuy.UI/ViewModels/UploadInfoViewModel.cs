using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyUI.Liuy.UI.ViewModels
{
    public class UploadInfoViewModel
    {
        public bool IsReady { get; set; }
        public int ContentLength { get; set; }
        public int UploadedLength { get; set; }
        public string FileName { get; set; }
    }
}