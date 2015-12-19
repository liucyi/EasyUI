using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EasyUI.Liuy.Domain.Models.Mapping
{
    public class WorkOrderMap : EntityTypeConfiguration<WorkOrder>
    {
        public WorkOrderMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Type)
                .HasMaxLength(10);

            this.Property(t => t.Contact)
                .HasMaxLength(10);

            this.Property(t => t.Phone)
                .HasMaxLength(11);

            this.Property(t => t.Sex)
                .HasMaxLength(4);

            this.Property(t => t.ProcessingMode)
                .HasMaxLength(20);

            this.Property(t => t.SI)
                .HasMaxLength(50);

            this.Property(t => t.SIM)
                .HasMaxLength(30);

            this.Property(t => t.Terminal)
                .HasMaxLength(30);

            this.Property(t => t.Company)
                .HasMaxLength(30);

            this.Property(t => t.State)
                .HasMaxLength(8);

            this.Property(t => t.CreateTime)
                .HasMaxLength(20);

            this.Property(t => t.ProcessingTime)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("WorkOrder");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Type).HasColumnName("Type");
            this.Property(t => t.ProductId).HasColumnName("ProductId");
            this.Property(t => t.Quantity).HasColumnName("Quantity");
            this.Property(t => t.Contact).HasColumnName("Contact");
            this.Property(t => t.Phone).HasColumnName("Phone");
            this.Property(t => t.Sex).HasColumnName("Sex");
            this.Property(t => t.ProblemDescription).HasColumnName("ProblemDescription");
            this.Property(t => t.ProcessingMode).HasColumnName("ProcessingMode");
            this.Property(t => t.Suggestion).HasColumnName("Suggestion");
            this.Property(t => t.SI).HasColumnName("SI");
            this.Property(t => t.Attachment).HasColumnName("Attachment");
            this.Property(t => t.SIM).HasColumnName("SIM");
            this.Property(t => t.Terminal).HasColumnName("Terminal");
            this.Property(t => t.Company).HasColumnName("Company");
            this.Property(t => t.State).HasColumnName("State");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.ProcessingTime).HasColumnName("ProcessingTime");
            this.Property(t => t.Service).HasColumnName("Service");

            // Relationships
            this.HasOptional(t => t.Product)
                .WithMany(t => t.WorkOrders)
                .HasForeignKey(d => d.ProductId);

        }
    }
}
