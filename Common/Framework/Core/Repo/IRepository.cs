using Framework.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Framework.Core.Repo
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> SingleAsync(Expression<Func<T, bool>> predicate, bool track = true);

        Task<T> GetByIdAsync(object id);

        T Single(Expression<Func<T, bool>> predicate, bool track = true);

        T GetById(object id);

        void Insert(T entity);
        void Insert(IList<T> entities);
        void Update(T entity);

        void Delete(T entity);
        IQueryable<T> GetAll();

        IPagedResult<T, IVM> GetPagedResult(QueryModel queryModel, Func<T, IVM> func);
        IQueryable<T> Table { get; }
        ICollection<T> Where(Expression<Func<T, bool>> predicate, bool track = true);
    }
}