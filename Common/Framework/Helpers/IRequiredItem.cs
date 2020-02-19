using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Helpers
{
    public interface IRequiredItem
    {
        IList<SelectListItem> GetItems();
    }
}
