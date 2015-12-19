using System.Collections.Generic;
using EasyUI.Liuy.Domain.Models;

namespace EasyUI.Liuy.Domain.Abstract.IService
{
    public interface ISysMenuService : IBaseService<SysMenu>
    {
        Dictionary<string, object> GetTreeMenu();
    }
}