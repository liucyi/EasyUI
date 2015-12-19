using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
 
using EasyUI.Liuy.Domain.Abstract.IService;
using EasyUI.Liuy.Domain.Models;

namespace EasyUI.Liuy.UI.Controllers
{
    public class SysMenuController : Controller
    {
        //
        // GET: /SysMenu/
        private WorkOrderContext db = new WorkOrderContext();
        private ISysMenuService iSysMenuService;
        public SysMenuController(ISysMenuService iService)
        {
            iSysMenuService = iService;
        }
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult DataGrid(FormCollection form)
        {
            int pageSize = 5;
            int pageIndex = 1;
            int.TryParse(form["page"], out pageIndex);
            int.TryParse(form["rows"], out pageSize);
            pageSize = pageSize <= 0 ? 5 : pageSize;
            pageIndex = pageIndex < 1 ? 1 : pageIndex;

            var sysname = form["menuName"];
            var url = form["url"];

            var query = from s in db.SysMenus.ToList()

                        select new
                            {
                                s.Id,
                                s.Name,
                                ParentId = s.SysMenu2.Name,
                                s.Url,
                                s.Sort,
                                s.Iconic,
                                s.Remark,
                                s.State,
                                s.IsLeaf
                            };
            query = query
              .OrderBy(c => c.Id)
              .Skip((pageIndex - 1) * pageSize)
              .Take(pageSize)
              .ToList();
            Dictionary<string, object> dictionary = new Dictionary<string, object>();

            dictionary["total"] = query.Count();
            dictionary["rows"] = query;
            return Json(dictionary, JsonRequestBehavior.AllowGet);

        }

        public JsonResult TreeMenu()
        {
            #region MyRegion
            //Dictionary<string, object> menu = new Dictionary<string, object>();

            //var query = from s in iSysMenuRepository.FindAll()
            //            where s.ParentId == null
            //            select new
            //            {
            //                menuid = s.Id,
            //                icon = s.Iconic,
            //                menuname = s.Name,
            //                menus = from a in iSysMenuRepository.Search(c => c.ParentId == s.Id)
            //                        select new
            //                        {
            //                            menuid = a.Id,
            //                            menuname = a.Name,
            //                            icon = a.Iconic,
            //                            menus = from b in iSysMenuRepository.Search(c => c.ParentId == a.Id)
            //                                    select new
            //                                    {
            //                                        menuid = b.Id,
            //                                        menuname = b.Name,
            //                                        icon = b.Iconic,
            //                                        url = b.Url
            //                                    }
            //                        }
            //            };

            //menu["menus"] = query; 
            #endregion

            var model = iSysMenuService.GetTreeMenu();
            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}
