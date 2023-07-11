namespace ClientProperty.ApplicationService.Models.Request
{
    public class PropertyUpdateRequestModel
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string TypeOfProperty { get; set; } = null!;
        public DateTime PurchaseDate { get; set; }
        public double InitialValue { get; set; }
        public double PriceLossSelectedPeriod { get; set; }
    }
}
