using Framework.Basic;
using Framework.Core;
using Framework.Core.Model;
using Framework.Core.Repo;
using Framework.Core.Repo.Interfaces;
using Framework.Core.UOW;
using Persistence.Repositories;
using System;
using System.Threading.Tasks;

namespace Persistence.UnitOfWork
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private ICtrlPlusDbContext context;
        private bool disposed = false;
        public SaveResult SaveResult { get; set; }

        public UnitOfWork(ICtrlPlusDbContext _context)
        {
            context = _context;
            SaveResult = new SaveResult();
        }

        #region repositories

        #region fields
        private IUsersRepository _usersRepository;
        #endregion

        #region Properties
        public IUsersRepository Users => _usersRepository = _usersRepository ?? new UsersRepository(context);
        #endregion

        #endregion

        public async Task<int> Save()
        {
            int returnNum = 0;
            try
            {
                returnNum = await context.SaveChangesAsync();
                SaveResult.Affected = returnNum;
                return returnNum;
            }
            catch (Exception e)
            {
                AddError(new Error(500, e.Message.ToString()));
            }
            return returnNum;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void AddError(int code, string error)
        {
            SaveResult.Errors.Add(new Error(code, error));
        }
        public void AddError(Error error)
        {
            SaveResult.Errors.Add(error);
        }
    }
}
