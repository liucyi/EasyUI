using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EasyUI.Liuy.Domain.Models.Mapping
{
    public class SysDepartmentMap : EntityTypeConfiguration<SysDepartment>
    {
        public SysDepartmentMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(50);

            this.Property(t => t.Sort)
                .HasMaxLength(20);

            this.Property(t => t.State)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("SysDepartment");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.ParentId).HasColumnName("ParentId");
            this.Property(t => t.Sort).HasColumnName("Sort");
            this.Property(t => t.State).HasColumnName("State");

            // Relationships
            this.HasOptional(t => t.SysDepartment2)
                .WithMany(t => t.SysDepartment1)
                .HasForeignKey(d => d.ParentId);

        }
    }
}
