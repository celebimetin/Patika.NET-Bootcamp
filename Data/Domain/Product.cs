using Core.Model;

namespace Data.Domain
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public string Description { get; set; }
        public bool IsStatus { get; set; }
        public virtual List<Category> Categories { get; set; }
    }
}