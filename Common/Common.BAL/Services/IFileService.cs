using CoreData.RiskManagement.Common;
using Framework.Core;
using Framework.Core.UOW;
using RiskManagement.BAL.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiskManagement.BAL.Services.Common
{
    public interface IFileService : IBaseService<File, FileVM>
    {
       IList<FileVM> GetFileByrefId(int refId, string tableName);
        IList<FileVM> GetFiles(IList<FileVM> report, int reportId, string TableName);
    }
}
