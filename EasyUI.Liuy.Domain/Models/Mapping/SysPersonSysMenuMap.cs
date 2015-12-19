using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EasyUI.Liuy.Domain.Models.Mapping
{
    public class SysPersonSysMenuMap : EntityTypeConfiguration<SysPersonSysMenu>
    {
        public SysPersonSysMenuMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.SysMenuId)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("SysPersonSysMenu");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.SysPersonId).HasColumnName("SysPersonId");
            this.Property(t => t.SysMenuId).HasColumnName("SysMenuId");

            // Relationships
            this.HasOptional(t => t.SysMenu)
                .WithMany(t => t.SysPersonSysMenus)
                .HasForeignKey(d => d.SysMenuId);
            this.HasOptional(t => t.SysPerson)
                .WithMany(t => t.SysPersonSysMenus)
                .HasForeignKey(d => d.SysPersonId);

        }
    }
}
