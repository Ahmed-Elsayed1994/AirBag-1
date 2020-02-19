using Framework.Core.Model;
using System.ComponentModel.DataAnnotations;

namespace RiskManagement.BAL.Models.Common
{
    public class FileVM : IVM
    {
        public int Id { get; set; }
        [Required]
        public string FileName { get; set; }
        public string TableName { get; set; }
        public int RefId { get; set; }
        public string Path { get; set; }
    }
}
