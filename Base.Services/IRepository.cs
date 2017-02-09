using Base.Models;
using Base.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Services
{
    public interface IRepository<T> where T : EntityBase
    {
        List<User> GetAll();

        IQueryable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate);

        void Save(T entity);

        void Delete(Int64 key);
    }
}
