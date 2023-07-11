using Microsoft.AspNetCore.Identity;

namespace ClientProperty.Domain.Entities
{
    public class User : IdentityUser
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string? Telephone { get; set; }
        public double InitialSumOfUserProperty { get; set; }
        public double CurrentSumOfUserProperty { get; set; }
        public List<UserProperty>? UserProperties { get; set; }
    }
}
