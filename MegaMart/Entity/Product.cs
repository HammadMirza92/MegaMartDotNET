using MegaMart.Entity.EntitesBase;
using MegaMart.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MegaMart.Entity
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public string Image { get; set; }
        public double? Price { get; set; }
        public int? Quantity { get; set; }
        public int? Stock { get; set; }
        public ProductType ProductType { get; set; }
        public Guid CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }
        public ICollection<ProductVariations> Variations { get; set; }

    }
}
