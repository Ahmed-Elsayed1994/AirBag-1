using Framework.Core.Model;
using Framework.Helpers;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Framework.Core.UOW
{
    public interface IBusiness<T, TVM> where T : BaseEntity where TVM : IVM
    {
        IVM GetSingle(Expression<Func<T, bool>> expression);
        IVM GetById(int id);
        T Insert(TVM entity);
        void InsertAll(IList<TVM> model);
        void Update(TVM entity);
        void Delete(TVM entity);
        IPagedResult<T, IVM> GetPagedResult(QueryModel queryModel);
        T GetEntity(Expression<Func<T, bool>> expression);
        T GetEntityById(int id);
        IList<SelectListItem> GetCreateItems();
        RequiredUpdateVM<TVM> GetUpdateItems(int id);
        ICollection<T> GetAll();
        Task<ICollection<T>> GetAllAsync();
    }
}