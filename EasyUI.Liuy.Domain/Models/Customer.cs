using System;
using System.Collections.Generic;

namespace EasyUI.Liuy.Domain.Models
{
    public partial class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string PassWord { get; set; }
        public string Sex { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string IDType { get; set; }
        public string IDNumber { get; set; }
        public string Address { get; set; }
        public string PostCode { get; set; }
    }
}
