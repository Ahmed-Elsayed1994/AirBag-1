using Framework.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreData.Users.Entities
{

    public class UnWantedBagCategory : BaseEntity
    {
        public string Name { get; set; }
        public int bagId { get; set; }
        public int ItemCategoryId { get; set; }
        [ForeignKey("bagId")]

        public virtual Bag Bag { get; set; }
        [ForeignKey("ItemCategoryId")]

        public virtual ItemCategory ItemCategory { get; set; }
    }
}
