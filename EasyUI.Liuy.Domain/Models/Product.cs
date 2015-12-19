using System;
using System.Collections.Generic;

namespace EasyUI.Liuy.Domain.Models
{
    public partial class Product
    {
        public Product()
        {
            this.WorkOrders = new List<WorkOrder>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<WorkOrder> WorkOrders { get; set; }
    }
}
