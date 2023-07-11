namespace ClientProperty.ApplicationService.Models.Response
{
    public class UserResponseModel
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string? Telephone { get; set; }
        public string? Email { get; set; }
    }
}
