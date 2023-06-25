using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MyAssienment.Models;

namespace MyAssienment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AdminController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("addUpdateVehicles")]

        public Response addUpdateVehicles(Vehicles vehicles)
        {
            DAL dAL = new DAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("MyDataCS").ToString());
            Response response = dAL.addUpdateVehicles(vehicles, connection);
            return response;

        }

        [HttpPost]
        [Route('registration')]

        public Response register(Users users)
        {
            Response response = new Response();
            DAL dAL = new DAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("MyDataCS").ToString());
            response = dAL.register(users, connection);
            return response;
        }

        [HttpPost]
        [Route("login")]

        public Response login(Users users)
        {
            DAL dAL = new DAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("MyDataCS").ToString());
            Response response = dAL.login(users, connection);
            return response;
        }


        [HttpPost]
        [Route("updateProfile")]

        public Response UpdateProfile(Users users)
        {
            DAL dAL = new DAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("MyDataCS").ToString());
            Response response = dAL.updateProfile(users, connection);
            return response;

        }

        [HttpGet]
        [Route("userList")]

        public Response userList()
        {
            DAL dAL = new DAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("MyDataCS").ToString());
            Response response = dAL.userList(connection);
            return response;

        }



    }

}
