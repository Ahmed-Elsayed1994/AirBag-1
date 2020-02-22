using Framework.Core;
using Framework.Core.Model;
using Framework.Core.Repo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ICtrlPlusDbContext _context;
        private DbSet<T> _entities;
        public IQueryable<T> Table => Entities;
        public Repository(ICtrlPlusDbContext context)
        {
            _context = context;
            //if (_context.Database.EnsureCreated())
            //    _context.Database.Migrate();
        }


        private DbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                {
                    _entities = _context.Set<T>();
                }
                return _entities;
            }
        }

        public async Task<T> GetByIdAsync(object id)
        {
            return await Entities.FindAsync(id);
        }

        public T GetById(object id)
        {
            return Entities.Find(id);
        }

        public void Insert(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                Entities.AddAsync(entity);
                // _context.SaveChanges();
            }
            catch (Exception dbEx)
            {
                throw dbEx;
            }
        }

        public void Insert(IList<T> entities)
        {
            try
            {
                if (entities == null)
                {
                    throw new ArgumentNullException("entity");
                }
                Entities.AddRangeAsync(entities);
                // _context.SaveChanges();
            }
            catch (Exception dbEx)
            {
                throw dbEx;
            }
        }


        public void Update(T updated)
        {
            var ce = _context.Entry<T>(updated);
            if (ce != null)
            {
                if (ce.State == EntityState.Detached)
                {
                    _entities.Attach(updated);
                }
                ce.State = EntityState.Modified;
            }
        }

        public void Delete(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                Entities.Remove(entity);
            }
            catch (Exception dbEx)
            {
                throw dbEx;
            }
        }

        public Task<T> SingleAsync(Expression<Func<T, bool>> predicate, bool track = true)
        {
            return QEntities(track).SingleOrDefaultAsync(predicate);
        }

        protected IQueryable<T> QEntities(bool track = true)
        {
            return track ? Entities : Entities.AsNoTracking();
        }

        public IPagedResult<T, IVM> GetPagedResult(QueryModel queryModel, Func<T, IVM> selectVMFunc)
        {
            var queraleObj = QEntities(true).Where(a=> a.IsDeleted == false);

            IQueryable<T> q = null;
            queryModel.SearchTerm = queryModel.SearchTerm.TrimText();

            if (!queryModel.SearchTerm.IsEmptyOrNull())
                queraleObj = ApplySearch(queraleObj, queryModel);

            if (!queryModel.Sort.IsEmptyOrNull())
                q = ApplySort(queraleObj, queryModel);

            return new PagedResult<T, IVM>(q, queryModel.CurrentPage, queryModel.PageSize, selectVMFunc);
        }

        private IQueryable<T> ApplySearch(IQueryable<T> queraleObj, QueryModel queryModel)
        {
            if (queraleObj is null)
                throw new ArgumentNullException(nameof(queraleObj));

            int lines = 0;

            var mapping = ((DbContext)_context).Model.FindEntityType(typeof(T));
            var tableName = mapping.GetTableName();

            var searchConditions = queryModel.SearchTerm.Split(',');
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append($"SELECT * FROM {tableName} WHERE ");

            foreach (var item in searchConditions)
            {
                var kvPair = item.Split(':');
                var pi = typeof(T).GetProperty(kvPair[0].ToFirstUpper());

                if (lines > 0)
                    stringBuilder.Append(" AND ");

                if (pi.PropertyType == typeof(int))
                    stringBuilder.Append($"{kvPair[0]} = {kvPair[1]}");
                else if (pi.PropertyType == typeof(DateTime))
                    stringBuilder.Append($"cast ([{kvPair[0]}] as date) = '{kvPair[1]}'");
                else
                    stringBuilder.Append($"{kvPair[0]} LIKE '%{kvPair[1]}%'");

                lines++;
            }
            stringBuilder.Append(" AND IsDeleted = 0");
            return _context.Set<T>().FromSqlRaw(stringBuilder.ToString());
        }

        private IQueryable<T> ApplySort(IQueryable<T> queraleObj, QueryModel queryModel)
        {
            queryModel.Sort = queryModel.Sort.ToFirstUpper();
            var pi = typeof(T).GetProperty(queryModel.Sort);
            if (pi != null)
            {
                var arza3 = queraleObj.Where(a => a.IsDeleted == false);
                return queryModel.SortDirection == "des" ?
                               arza3.AsEnumerable().OrderByDescending(x => pi.GetValue(x)).AsQueryable()
                                :
                                arza3.AsEnumerable().OrderBy(x => pi.GetValue(x)).AsQueryable();
            }
            return queraleObj.Where(a => a.IsDeleted == false).OrderByDescending(x => x.Id);
        }

        public T Single(Expression<Func<T, bool>> predicate, bool track = true)
        {
            return QEntities(track).SingleOrDefault(predicate);
        }
        public ICollection<T> Where(Expression<Func<T, bool>> predicate, bool track = true)
        {
            return QEntities(track).Where(predicate).ToList();
        }
        //public async Task<T> GetById(object id)
        //{
        //    return await Entities.FindAsync(id);
        //}

        public IQueryable<T> GetAll()
        {
            return  Entities.Where(a => a.IsDeleted == false); ;
        }

        
    }
}