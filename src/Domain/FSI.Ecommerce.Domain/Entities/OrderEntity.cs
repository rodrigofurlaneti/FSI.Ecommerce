namespace FSI.Ecommerce.Domain.Entities
{
    public class OrderEntity : BaseEntity
    {
        public int IdCommand { get; set; } = 0;
        public int IdProduct { get; set; } = 0;
        public int Quantity { get; set; } = 0;
        public double ValueOf { get; set; } = 0.00;
        public double ValueFor { get; set; } = 0.00;
        public double Discount { get; set; } = 0.00;

    }
}
