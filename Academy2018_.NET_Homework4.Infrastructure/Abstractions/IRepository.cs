using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Academy2018_.NET_Homework4.Infrastructure.Abstractions
{
    public interface IRepository<TEntity> 
        where TEntity: class
    {
        IEnumerable<TEntity> Get();

        object Create(TEntity entity);

        void Update(object id, TEntity entity);

        void Delete(object id);

        void Delete(TEntity entity);

        bool IsExist(object id);
    }
}
