using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyUI.Liuy.Domain.Abstract.IService
{
    public partial interface IBaseService<T> where T : class,new()
    {
        //添加
        void Add(T entity);

        //修改
        void Update(T entity);


        //删
        void Delete(T entity);

        //单个实体
        T FindById(object id);

        //查询
        IQueryable<T> Search(Func<T, bool> wherelambda);


        //分页
        IQueryable<T> GetPagedList<S>(int pageSize, int pageIndex,
            out int total, Func<T, bool> whereLambda, string isAsc, Func<T, S> orderByLambda);
    }
}
