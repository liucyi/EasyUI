using System.Web;
using EasyUI.Liuy.Domain.Models;

namespace EasyUI.Liuy.Domain.Abstract.IService
{
    public interface ISysPersonService : IBaseService<SysPerson>
    {
        SysPerson Login(string name, string password);
        bool IsLogin(HttpSessionStateBase session);
    }
}