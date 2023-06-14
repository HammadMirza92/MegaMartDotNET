using MegaMart.Entity.EntitesBase;

namespace MegaMart.Entity
{
    public class VariationAttribute : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<ProductAttribute> ProductAttributes { get; set; }
    }
}
