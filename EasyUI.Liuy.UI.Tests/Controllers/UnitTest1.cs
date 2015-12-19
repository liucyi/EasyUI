using System;
using System.Collections.Generic;
using System.Linq;
using EasyUI.Liuy.Domain.Abstract;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EasyUI.Liuy.Domain.Models;
using Top.Api;
using Top.Api.Request;
using Top.Api.Response;

namespace EasyUI.Liuy.UI.Tests.Controllers
{
    [TestClass]
    public class UnitTest1
    {
        private WorkOrderContext db = new WorkOrderContext();
        private const string url = "http://gw.api.taobao.com/router/rest";
        private const string appkey = "21629303";
        private const string appsecret = "2f8cd7a88293887aee1b820370b2d8af";
        private const string sessionKey = "6101918a53b0251376ff43ce66113a757411d7a2f3553171790727406";

        [TestMethod]
        public void Index()
        {
            ITopClient client = new DefaultTopClient(url, appkey, appsecret, "json");
            SellercatsListGetRequest req = new SellercatsListGetRequest();
            req.Nick = "古奇jh";
            SellercatsListGetResponse response = client.Execute(req);


        }
        [TestMethod]
        public void Index1()
        {
            ITopClient client = new DefaultTopClient(url, appkey, appsecret);
            LogisticsCompaniesGetRequest req = new LogisticsCompaniesGetRequest();
            req.Fields = "id,code,name,reg_mail_no";
            req.IsRecommended = true;
            req.OrderMode = "offline";
            LogisticsCompaniesGetResponse response = client.Execute(req);
        }
        [TestMethod]
        public void Index11()
        {
            ITopClient client = new DefaultTopClient(url, appkey, appsecret);
            UserSellerGetRequest req = new UserSellerGetRequest();
            req.Fields = ("user_id,sex,nick,type");
            UserSellerGetResponse response = client.Execute(req, sessionKey);
        }
        [TestMethod]
        public void Index111()
        {
            ITopClient client = new DefaultTopClient(url, appkey, appsecret);
            ShopGetRequest req = new ShopGetRequest();
            req.Fields = "sid,cid,title,nick,desc,bulletin,pic_path,created,modified";
            ShopGetResponse response = client.Execute(req);
        }
        [TestMethod]
        public void Index1111()
        {
            ITopClient client = new DefaultTopClient(url, appkey, appsecret, "json");
            TradesSoldGetRequest req = new TradesSoldGetRequest();
            req.Fields = "seller_nick,buyer_nick,title,type,created,sid,tid,seller_rate,buyer_rate,status,payment,discount_fee,adjust_fee,post_fee,total_fee,pay_time,end_time,modified,consign_time,buyer_obtain_point_fee,point_fee,real_point_fee,received_payment,commission_fee,pic_path,num_iid,num_iid,num,price,cod_fee,cod_status,shipping_type,receiver_name,receiver_state,receiver_city,receiver_district,receiver_address,receiver_zip,receiver_mobile,receiver_phone,orders.title,orders.pic_path,orders.price,orders.num,orders.iid,orders.num_iid,orders.sku_id,orders.refund_status,orders.status,orders.oid,orders.total_fee,orders.payment,orders.discount_fee,orders.adjust_fee,orders.sku_properties_name,orders.item_meal_name,orders.buyer_rate,orders.seller_rate,orders.outer_iid,orders.outer_sku_id,orders.refund_id,orders.seller_type";
            TradesSoldGetResponse response = client.Execute(req, sessionKey);
            var s = response.IsError;

        }
    }
}
