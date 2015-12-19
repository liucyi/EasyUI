using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EasyUI.Liuy.Domain.Models.Mapping
{
    public class SysMenuMap : EntityTypeConfiguration<SysMenu>
    {
        public SysMenuMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ParentId)
                .HasMaxLength(50);

            this.Property(t => t.Iconic)
                .HasMaxLength(50);

            this.Property(t => t.State)
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("SysMenu");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.ParentId).HasColumnName("ParentId");
            this.Property(t => t.Url).HasColumnName("Url");
            this.Property(t => t.Iconic).HasColumnName("Iconic");
            this.Property(t => t.Sort).HasColumnName("Sort");
            this.Property(t => t.Remark).HasColumnName("Remark");
            this.Property(t => t.State).HasColumnName("State");
            this.Property(t => t.IsLeaf).HasColumnName("IsLeaf");

            // Relationships
            this.HasOptional(t => t.SysMenu2)
                .WithMany(t => t.SysMenu1)
                .HasForeignKey(d => d.ParentId);

        }
    }
}
