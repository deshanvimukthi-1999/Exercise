using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MyAssienment.Models;

namespace MyAssienment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public VehiclesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("addToCart")]

        public Response addToCart(Cart cart)
        {
           
            DAL dAL = new DAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("MyDataCS").ToString());
            Response response = dAL.addToCart(cart, connection);
            return response;

        }

        [HttpPost]
        [Route("placeOrder")]

        public Response placeOrder(Users users)
        {

            DAL dAL = new DAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("MyDataCS").ToString());
            Response response = dAL.placeOrder(users, connection);
            return response;

        }

        [HttpPost]
        [Route("orderList")]

        public Response orderList(Users users)
        {

            DAL dAL = new DAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("MyDataCS").ToString());
            Response response = dAL.orderList(users, connection);
            return response;

        }
    }
}
