using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using EasyUI.Liuy.Domain.Models.Mapping;

namespace EasyUI.Liuy.Domain.Models
{
    public partial class WorkOrderContext : DbContext
    {
        static WorkOrderContext()
        {
            Database.SetInitializer<WorkOrderContext>(null);
        }

        public WorkOrderContext()
            : base("Name=WorkOrderContext")
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductOrder> ProductOrders { get; set; }
        public DbSet<ReplyMessage> ReplyMessages { get; set; }
        public DbSet<SysDepartment> SysDepartments { get; set; }
        public DbSet<SysMenu> SysMenus { get; set; }
        public DbSet<SysMenuSysRole> SysMenuSysRoles { get; set; }
        public DbSet<SysPerson> SysPersons { get; set; }
        public DbSet<SysPersonSysMenu> SysPersonSysMenus { get; set; }
        public DbSet<SysRole> SysRoles { get; set; }
        public DbSet<WorkOrder> WorkOrders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CustomerMap());
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new ProductOrderMap());
            modelBuilder.Configurations.Add(new ReplyMessageMap());
            modelBuilder.Configurations.Add(new SysDepartmentMap());
            modelBuilder.Configurations.Add(new SysMenuMap());
            modelBuilder.Configurations.Add(new SysMenuSysRoleMap());
            modelBuilder.Configurations.Add(new SysPersonMap());
            modelBuilder.Configurations.Add(new SysPersonSysMenuMap());
            modelBuilder.Configurations.Add(new SysRoleMap());
            modelBuilder.Configurations.Add(new WorkOrderMap());
        }
    }
}
