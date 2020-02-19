using Framework.Core;

namespace CoreData.Common.Entities
{
    public class Localization : BaseEntity
    {
        public string LKey { get; set; }
        public string Value { get; set; }
        public string Module { get; set; }
        public string Culture { get; set; }
    }
}
