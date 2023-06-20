using MegaMart.Entity.EntitesBase;
using System.ComponentModel.DataAnnotations.Schema;

namespace MegaMart.Entity
{
    public class Category :BaseEntity
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public Guid? ParentCategoryId { get; set; }
        [ForeignKey(nameof(ParentCategoryId))]
        public Category? ParentCategory { get; set; }

        public ICollection<Product> Products { get; set; }

    }
}
