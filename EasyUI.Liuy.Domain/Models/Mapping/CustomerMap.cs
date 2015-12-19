using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EasyUI.Liuy.Domain.Models.Mapping
{
    public class CustomerMap : EntityTypeConfiguration<Customer>
    {
        public CustomerMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(20);

            this.Property(t => t.Phone)
                .HasMaxLength(11);

            this.Property(t => t.PassWord)
                .HasMaxLength(20);

            this.Property(t => t.Sex)
                .HasMaxLength(4);

            this.Property(t => t.Province)
                .HasMaxLength(16);

            this.Property(t => t.City)
                .HasMaxLength(16);

            this.Property(t => t.IDType)
                .HasMaxLength(14);

            this.Property(t => t.IDNumber)
                .HasMaxLength(20);

            this.Property(t => t.PostCode)
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("Customer");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Phone).HasColumnName("Phone");
            this.Property(t => t.PassWord).HasColumnName("PassWord");
            this.Property(t => t.Sex).HasColumnName("Sex");
            this.Property(t => t.Province).HasColumnName("Province");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.IDType).HasColumnName("IDType");
            this.Property(t => t.IDNumber).HasColumnName("IDNumber");
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.PostCode).HasColumnName("PostCode");
        }
    }
}
