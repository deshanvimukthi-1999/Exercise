using Microsoft.Data.SqlClient;
using System.Data;

namespace MyAssienment.Models
{
    public class DAL
    {
        public Response register(Users users, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("sp_register", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FirstName", users.FirstName);
            cmd.Parameters.AddWithValue("@LastName", users.LastName);
            cmd.Parameters.AddWithValue("@Password", users.Password);
            cmd.Parameters.AddWithValue("@Email", users.Email);
            cmd.Parameters.AddWithValue("@Type", "Users");
            cmd.Parameters.AddWithValue("@Type", "Pending");
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if(i >0)
            {
                response.StatuesCode = 200;
                response.StatuesMessage = "User register successfully";
            }
            else
            {
                response.StatuesCode = 100;
                response.StatuesMessage = "User register failed";
            }
            return response;




        }

        public Response login(Users users, SqlConnection connection)
        {
            SqlDataAdapter adapter = new SqlDataAdapter("sp_login", connection);
            adapter.SelectCommand.CommandType =  CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@Email", users.Email);
            adapter.SelectCommand.Parameters.AddWithValue("@Password", users.Password);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            Response response = new Response(); 
            Users user = new Users();
            if(dt.Rows.Count > 0)
            {
                user.Id = Convert.ToInt32(dt.Rows[0]["ID"]);
                user.FirstName = Convert.ToString(dt.Rows[0]["FirstName"]);
                user.LastName = Convert.ToString(dt.Rows[0]["LastName"]);
                user.Email = Convert.ToString(dt.Rows[0]["Email"]);
                user.Type = Convert.ToString(dt.Rows[0]["Type"]);
                response.StatuesCode = 200;
                response.StatuesMessage = "User is Valid";
                response.user = user;
            }
            else
            {
                response.StatuesCode = 100;
                response.StatuesMessage = "User is InValid";
                response.user = null;
            }
            return response;

        }

        public Response viewUsers(Users users, SqlConnection connection) 
        {
            SqlDataAdapter adapter = new SqlDataAdapter("p_viewer", connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@ID", users.Id);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            Response response = new Response();
            Users user = new Users();
            if (dt.Rows.Count > 0) 
            {
                user.Id = Convert.ToInt32(dt.Rows[0]["ID"]);
                user.FirstName = Convert.ToString(dt.Rows[0]["FirstName"]);
                user.LastName = Convert.ToString(dt.Rows[0]["LastName"]);
                user.Email = Convert.ToString(dt.Rows[0]["Email"]);
                user.Type = Convert.ToString(dt.Rows[0]["Type"]);
                user.CreatedOn = Convert.ToDateTime(dt.Rows[0]["CreatedOn"]);
                user.Password = Convert.ToString(dt.Rows[0]["Password"]);
                response.StatuesCode = 200;
                response.StatuesMessage = "User exits";
                response.user = user;
            }
            else
            {
                response.StatuesCode = 100;
                response.StatuesMessage = "User doesn't exit";
                response.user = user;
            }
            return response;
        }

        public Response updateProfile(Users users, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("sp_update", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FirstName", users.FirstName);
            cmd.Parameters.AddWithValue("@LastName", users.LastName);
            cmd.Parameters.AddWithValue("@Password", users.Password);
            cmd.Parameters.AddWithValue("@Email", users.Email);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatuesCode = 200;
                response.StatuesMessage = "Record updated successfully";
            }
            else
            {
                response.StatuesCode = 100;
                response.StatuesMessage = "Record update failed";
            }
            return response;
        }
        public Response addToCart(Cart cart, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("sp_Add", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@User Id", cart.UserId);
            cmd.Parameters.AddWithValue("@VehicleId", cart.VehicleId);
            cmd.Parameters.AddWithValue("@TotalPrice", cart.TotalPrice);
            cmd.Parameters.AddWithValue("@User Id", cart.UserId);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatuesCode = 200;
                response.StatuesMessage = "Add vehicle to cart";
            }
            else
            {
                response.StatuesCode = 100;
                response.StatuesMessage = "Invalid Input";
            }
            return response;

        }
        public Response placeOrder(Users users, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("sp_PlaceOrder", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", users.Id);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatuesCode = 200;
                response.StatuesMessage = "Order has been placed successfully";
            }
            else
            {
                response.StatuesCode = 100;
                response.StatuesMessage = "Order has been placed unsuccessfully";
            }
            return response;

        }
        public Response orderList(Users users, SqlConnection connection)
        {
            Response response = new Response();
            List<Orders> listorder = new List<Orders>();
            SqlDataAdapter da= new SqlDataAdapter("sp_OrderList", connection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@Type", users.Type);
            da.SelectCommand.Parameters.AddWithValue("@ID", users.Id);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for(int i=0; i<dt.Rows.Count; i++)
                {
                    Orders order = new Orders();
                    order.Id = Convert.ToInt32(dt.Rows[1]["ID"]);
                    order.OrderNo = Convert.ToString(dt.Rows[1]["OrderNo"]);
                    order.OrderTotal = Convert.ToDecimal(dt.Rows[1]["OrderTotal"]);
                    order.OrderStatus = Convert.ToString(dt.Rows[1]["OrderStatus"]);
                    listorder.Add(order);
                }
                if(listorder.Count > 0)
                {
                    response.StatuesCode = 200;
                    response.StatuesMessage = "Order Details Fetched";
                    response.listOrders = listorder;
                }
                else
                {
                    response.StatuesCode = 100;
                    response.StatuesMessage = "Order Details are not Fetched";
                    response.listOrders = null;
                }

            }
            else
            {
                response.StatuesCode = 100;
                response.StatuesMessage = "Order Details are not Fetched";
                response.listOrders = null;
            }
            return response;
          
        }
        public Response addUpdateVehicles(Vehicles vehicles, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("sp_AddUpdateVehicles", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", vehicles.Name);
            cmd.Parameters.AddWithValue("@Type", vehicles.Type);
            cmd.Parameters.AddWithValue("@Price", vehicles.Price);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatuesCode = 200;
                response.StatuesMessage = "Vehicle Inserted successfully";
            }
            else
            {
                response.StatuesCode = 100;
                response.StatuesMessage = "Vehicle Insert failed";
            }
            return response;

        }
        public Response userList(SqlConnection connection)
        {
            Response response = new Response();
            List<Users> listusers = new List<Users>();
            SqlDataAdapter da = new SqlDataAdapter("sp_UserList", connection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Users user= new Users();
                    user.Id = Convert.ToInt32(dt.Rows[1]["ID"]);
                    user.FirstName = Convert.ToString(dt.Rows[1]["FirstName"]);
                    user.LastName = Convert.ToString(dt.Rows[1]["LastName"]);
                    user.Password= Convert.ToString(dt.Rows[1]["Password"]);
                    user.Email = Convert.ToString(dt.Rows[1]["Email"]);
                    user.Statues = Convert.ToInt32(dt.Rows[1]["Statues"]);
                    user.CreatedOn = Convert.ToDateTime(dt.Rows[1]["CreatedOn"]);


                    listusers.Add(user);
                }
                if (listusers.Count > 0)
                {
                    response.StatuesCode = 200;
                    response.StatuesMessage = "User Details Fetched";
                    response.listUsers = listusers;
                }
                else
                {
                    response.StatuesCode = 100;
                    response.StatuesMessage = "User Details are not Fetched";
                    response.listUsers = null;
                }

            }
            else
            {
                response.StatuesCode = 100;
                response.StatuesMessage = "User Details are not Fetched";
                response.listUsers = null;
            }
            return response;

        }
    }
}
