namespace MyAssienment.Models
{
    public class Cart
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int VehicleId { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
