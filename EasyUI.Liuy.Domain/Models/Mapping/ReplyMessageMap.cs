using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EasyUI.Liuy.Domain.Models.Mapping
{
    public class ReplyMessageMap : EntityTypeConfiguration<ReplyMessage>
    {
        public ReplyMessageMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.AcceptanceDep)
                .HasMaxLength(50);

            this.Property(t => t.SI)
                .HasMaxLength(50);

            this.Property(t => t.WorkOrderId)
                .HasMaxLength(20);

            this.Property(t => t.AcceptancePer)
                .HasMaxLength(20);

            this.Property(t => t.ProcessingMode)
                .HasMaxLength(20);

            this.Property(t => t.CreateTime)
                .HasMaxLength(20);

            this.Property(t => t.ProcessingTime)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("ReplyMessage");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.AcceptanceDep).HasColumnName("AcceptanceDep");
            this.Property(t => t.SI).HasColumnName("SI");
            this.Property(t => t.WorkOrderId).HasColumnName("WorkOrderId");
            this.Property(t => t.AcceptancePer).HasColumnName("AcceptancePer");
            this.Property(t => t.ProcessingMode).HasColumnName("ProcessingMode");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.ProcessingTime).HasColumnName("ProcessingTime");
            this.Property(t => t.Suggestion).HasColumnName("Suggestion");
            this.Property(t => t.Attachment).HasColumnName("Attachment");
            this.Property(t => t.AcceptancePhone).HasColumnName("AcceptancePhone");

            // Relationships
            this.HasOptional(t => t.WorkOrder)
                .WithMany(t => t.ReplyMessages)
                .HasForeignKey(d => d.WorkOrderId);

        }
    }
}
