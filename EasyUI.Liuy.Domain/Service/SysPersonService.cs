using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using EasyUI.Liuy.Domain.Models;
using EasyUI.Liuy.Domain.Abstract.IService;
using EasyUI.Liuy.Domain.Abstract.IRepository;
using EasyUI.Liuy.Domain.Repostory;

namespace EasyUI.Liuy.Domain.Service
{
    public class SysPersonService : BaseService<SysPerson>, ISysPersonService
    {
        private ISysPersonRepository iSysPersonRepository = new SysPersonRepostory();

        public override void SetCurrentRepository()
        {
            CurrentRepository = iSysPersonRepository;
        }

        public SysPerson Login(string name, string password)
        {
            var s = iSysPersonRepository.Search(c => c.Name == name && c.Password == password);
            if (s.Count() > 0)
            {
                return s.First();
            }
            return null;
        }
        public bool IsLogin(HttpSessionStateBase session)
        {
            if (session["account"] != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
