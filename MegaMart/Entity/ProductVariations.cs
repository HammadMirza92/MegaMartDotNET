using MegaMart.Entity.EntitesBase;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace MegaMart.Entity
{
    public class ProductVariations : BaseEntity
    {
        public Guid ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }
        public ICollection<VariationOptions> Options { get; set; }


    }
}
