using System;
using System.Collections.Generic;

namespace EasyUI.Liuy.Domain.Models
{
    public partial class SysMenuSysRole
    {
        public int Id { get; set; }
        public string SysMenuId { get; set; }
        public Nullable<int> SysRoleId { get; set; }
        public virtual SysMenu SysMenu { get; set; }
        public virtual SysRole SysRole { get; set; }
    }
}
