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
    public class ReplyMessageService : BaseService<ReplyMessage>, IReplyMessageService
    {
        private IReplyMessageRepostory iRepostory = new ReplyMessageRepostory();

        public override void SetCurrentRepository()
        {
            CurrentRepository = iRepostory;
        }


        public Dictionary<string, object> GetReplyMessageList(string wid)
        {

            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            var query = iRepostory.Search(c => c.WorkOrder.Id == wid).ToList();
            dictionary["total"] = query.Count();


            dictionary["rows"] = query;
            return dictionary;
        }

        public void AddAcceptance(ReplyMessage Wid)
        {
            iRepostory.Add(Wid);
        }
        public void UpdateAcceptance(ReplyMessage Wid)
        {
            iRepostory.Update(Wid);
        }
    }
}
