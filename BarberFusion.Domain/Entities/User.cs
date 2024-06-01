namespace BarberFusion.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public List<UserRole> UserRoles { get; set; }
        public Guid ShopId { get; set; }
        public Shop Shop { get; set; }
    }
}
