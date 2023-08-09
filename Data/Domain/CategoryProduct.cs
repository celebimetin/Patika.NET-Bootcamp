using Core.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Domain
{
    [NotMapped]
    public class CategoryProduct : BaseEntity
    {
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}