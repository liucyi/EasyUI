using System.Web;
using EasyUI.Liuy.Domain.Models;

namespace EasyUI.Liuy.Domain.Abstract.IService
{
    public interface ITOPService
    {
        /// <summary>
        /// 获取前台展示的店铺内卖家自定义商品类目
        /// </summary>
        /// <returns></returns>
        string SellercatsListGet();
        /// <summary>
        /// 查询卖家已卖出的交易数据（根据创建时间）
        /// </summary>
        /// <returns></returns>
        string TradesSoldGet();
        /// <summary>
        /// 卖家信息
        /// </summary>
        /// <returns></returns>
        string SellerInfo(string _sessionkey);
        /// <summary>
        /// 订单物流信息
        /// </summary>
        /// <returns></returns>
        string LogisticsInfo();
    }
}