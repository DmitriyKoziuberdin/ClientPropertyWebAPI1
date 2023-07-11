namespace ClientProperty.Domain.Entities
{
    public class Property
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string TypeOfProperty { get; set; } = null!;
        public DateTime PurchaseDate { get; set; }
        public double InitialValue { get; set; }
        public string? PriceLossPeriod { get; set; }
        public double PriceLossSelectedPeriod { get; set; }
        public double CurrentValue { get; set; }
        public int DaysOfPropertyOwnership { get; set; }
        public List<UserProperty>? UserProperties { get; set; }
    }
}
