namespace BarberFusion.Domain.Entities
{
    public class Invoice
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; } = new();
        public DateTime Date { get; set; }
        public List<InvoiceDetail> InvoiceDetails { get; set; } = new();
        public decimal TotalAmount { get; set; }
        public Guid ShopId { get; set; }
        public Shop Shop { get; set; }
    }
}
