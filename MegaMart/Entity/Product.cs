using MegaMart.Entity.EntitesBase;
using System.ComponentModel.DataAnnotations;


namespace MegaMart.Entity
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; }
    }
}
