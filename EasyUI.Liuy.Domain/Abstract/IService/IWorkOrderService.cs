using System;
using System.Collections.Generic;
using EasyUI.Liuy.Domain.Models;

namespace EasyUI.Liuy.Domain.Abstract.IService
{
    public interface IWorkOrderService : IBaseService<WorkOrder>
    {
        /// <summary>
        /// 待处理工单列表
        /// </summary>
        /// <returns></returns>
        Dictionary<string, object> PendingList(int pageNumber, int pageSize, string type);
        /// <summary>
        /// 待处理工单详细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        WorkOrder PendingById(object id);
    }
}