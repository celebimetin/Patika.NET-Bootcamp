using Core.Model;

namespace Data.Domain
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Picture { get; set; }
        public string Description { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}