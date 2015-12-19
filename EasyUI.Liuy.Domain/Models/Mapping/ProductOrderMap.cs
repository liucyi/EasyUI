using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EasyUI.Liuy.Domain.Models.Mapping
{
    public class ProductOrderMap : EntityTypeConfiguration<ProductOrder>
    {
        public ProductOrderMap()
        {
            // Primary Key
            this.HasKey(t => t.OrderId);

            // Properties
            this.Property(t => t.CreateTime)
                .HasMaxLength(22);

            this.Property(t => t.TEL)
                .HasMaxLength(11);

            this.Property(t => t.Quantity)
                .HasMaxLength(4);

            this.Property(t => t.PayoutStatus)
                .HasMaxLength(8);

            this.Property(t => t.OrderId)
                .IsRequired()
                .HasMaxLength(22);

            this.Property(t => t.SimStatus)
                .HasMaxLength(8);

            this.Property(t => t.ReceivingStatus)
                .HasMaxLength(8);

            this.Property(t => t.CollectionStatus)
                .HasMaxLength(8);

            // Table & Column Mappings
            this.ToTable("ProductOrder");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.CustomerServices).HasColumnName("CustomerServices");
            this.Property(t => t.Customer).HasColumnName("Customer");
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.TEL).HasColumnName("TEL");
            this.Property(t => t.GoodsId).HasColumnName("GoodsId");
            this.Property(t => t.ProductName).HasColumnName("ProductName");
            this.Property(t => t.Quantity).HasColumnName("Quantity");
            this.Property(t => t.Price).HasColumnName("Price");
            this.Property(t => t.Unit).HasColumnName("Unit");
            this.Property(t => t.TotalPrice).HasColumnName("TotalPrice");
            this.Property(t => t.PayoutStatus).HasColumnName("PayoutStatus");
            this.Property(t => t.OrderId).HasColumnName("OrderId");
            this.Property(t => t.Sim).HasColumnName("Sim");
            this.Property(t => t.SimStatus).HasColumnName("SimStatus");
            this.Property(t => t.LogisticsId).HasColumnName("LogisticsId");
            this.Property(t => t.ReceivingStatus).HasColumnName("ReceivingStatus");
            this.Property(t => t.CollectionStatus).HasColumnName("CollectionStatus");
        }
    }
}
