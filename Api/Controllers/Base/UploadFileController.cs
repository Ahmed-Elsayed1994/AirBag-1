using Framework.Core.UOW;
using Framework.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RiskManagement.BAL.Models.Common;
using RiskManagement.BAL.Services.Common;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadFileController : CommonController
    {

        private readonly IImageUpload _imageUpload;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IWebHostEnvironment _host;
        private readonly IFileService _fileService;
        private readonly IUnitOfWork unitOfWork;
        public UploadFileController(IImageUpload imageUpload,
            IHttpContextAccessor httpContextAccessor,
            IWebHostEnvironment host,
            IFileService fileService,
            IUnitOfWork unitOfWork
            )
        {
            _imageUpload = imageUpload;
            _httpContextAccessor = httpContextAccessor;
            _host = host;
            _fileService = fileService;
            this.unitOfWork = unitOfWork;
        }
        [HttpPost]
        [Route("Upload")]
        public async Task<IActionResult> UploadFile()
        {

            if (!Request.HasFormContentType)
                return BadRequest();

            var file = Request.Form.Files[0];
            if (file == null || file.Length == 0)
                return Content("file not selected");
            var te = _httpContextAccessor.HttpContext.Request.Host;

            var path = Path.Combine(
                        _host.WebRootPath, "Files");
            var fileName =await _imageUpload.UploadFile(path, file);
            //var que = new QuestionFileVM()
            //{
            //    URL = path,
            //    FileName = fileName
            //};
          
            return Ok(new FileVM()
            {
                FileName = fileName
            });
        }
        [HttpPost]
        [Route("Download")]
        public async Task<IActionResult> Download(string filename)
        {
            if (filename == null)
                return Content("filename not present");

            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot", filename);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));
        }
        [NonAction]
        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }
        [NonAction]
        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformatsofficedocument.spreadsheetml.sheet"},  
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };
        }
        [HttpPost]
        [Route("SaveFile")]
        public async Task<IActionResult> SaveFile([FromBody]FileVM fileVM)
        {
            _fileService.Insert(fileVM);

            if (unitOfWork.SaveResult.Errors.Count == 0)
                await unitOfWork.Save();

            return unitOfWork.SaveResult.Affected > 0 ? ResCreateOk(unitOfWork.SaveResult) : ResCreateServerError(unitOfWork.SaveResult);
        }
    }
}
