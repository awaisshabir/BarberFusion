namespace BarberFusion.Domain.Entities
{
    public class Role
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<UserRole> UserRoles { get; set; }

        public Guid ShopId { get; set; }
        public Shop Shop { get; set; }
    }
}
