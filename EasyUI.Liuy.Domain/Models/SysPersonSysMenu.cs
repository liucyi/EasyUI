using System;
using System.Collections.Generic;

namespace EasyUI.Liuy.Domain.Models
{
    public partial class SysPersonSysMenu
    {
        public int Id { get; set; }
        public Nullable<int> SysPersonId { get; set; }
        public string SysMenuId { get; set; }
        public virtual SysMenu SysMenu { get; set; }
        public virtual SysPerson SysPerson { get; set; }
    }
}
