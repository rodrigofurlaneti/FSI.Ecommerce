namespace FSI.Ecommerce.Domain.Entities
{
    public class ProductEntity : BaseEntity
    {
        public int IdCategory { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Details { get; set; } = string.Empty;
        public string Picture { get; set; } = string.Empty;
        public int Amount { get; set; } = 0;
        public double ValueOf { get; set; } = 0.00;
        public double ValueFor { get; set; } = 0.00;
        public double Discount { get; set; } = 0.00;
    }
}
