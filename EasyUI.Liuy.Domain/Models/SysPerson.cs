using System;
using System.Collections.Generic;

namespace EasyUI.Liuy.Domain.Models
{
    public partial class SysPerson
    {
        public SysPerson()
        {
            this.SysPersonSysMenus = new List<SysPersonSysMenu>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string MyName { get; set; }
        public string Password { get; set; }
        public string Sex { get; set; }
        public Nullable<int> SysRoleId { get; set; }
        public Nullable<int> SysDepartmentId { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public string Village { get; set; }
        public string State { get; set; }
        public string Type { get; set; }
        public virtual SysDepartment SysDepartment { get; set; }
        public virtual ICollection<SysPersonSysMenu> SysPersonSysMenus { get; set; }
        public virtual SysRole SysRole { get; set; }
    }
}
