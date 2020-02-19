using Framework.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CoreData.Users.Entities
{
   
   public class Card: BaseEntity
    {

        public string CardNumber { get; set; }
        public string CardHolderName { get; set; }
        public string Cvv { get; set; }
        public string ExpDate { get; set; }
        public bool IsDefault { get; set; } = false;
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

    }
}
