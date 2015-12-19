using System;
using System.Collections.Generic;

namespace EasyUI.Liuy.Domain.Models
{
    public partial class ReplyMessage
    {
        public int Id { get; set; }
        public string AcceptanceDep { get; set; }
        public string SI { get; set; }
        public string WorkOrderId { get; set; }
        public string AcceptancePer { get; set; }
        public string ProcessingMode { get; set; }
        public string CreateTime { get; set; }
        public string ProcessingTime { get; set; }
        public string Suggestion { get; set; }
        public string Attachment { get; set; }
        public string AcceptancePhone { get; set; }
        public virtual WorkOrder WorkOrder { get; set; }
    }
}
