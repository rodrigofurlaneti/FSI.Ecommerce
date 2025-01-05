namespace FSI.Ecommerce.Domain.Entities
{
    public class PropertyEntity : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Picture { get; set; } = string.Empty;
        public string Enterprise { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Details { get; set; } = string.Empty;
        public int Deadline { get; set; }
        public int NumberOfShares { get; set; }
        public int SharesAvailable { get; set; }
        public int SharesNotAvailable { get; set; }
        public double ValueByShares { get; set; }
        public double ExpectedValue { get; set; }
        public double Profitability { get; set; }
        public double ProjectedProfitability { get; set; }
        public double Minimum { get; set; }
        public double Maximum { get; set; }
        public bool WorksStarted { get; set; }
        public double PercentageOfWorks { get; set; }
    }
}
