using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
namespace EasyUI.Liuy.Domain.Abstract.IRepository
{
    public interface IRepository<T>
           where T : new()
    {

        IQueryable<T> GetPagedList<S>(int pageSize, int pageIndex, out int total,
                                      Func<T, bool> whereLambda, string sortOrder, Func<T, S> orderByLambda);

        IEnumerable<T> GetPagedList(int pageNumber, int pageSize, Func<T, string> orderName, string sortOrder,
                                    Func<T, bool> exp);

        IQueryable<T> Search(Func<T, bool> wherelambda);

        T FindById(object id);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
