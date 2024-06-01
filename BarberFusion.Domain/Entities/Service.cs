namespace BarberFusion.Domain.Entities
{
    public class Service
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Guid ShopId { get; set; }
        public Shop Shop { get; set; }
    }
}
