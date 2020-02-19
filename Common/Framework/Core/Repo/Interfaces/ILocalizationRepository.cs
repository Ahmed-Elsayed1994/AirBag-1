using CoreData.Common.Entities;
using Framework.Core.Model;
using System;
using System.Collections.Generic;

namespace Framework.Core.Repo.Interfaces
{
    public interface ILocalizationRepository : IRepository<Localization>
    {
        IEnumerable<IVM> GetModuleList(string module, Func<Localization, IVM> func);
    }
}
