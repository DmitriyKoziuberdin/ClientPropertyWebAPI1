namespace ClientProperty.ApplicationService.Models.Request
{
    public class UserUpdateRequestModel
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string? Telephone { get; set; }
        public string? Email { get; set; }
    }
}
