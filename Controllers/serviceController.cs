using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using BlockAPI.Connection;
using System.Data;
using BlockAPI.serviceModel;

namespace BlockAPI.ServiceController
{
    [Route("api/Service")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public ServiceController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public String Get()
        {
            string sql = "SELECT * FROM service";

            DataTable table = new DataTable();
            MySqlDataReader myReader;
            MySqlConnection conn = DBConnect.GetDBConnection();

            conn.Open();

            MySqlCommand cmd = new MySqlCommand(sql, conn);

            myReader = cmd.ExecuteReader();

            table.Load(myReader);

            myReader.Close();
            conn.Close();

            string json = JsonConvert.SerializeObject(table, Formatting.Indented);

            return json;
        }


        [HttpGet("{id}")]
        public String GetById(int id)
        {
            string sql = "SELECT * FROM service WHERE IdService = @Id";

            DataTable table = new DataTable();
            MySqlDataReader myReader;
            MySqlConnection conn = DBConnect.GetDBConnection();

            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@Id", id);

            myReader = cmd.ExecuteReader();
            table.Load(myReader);

            myReader.Close();
            conn.Close();

            string json = JsonConvert.SerializeObject(table, Formatting.Indented);

            return json;
        }

        [HttpPost]
        public JsonResult Post(Service service)
        {
            string sql = @"INSERT INTO service(nomService) VALUES (@nomService)";

            DataTable table = new DataTable();
            MySqlDataReader myReader;
            MySqlConnection conn = DBConnect.GetDBConnection();

            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@ville", service.nomService);


            myReader = cmd.ExecuteReader();
            table.Load(myReader);

            myReader.Close();
            conn.Close();

            return new JsonResult("Added Successfully");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string sql = @"delete from service where IdService = @Id;";

            DataTable table = new DataTable();
            MySqlDataReader myReader;
            MySqlConnection conn = DBConnect.GetDBConnection();

            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@Id", id);

            myReader = cmd.ExecuteReader();
            table.Load(myReader);

            myReader.Close();
            conn.Close();

            return new JsonResult("Deleted Successfully");
        }

        [HttpPut("{id}")]
        public JsonResult Put(int id, Service service)
        {
            var sql = @"UPDATE service SET nomService = @nomService WHERE IdService = @Id";

            DataTable table = new DataTable();
            MySqlDataReader myReader;
            MySqlConnection conn = DBConnect.GetDBConnection();

            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@ville", service.nomService);
            cmd.Parameters.AddWithValue("@Id", id);

            myReader = cmd.ExecuteReader();
            table.Load(myReader);

            myReader.Close();
            conn.Close();

            return new JsonResult("Updated Successfully");

        }
    }
}