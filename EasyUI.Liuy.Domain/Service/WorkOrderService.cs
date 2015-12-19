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
    public class WorkOrderService : BaseService<WorkOrder>, IWorkOrderService
    {
        private IWorkOrderRepostory iRepostory = new WorkOrderRepostory();
        public override void SetCurrentRepository()
        {
            CurrentRepository = iRepostory;
        }


        public Dictionary<string, object> PendingList(int pageNumber, int pageSize, string type)
        {
            var query = from s in iRepostory.Search(c => type == "" ? c.State == "待处理" : c.State == "待处理" && c.Type == type).ToList()
                        select new
                        {
                            s.Id,
                            s.Phone,
                            s.ProblemDescription,
                            s.ProcessingMode,
                            s.ProcessingTime,
                            s.Product.Name,
                            s.Quantity,
                            s.SI,
                            s.SIM,
                            s.Service,
                            s.Sex,
                            s.State,
                            s.Suggestion,
                            s.Terminal,
                            s.Attachment,
                            s.Company,
                            s.Contact,
                            s.CreateTime,
                            s.Type
                        };
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            dictionary["total"] = query.Count();
            query = query
            .OrderBy(c => c.Id)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();



            dictionary["rows"] = query;
            return dictionary;
        }

        public WorkOrder PendingById(object id)
        {
            return iRepostory.FindById(id);
        }


    }
}
