using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasyUI.Liuy.Domain.Models;
using EasyUI.Liuy.Domain.Abstract.IService;
using EasyUI.Liuy.Domain.Abstract.IRepository;
using EasyUI.Liuy.Domain.Repostory;

namespace EasyUI.Liuy.Domain.Service
{
    public class SysMenuService : BaseService<SysMenu>, ISysMenuService
    {
        private ISysMenuRepository iSysMenuRepository = new SysMenuRepostory();

        public override void SetCurrentRepository()
        {
            CurrentRepository = iSysMenuRepository;
        }

        /// <summary>
        /// 获取栏目树
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, object> GetTreeMenu()
        {
            Dictionary<string, object> menu = new Dictionary<string, object>();

            var query = from s in iSysMenuRepository.Search(c => c.ParentId == null)
                        select new
                       {
                           menuid = s.Id,
                           icon = s.Iconic,
                           menuname = s.Name,
                           menus = from a in iSysMenuRepository.Search(c => c.ParentId == s.Id)
                                   select new
                                   {
                                       menuid = a.Id,
                                       menuname = a.Name,
                                       icon = a.Iconic,
                                       url = a.Url
                                       //menus = from b in iSysMenuRepository.Search(c => c.ParentId == a.Id)
                                       //        select new
                                       //        {
                                       //            menuid = b.Id,
                                       //            menuname = b.Name,
                                       //            icon = b.Iconic,
                                       //            url = b.Url
                                       //        }
                                   }
                       };

            menu["menus"] =   query;
            return menu;
        }
    }
}
