namespace ClientProperty.ApplicationService.Models.Request
{
    public class UserRequestModel
    {
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string? Telephone { get; set; }
        public string? Email { get; set; }
    }
}
