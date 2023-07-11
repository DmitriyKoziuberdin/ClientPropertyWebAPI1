namespace ClientProperty.Domain.Entities
{
    public class UserProperty
    {
        public long UserId { get; set; }
        public User? User { get; set; }
        public long PropertyId { get; set; }
        public Property? Property { get; set; }
    }
}
