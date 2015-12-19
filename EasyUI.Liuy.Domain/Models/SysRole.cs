using System;
using System.Collections.Generic;

namespace EasyUI.Liuy.Domain.Models
{
    public partial class SysRole
    {
        public SysRole()
        {
            this.SysMenuSysRoles = new List<SysMenuSysRole>();
            this.SysPersons = new List<SysPerson>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string State { get; set; }
        public virtual ICollection<SysMenuSysRole> SysMenuSysRoles { get; set; }
        public virtual ICollection<SysPerson> SysPersons { get; set; }
    }
}
