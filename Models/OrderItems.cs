namespace MyAssienment.Models
{
    public class OrderItems
    {
        public int Id { get; set; }
        public int OrderNo { get; set; }
        public int VehicleId { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
