using System;
using System.Collections.Generic;

namespace EasyUI.Liuy.Domain.Models
{
    public partial class ProductOrder
    {
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public string CreateTime { get; set; }
        /// <summary>
        /// �Ӵ��ͷ�
        /// </summary>
        public string CustomerServices { get; set; }
        /// <summary>
        /// �˿�����
        /// </summary>
        public string Customer { get; set; }
        /// <summary>
        /// ��ϵ��ַ

        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// ��ϵ�绰
        /// </summary>
        public string TEL { get; set; }
        /// <summary>
        /// ������Ʒ
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// ��λ


        /// </summary>
        public string Price { get; set; }
        /// <summary>
        /// ����

        /// </summary>
        public string Quantity { get; set; }
        /// <summary>
        /// ����

        /// </summary>
        public string Unit { get; set; }
        /// <summary>
        /// �ܼ�

        /// </summary>
        public string TotalPrice { get; set; }
        /// <summary>
        /// ֧�����

        /// </summary>
        public string PayoutStatus { get; set; }
        /// <summary>
        /// ������

        /// </summary>
        public string OrderId { get; set; }

        /// ��Ʒ��

        /// </summary>
        public string GoodsId { get; set; }
        /// <summary>
        /// sim����

        /// </summary>
        public string Sim { get; set; }
        /// <summary>
        /// sim����ͨ���

        /// </summary>
        public string SimStatus { get; set; }
        /// <summary>
        /// ��������

        /// </summary>
        public string LogisticsId { get; set; }
        /// <summary>
        /// �ջ����

        /// </summary>
        public string ReceivingStatus { get; set; }
        /// <summary>
        /// �տ����

        /// </summary>
        public string CollectionStatus { get; set; }
    }
}
