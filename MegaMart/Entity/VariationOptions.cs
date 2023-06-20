using MegaMart.Entity.EntitesBase;
using System.ComponentModel.DataAnnotations.Schema;

namespace MegaMart.Entity
{
    public class VariationOptions : BaseEntity
    {
        public string Name { get; set; }
        public string Option { get; set; }
        public Guid VariationAttributeId{ get; set; }
        [ForeignKey(nameof(VariationAttributeId))]
        public ProductVariations VariationAttribute { get; set; }
        public int StockQuantity { get; set; }
        public double Price { get; set; }
    }
}
