namespace FSI.Ecommerce.Domain.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime DateInsert { get; set; }
        public DateTime DateUpdate { get; set; }
        public bool Status { get; set; }
    }
}
