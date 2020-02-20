using Framework.Core.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreData.Users.Entities
{
    public class CardVm: IVM
    {
        public string CardNumber { get; set; }
        public string CardHolderName { get; set; }
        public string Cvv { get; set; }
        public string ExpDate { get; set; }
        public bool IsDefault { get; set; } = false;
        public int UserId { get; set; }
        public string UserName { get; set; }

    }
}
