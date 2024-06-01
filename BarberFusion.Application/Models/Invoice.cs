namespace BarberFusion.Application.Models
{
    public class Invoice
    {
        public Guid Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime Date { get; set; }
        public List<InvoiceDetail> InvoiceDetails { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
