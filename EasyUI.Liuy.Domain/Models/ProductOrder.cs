using System;
using System.Collections.Generic;

namespace EasyUI.Liuy.Domain.Models
{
    public partial class ProductOrder
    {
        /// <summary>
        /// 出货时间
        /// </summary>
        public string CreateTime { get; set; }
        /// <summary>
        /// 接待客服
        /// </summary>
        public string CustomerServices { get; set; }
        /// <summary>
        /// 顾客姓名
        /// </summary>
        public string Customer { get; set; }
        /// <summary>
        /// 联系地址

        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string TEL { get; set; }
        /// <summary>
        /// 所购商品
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// 单位


        /// </summary>
        public string Price { get; set; }
        /// <summary>
        /// 数量

        /// </summary>
        public string Quantity { get; set; }
        /// <summary>
        /// 单价

        /// </summary>
        public string Unit { get; set; }
        /// <summary>
        /// 总价

        /// </summary>
        public string TotalPrice { get; set; }
        /// <summary>
        /// 支付情况

        /// </summary>
        public string PayoutStatus { get; set; }
        /// <summary>
        /// 订单号

        /// </summary>
        public string OrderId { get; set; }

        /// 商品号

        /// </summary>
        public string GoodsId { get; set; }
        /// <summary>
        /// sim卡号

        /// </summary>
        public string Sim { get; set; }
        /// <summary>
        /// sim卡开通情况

        /// </summary>
        public string SimStatus { get; set; }
        /// <summary>
        /// 物流单号

        /// </summary>
        public string LogisticsId { get; set; }
        /// <summary>
        /// 收货情况

        /// </summary>
        public string ReceivingStatus { get; set; }
        /// <summary>
        /// 收款情况

        /// </summary>
        public string CollectionStatus { get; set; }
    }
}
