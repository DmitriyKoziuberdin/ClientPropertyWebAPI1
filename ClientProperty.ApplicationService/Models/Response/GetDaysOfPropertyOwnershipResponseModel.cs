namespace ClientProperty.ApplicationService.Models.Response
{
    public class GetDaysOfPropertyOwnershipResponseModel
    {
        public long Id { get; set; }
        public string? Name { get; set; }    
        public int DaysOfPropertyOwnership { get; set; }
    }
}
