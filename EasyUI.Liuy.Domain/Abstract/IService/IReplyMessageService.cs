using System.Collections.Generic;
using EasyUI.Liuy.Domain.Models;

namespace EasyUI.Liuy.Domain.Abstract.IService
{
    public interface IReplyMessageService : IBaseService<ReplyMessage>
    {
        /// <summary>
        /// 查询工单的回复信息列表
        /// </summary>
        /// <param name="wid">工单号</param>
        /// <returns></returns>
        Dictionary<string, object> GetReplyMessageList(string wid);

        /// <summary>
        /// 阶级性回复
        /// </summary>
        /// <param name="Wid"></param>
        /// <returns></returns>
        void AddAcceptance(ReplyMessage Wid);

        /// <summary>
        /// 工单完成
        /// </summary>
        /// <param name="Wid"></param>
        void UpdateAcceptance(ReplyMessage Wid);
    }
}