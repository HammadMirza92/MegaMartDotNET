using MegaMart.Entity.EntitesBase;
using System.ComponentModel.DataAnnotations.Schema;

namespace MegaMart.Entity
{
    public class ProductAttribute : BaseEntity
    {
        public string Values { get; set; }
        public Guid ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }
        public Guid AttributeId { get; set; }
        [ForeignKey(nameof(AttributeId))]
        public VariationAttribute Attribute { get; set; }
    }
}
