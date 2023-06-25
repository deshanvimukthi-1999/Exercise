namespace MyAssienment.Models
{
    public class Response
    {
        public int StatuesCode { get; set; }
        public string StatuesMessage { get; set; }
        public List <Users> listUsers { get; set; }
        public Users user { get; set; }
        public List<Vehicles> listVehicles { get; set; }
        public Vehicles vehicle{ get; set; }
        public List<Cart> carts { get; set; }
        public Cart cart { get; set; }
        public List<Orders> listOrders { get; set; }
        public Orders order { get; set; }
        public List<OrderItems> listItems { get; set; }
        public OrderItems orderItem { get; set; }


    }
}
