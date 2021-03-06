
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    public interface IEntityRespiratory<T> where T:class,IEntity,new()
    {
        void Add(T item);
        void Delete(T item);
        void Update(T item);
       

        List<T> GetAll(Expression<Func<T,bool>> filer = null);
        T Get(Expression<Func<T, bool>> filter);
    }
}
