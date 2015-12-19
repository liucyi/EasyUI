
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyUI.Liuy.Domain.Abstract;
using EasyUI.Liuy.Domain.Abstract.IRepository;
using EasyUI.Liuy.Domain.Models;

namespace EasyUI.Liuy.Domain.Repostory
{
    //public class BaseRepository<T> : IRepository<T>
    //      where T : class, new()
    //{
    public class BaseRepository<T> where T : class
    {

        private WorkOrderContext db = new WorkOrderContext();

        protected DbSet<T> DbSet
        {
            get { return db.Set<T>(); }
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity">实体</param>
        public void Add(T entity)
        {
            db.Entry<T>(entity).State = EntityState.Added;
            db.SaveChanges();
            //  return entity;
        }


        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity">实体</param>
        public void Update(T entity)
        {
            db.Set<T>().Attach(entity);
            db.Entry<T>(entity).State = EntityState.Modified;
            //db.Entry<T>(entity).State= EntityState.Unchanged;
            db.SaveChanges();
            //  return true;
        }


        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity">实体</param>
        public void Delete(T entity)
        {
            db.Set<T>().Attach(entity);
            db.Entry<T>(entity).State = EntityState.Deleted;
            db.SaveChanges();
            //  return db.SaveChanges() > 0;
            //return true;
        }


        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="wherelambda">表达式</param>
        /// <returns></returns>
        public IQueryable<T> Search(Func<T, bool> wherelambda)
        {
            return db.Set<T>().Where<T>(wherelambda).AsQueryable();
        }

     
            public T FindById(object id)
            {
                return DbSet.Find(id);
            }

        /// <summary>
        ///  分页
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <param name="pageSize">页数</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="total">总数</param>
        /// <param name="whereLambda">表达式</param>
        /// <param name="sortOrder">是否正序</param>
        /// <param name="orderByLambda"></param>
        /// <returns></returns>
        public IQueryable<T> GetPagedList<S>(int pageSize, int pageIndex, out int total,
            Func<T, bool> whereLambda, string sortOrder, Func<T, S> orderByLambda)
        {
            var tempData = db.Set<T>().Where<T>(whereLambda);

            total = tempData.Count();

            //排序获取当前页的数据
            if (sortOrder == "asc")
            {
                tempData = tempData.OrderBy<T, S>(orderByLambda).
                      Skip<T>(pageSize * (pageIndex - 1)).
                      Take<T>(pageSize).AsQueryable();
            }
            else
            {
                tempData = tempData.OrderByDescending<T, S>(orderByLambda).
                     Skip<T>(pageSize * (pageIndex - 1)).
                     Take<T>(pageSize).AsQueryable();
            }
            return tempData.AsQueryable();
        }

        /// <summary>
        /// 分页查询(Linq分页方式)
        /// </summary>
        /// <param name="pageNumber">当前页</param>
        /// <param name="pageSize">页码</param>
        /// <param name="orderName">lambda排序名称</param>
        /// <param name="sortOrder">排序(升序or降序)</param>
        /// <param name="exp">lambda查询条件where</param>
        /// <returns></returns>
        public IEnumerable<T> GetPagedList(int pageNumber, int pageSize, Func<T, string> orderName, string sortOrder, Func<T, bool> exp)
        {

            if (sortOrder == "asc") //升序排列
            {
                return DbSet.Where(exp).OrderBy(orderName).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            }
            else
                return DbSet.Where(exp).Where(exp).OrderByDescending(orderName).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();


        }
       
    }
}
