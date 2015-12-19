using System;
using System.Collections.Generic;

namespace EasyUI.Liuy.Domain.Models
{
    public partial class SysMenu
    {
        public SysMenu()
        {
            this.SysMenu1 = new List<SysMenu>();
            this.SysMenuSysRoles = new List<SysMenuSysRole>();
            this.SysPersonSysMenus = new List<SysPersonSysMenu>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string ParentId { get; set; }
        public string Url { get; set; }
        public string Iconic { get; set; }
        public Nullable<int> Sort { get; set; }
        public string Remark { get; set; }
        public string State { get; set; }
        public string IsLeaf { get; set; }
        public virtual ICollection<SysMenu> SysMenu1 { get; set; }
        public virtual SysMenu SysMenu2 { get; set; }
        public virtual ICollection<SysMenuSysRole> SysMenuSysRoles { get; set; }
        public virtual ICollection<SysPersonSysMenu> SysPersonSysMenus { get; set; }
    }
}
