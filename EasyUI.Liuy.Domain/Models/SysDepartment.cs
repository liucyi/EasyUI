using System;
using System.Collections.Generic;

namespace EasyUI.Liuy.Domain.Models
{
    public partial class SysDepartment
    {
        public SysDepartment()
        {
            this.SysDepartment1 = new List<SysDepartment>();
            this.SysPersons = new List<SysPerson>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> ParentId { get; set; }
        public string Sort { get; set; }
        public string State { get; set; }
        public virtual ICollection<SysDepartment> SysDepartment1 { get; set; }
        public virtual SysDepartment SysDepartment2 { get; set; }
        public virtual ICollection<SysPerson> SysPersons { get; set; }
    }
}
