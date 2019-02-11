using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;

namespace MusicRecomendations.DAL.interfaces
{
    public interface IRepository<T> where T : class
    {
        bool Create(T t);
        IQueryable<T> Read(params Expression<Func<T, object>>[] includes);

        bool Update(T t);
        bool Delete(T t);
    }
}
