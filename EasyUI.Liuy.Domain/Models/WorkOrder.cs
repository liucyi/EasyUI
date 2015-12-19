using System;
using System.Collections.Generic;

namespace EasyUI.Liuy.Domain.Models
{
    public partial class WorkOrder
    {
        public WorkOrder()
        {
            this.ReplyMessages = new List<ReplyMessage>();
        }

        public string Id { get; set; }
        public string Type { get; set; }
        public Nullable<int> ProductId { get; set; }
        public Nullable<int> Quantity { get; set; }
        public string Contact { get; set; }
        public string Phone { get; set; }
        public string Sex { get; set; }
        public string ProblemDescription { get; set; }
        public string ProcessingMode { get; set; }
        public string Suggestion { get; set; }
        public string SI { get; set; }
        public string Attachment { get; set; }
        public string SIM { get; set; }
        public string Terminal { get; set; }
        public string Company { get; set; }
        public string State { get; set; }
        public string CreateTime { get; set; }
        public string ProcessingTime { get; set; }
        public string Service { get; set; }
        public virtual Product Product { get; set; }
        public virtual ICollection<ReplyMessage> ReplyMessages { get; set; }
    }
}
