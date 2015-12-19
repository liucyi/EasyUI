
using EasyUI.Liuy.Domain.Abstract.IRepository;
using EasyUI.Liuy.Domain.Repostory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyUI.Liuy.Domain.Service
{
    public abstract class BaseService<T> where T : class,new()
    {
        //在调用这个方法的时候必须给他赋值
        public IRepository<T> CurrentRepository { get; set; }



        //基类的构造函数
        public BaseService()
        {
            SetCurrentRepository();  //构造函数里面调用了此设置当前仓储的抽象方法
        }

        //构造方法实现赋值 
        public abstract void SetCurrentRepository();  //约束子类必须实现这个抽象方法

        //添加
        public void Add(T entity)
        {
            //如果在这里操作多个表的话，实现批量的操作
            //调用T对应的仓储来添加
            CurrentRepository.Add(entity);
        }

        //修改
        public void Update(T entity)
        {
            CurrentRepository.Update(entity);


        }

        public T FindById(object id)
        {
            return CurrentRepository.FindById(id);
        }

        public void Delete(T entity)
        {
            CurrentRepository.Delete(entity);

        }


        //查询
        public IQueryable<T> Search(Func<T, bool> wherelambda)
        {
            return CurrentRepository.Search(wherelambda);
        }


        //分页
        public IQueryable<T> GetPagedList<S>(int pageSize, int pageIndex,
             out int total, Func<T, bool> whereLambda, string isAsc, Func<T, S> orderByLambda)
        {
            return CurrentRepository.GetPagedList(pageSize, pageIndex, out total, whereLambda, isAsc, orderByLambda);
        }


    }
}
