namespace ClientProperty.ApplicationService.Models.Response
{
    public class GetCurrentPeriodResponseModel
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public double CurrentValue { get; set; }
    }
}
