using System.Text.Json.Serialization;

namespace BarberFusion.Domain.Entities
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
                  
        public Guid ShopId { get; set; }
        [JsonIgnore]
        public Shop Shop { get; set; } 

        [JsonIgnore]
        public List<Invoice> Invoices { get; set; }
        [JsonIgnore]
        public List<Appointment> Appointments { get; set; } 
    }
}
