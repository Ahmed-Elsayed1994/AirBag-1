using Framework.Basic;
using Framework.Core.Model;
using Framework.Core.Repo;
using Framework.Core.Repo.Interfaces;
using System.Threading.Tasks;

namespace Framework.Core.UOW
{
    public interface IUnitOfWork
    {
        IUsersRepository Users { get; }

        SaveResult SaveResult { get;  }
        void Dispose();
        Task<int> Save();
        void AddError(int code, string error);
        void AddError(Error error);
    }
}