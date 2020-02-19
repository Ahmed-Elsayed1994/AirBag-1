using CoreData.RiskManagement.Common;
using Framework.Core;
using Framework.Core.BaseModel;
using Framework.Core.Model;
using Framework.Core.Repo;
using Framework.Core.UOW;
using Microsoft.AspNetCore.Http;
using RiskManagement.BAL.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiskManagement.BAL.Services.Common
{
    public class FileService :  BaseService<File , FileVM>, IFileService 
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public FileService(IRepository<File> repository, IUnitOfWork unitOfWork,
            IHttpContextAccessor httpContextAccessor)
        :base(repository, unitOfWork){
            _httpContextAccessor = httpContextAccessor;
        }

        private string GetPath(string fileName)
        {
            return _httpContextAccessor.HttpContext.Request.Scheme + "://" + _httpContextAccessor.HttpContext.Request.Host.Value + "/Files/" + fileName;

        }

        public IList<FileVM> GetFileByrefId(int refId, string tableName)
        {
            IList<FileVM> fileVMs = new List<FileVM>();
            var file = _repository.Where(a => a.RefId == refId && a.TableName.ToLower() == tableName.ToLower());
            if (file == null)
                return null;
            else
            {
                foreach (var item in file)
                {
                    fileVMs.Add(new FileVM()
                    {
                        Id = item.Id,
                        FileName = item.FileName,
                        Path = GetPath(item.FileName),
                        RefId = item.RefId,
                        TableName = item.TableName
                    });
                }
            }
            return fileVMs;
        }
        public IList<FileVM> GetFiles(IList<FileVM> files, int reportId, string TableName)
        {
            IList<FileVM> fileVMs = new List<FileVM>();
            if (files == null || files.Count == 0)
                return null;
            foreach (var item in files)
            {
                fileVMs.Add(new FileVM()
                {
                    Id = item.Id,
                    FileName = item.FileName,
                    TableName = TableName,
                    RefId = reportId,
                });
            }
            return fileVMs;
        }
        public override FileVM MapEntityToModel(File entity)
        {
            if (entity == null)
                return null;
            return new FileVM()
            {
                FileName = entity.FileName,
                Id = entity.Id,
                RefId = entity.RefId,
                TableName = entity.TableName
            };
        }

        public override File MapModelToEntity(FileVM model)
        {
            if (model == null)
                return null;
            var file = _repository.GetById(model.Id);
            if (file == null)
                return new File()
                {
                    FileName = model.FileName,
                    RefId = model.RefId,
                    TableName = model.TableName
                };
            file.TableName = model.TableName;
            file.RefId = model.RefId;
            file.FileName = model.FileName;
            return file;
        }

        protected override Func<File, IVM> FuncToVM()
        {
            return (a) => new FileVM()
            {
                Id = a.Id,
                FileName = a.FileName,
                RefId = a.RefId,
                TableName = a.TableName,
                Path = GetPath(a.FileName)
            };
        }
    }
}
