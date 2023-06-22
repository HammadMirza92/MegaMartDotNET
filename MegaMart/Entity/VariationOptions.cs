using MegaMart.Entity.EntitesBase;
using MegaMart.Enums;
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
        public string SKU { get; set; }
        public double? Price { get; set; }
        public double? SalePrice { get; set; }
        public int? Stock { get; set; }
        public int? StockQuantity { get; set; }
        public StockStatus StockStatus { get; set; }
    }
}
