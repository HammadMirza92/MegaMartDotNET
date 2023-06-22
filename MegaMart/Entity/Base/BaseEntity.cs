namespace MegaMart.Entity.EntitesBase
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
        public Boolean IsDeleted { get; set; }
    }
}
