using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;


using System.Data;
using System.Data.Entity;
using EasyUI.Liuy.Domain.Abstract;
using EasyUI.Liuy.Domain.Models;


namespace EasyUI.Liuy.Domain.Repostory
{
    //public class Repository<T> : IRepository<T>
    //      where T : class, new()
    //{
    //    private readonly easyuiDBContext _dbContext;

    //    public Repository(easyuiDBContext dbContext)
    //    {
    //        _dbContext = dbContext;
    //    }

    //    protected virtual void OnLoaded(T entity)
    //    {

    //    }

    //    protected DbSet<T> DbSet
    //    {
    //        get { return _dbContext.Set<T>(); }
    //    }

    //    public IEnumerable<T> FindAll()
    //    {
    //        return DbSet.AsQueryable();
    //    }
 

    //    //public PagedList<T> GetPagedList(Expression<Func<T, bool>> expression, int pageIndex, int pageSize)
    //    //{
    //    //    return DbSet.Where(expression).ToPagedList(pageIndex, pageSize);
    //    //}
    //    //public PagedList<T> GetPagedList(Expression<Func<T, bool>> expression, string orderBy, SortOrder sortOrder, int pageIndex, int pageSize)
    //    //{
    //    //    return DbSet.Where(expression)
    //    // .OrderBy(orderBy, sortOrder)
    //    // .ToPagedList(pageIndex, pageSize);
    //    //}
    //    /// <summary>
    //    /// 分页查询(Linq分页方式)
    //    /// </summary>
    //    /// <param name="pageNumber">当前页</param>
    //    /// <param name="pageSize">页码</param>
    //    /// <param name="orderName">lambda排序名称</param>
    //    /// <param name="sortOrder">排序(升序or降序)</param>
    //    /// <param name="exp">lambda查询条件where</param>
    //    /// <returns></returns>
    //    public virtual IEnumerable<T> GetPagedList(int pageNumber, int pageSize, Func<T, string> orderName, string sortOrder, Func<T, bool> exp)
    //    {

    //        if (sortOrder == "asc") //升序排列
    //        {
    //            return DbSet.Where(exp).OrderBy(orderName).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
    //        }
    //        else
    //            return DbSet.Where(exp).Where(exp).OrderByDescending(orderName).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();


    //    }
    //    public T FindById(int id)
    //    {
    //        return DbSet.Find(id);
    //    }

    //    public void Add(T entity)
    //    {
    //        DbSet.Add(entity);
    //        _dbContext.SaveChanges();
    //    }

    //    public void Delete(T entity)
    //    {
    //        DbSet.Remove(entity);
    //        _dbContext.SaveChanges();
    //    }

    //    public void Delete(string id)
    //    {
    //        foreach (var i in id.Split(','))
    //        {
    //            DbSet.Remove(FindById(int.Parse(i)));
    //            _dbContext.SaveChanges();
    //        }
    //    }
    //    public void Update(T entity)
    //    {
    //        var entry = _dbContext.Entry(entity);
    //        if (entry.State == EntityState.Detached)
    //        {
    //            //DbSet.Attach(entity);
    //            entry.State = EntityState.Modified;
    //        }
    //        _dbContext.SaveChanges();
    //    }
    //}
}
