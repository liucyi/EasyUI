using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EasyUI.Liuy.Domain.Models.Mapping
{
    public class SysMenuSysRoleMap : EntityTypeConfiguration<SysMenuSysRole>
    {
        public SysMenuSysRoleMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.SysMenuId)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("SysMenuSysRole");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.SysMenuId).HasColumnName("SysMenuId");
            this.Property(t => t.SysRoleId).HasColumnName("SysRoleId");

            // Relationships
            this.HasOptional(t => t.SysMenu)
                .WithMany(t => t.SysMenuSysRoles)
                .HasForeignKey(d => d.SysMenuId);
            this.HasOptional(t => t.SysRole)
                .WithMany(t => t.SysMenuSysRoles)
                .HasForeignKey(d => d.SysRoleId);

        }
    }
}
