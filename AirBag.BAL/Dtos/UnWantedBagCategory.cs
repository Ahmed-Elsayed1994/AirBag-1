using Framework.Core;
using Framework.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreData.Users.Entities
{

    public class UnWantedBagCategoryVm : IVM
    {
        public string Name { get; set; }
        public int bagId { get; set; }
        public int ItemCategoryId { get; set; }
        public string ItemCategoryName { get; set; }
    }
}
