namespace BarberFusion.Application.Models
{
    public class InvoiceDetail
    {
        public Guid Id { get; set; }
        public int ServiceId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
