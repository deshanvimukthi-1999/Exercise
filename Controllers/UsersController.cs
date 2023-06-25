using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MyAssienment.Models;



namespace MyAssienment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public UsersController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route ('registration')]

        public Response register (Users users)
        {
            Response response = new Response ();
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
        [Route("viewUsers")]

        public Response viewUsers(Users users)
        {
            DAL dAL=new DAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("MyDataCS").ToString());
            Response response = dAL.viewUsers(users, connection);
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

        
    }

}
