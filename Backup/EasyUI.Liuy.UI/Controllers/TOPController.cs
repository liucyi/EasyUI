using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EasyUI.Liuy.Domain.Abstract.IService;
using EasyUI.Liuy.UI.ViewModels;
using Top.Api;
using Top.Api.Request;
using Top.Api.Response;

namespace EasyUI.Liuy.UI.Controllers
{
    public class TOPController : Controller
    {
        private ITOPService topService;
        public TOPController(ITOPService top)
        {
            topService = top;
        }
        //
        // GET: /TOP/
        private TOPViewModel top = new TOPViewModel();
        /// <summary>
        /// 获取前台展示的店铺内卖家自定义商品类目 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult TradesSold()
        {
            return View();
        }
        public ActionResult SellercatsList()
        {
            return View();
        }

        public ActionResult LogisticsList()
        {
            return View();
        }
        public ActionResult SellercatsListGet()
        {
            var s = topService.SellercatsListGet();
            return JavaScript(s);
        }
       
        /// <summary>
        /// 查询卖家已卖出的交易数据
        /// </summary>
        /// <returns></returns>
        public ActionResult TradesSoldGet()
        {
            //  ViewBag.info = topService.TradesSoldGet();
            var s = topService.TradesSoldGet();
            if (s == "")
            {
                return RedirectToAction("Index");
            }
            return JavaScript(s);
        }

        /// <summary>
        /// 物流信息
        /// </summary>
        /// <returns></returns>
        public ActionResult Logistics()
        {
            var model = topService.LogisticsInfo();
            if (model == "")
            {
                return RedirectToAction("Index");
            }
            return JavaScript(model);
        }
    }
}
