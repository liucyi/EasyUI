using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EasyUI.Liuy.Domain.Models.Mapping
{
    public class SysPersonMap : EntityTypeConfiguration<SysPerson>
    {
        public SysPersonMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(20);

            this.Property(t => t.MyName)
                .HasMaxLength(20);

            this.Property(t => t.Sex)
                .HasMaxLength(10);

            this.Property(t => t.PhoneNumber)
                .HasMaxLength(11);

            this.Property(t => t.City)
                .HasMaxLength(20);

            this.Property(t => t.Village)
                .HasMaxLength(20);

            this.Property(t => t.State)
                .HasMaxLength(10);

            this.Property(t => t.Type)
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("SysPerson");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.MyName).HasColumnName("MyName");
            this.Property(t => t.Password).HasColumnName("Password");
            this.Property(t => t.Sex).HasColumnName("Sex");
            this.Property(t => t.SysRoleId).HasColumnName("SysRoleId");
            this.Property(t => t.SysDepartmentId).HasColumnName("SysDepartmentId");
            this.Property(t => t.PhoneNumber).HasColumnName("PhoneNumber");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.Village).HasColumnName("Village");
            this.Property(t => t.State).HasColumnName("State");
            this.Property(t => t.Type).HasColumnName("Type");

            // Relationships
            this.HasOptional(t => t.SysDepartment)
                .WithMany(t => t.SysPersons)
                .HasForeignKey(d => d.SysDepartmentId);
            this.HasOptional(t => t.SysRole)
                .WithMany(t => t.SysPersons)
                .HasForeignKey(d => d.SysRoleId);

        }
    }
}
