using Framework.Core;
using Framework.Core.Model;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreData.Users.Entities
{
    public class TransactionVm : IVM
    {
        public decimal Cost { get; set; }
        public int UserCardId { get; set; }
        public DateTime DateTime { get; set; }
        public int RequestId { get; set; }
        public virtual CardVm Card { get; set; }
    }
}
