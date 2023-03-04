using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using BlockAPI.Connection;
using System.Data;
using BlockAPI.employerModel;

namespace BlockAPI.EmployerController
{
    [Route("api/Employer")]
    [ApiController]
    public class EmployerController : ControllerBase
    {

        [HttpGet]
        public String Get()
        {
            string sql = "SELECT * FROM employer";

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
            string sql = "SELECT * FROM employer WHERE IdEmployer = @Id";

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

        [HttpGet("/api/Employer/Site/{site}")]
        public String getBySite(int site)
        {
            string sql = "SELECT * FROM employer WHERE employerSite = @Site";

            DataTable table = new DataTable();
            MySqlDataReader myReader;
            MySqlConnection conn = DBConnect.GetDBConnection();

            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@Site", site);

            myReader = cmd.ExecuteReader();
            table.Load(myReader);

            myReader.Close();
            conn.Close();

            string json = JsonConvert.SerializeObject(table, Formatting.Indented);

            return json;
        }

        [HttpGet("/api/Employer/Service/{service}")]
        public String getByService(int service)
        {
            string sql = "SELECT * FROM employer WHERE employerService = @service";

            DataTable table = new DataTable();
            MySqlDataReader myReader;
            MySqlConnection conn = DBConnect.GetDBConnection();

            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@service", service);

            myReader = cmd.ExecuteReader();
            table.Load(myReader);

            myReader.Close();
            conn.Close();

            string json = JsonConvert.SerializeObject(table, Formatting.Indented);

            return json;
        }

        [HttpGet("/api/Employer/ServiceSite/{service}/{site}")]
        public String getByServiceSite(int service,int site)
        {
            string sql = "SELECT * FROM employer WHERE employerService = @service AND employerSite = @Site";

            DataTable table = new DataTable();
            MySqlDataReader myReader;
            MySqlConnection conn = DBConnect.GetDBConnection();

            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@service", service);
            cmd.Parameters.AddWithValue("@Site", site);

            myReader = cmd.ExecuteReader();
            table.Load(myReader);

            myReader.Close();
            conn.Close();

            string json = JsonConvert.SerializeObject(table, Formatting.Indented);

            return json;
        }

        [HttpPost]
        public JsonResult Post(Employer employer)
        {
            string sql = @"INSERT INTO employer(nom, prenom, fixe, portable, email, employerService, employerSite) 
                            VALUES (@nom, @prenom, @fixe, @portable, @email, @employerService, @employerSite)";

            DataTable table = new DataTable();
            MySqlDataReader myReader;
            MySqlConnection conn = DBConnect.GetDBConnection();

            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@nom", employer.nom);
            cmd.Parameters.AddWithValue("@prenom", employer.prenom);
            cmd.Parameters.AddWithValue("@fixe", employer.fixe);
            cmd.Parameters.AddWithValue("@portable", employer.portable);
            cmd.Parameters.AddWithValue("@email", employer.email);
            cmd.Parameters.AddWithValue("@employerService", employer.employerService);
            cmd.Parameters.AddWithValue("@employerSite", employer.employerSite);

            myReader = cmd.ExecuteReader();
            table.Load(myReader);

            myReader.Close();
            conn.Close();

            return new JsonResult("Added Successfully");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string sql = @"delete from employer where IdEmployer = @Id;";

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
        public JsonResult Put(int id, Employer employer)
        {
            var sql = @"UPDATE employer
                        SET nom = @nom,  
                        prenom = @prenom, 
                        fixe = @fixe, 
                        portable = @portable, 
                        email = @email, 
                        employerService = @employerService, 
                        employerSite = @employerSite
                        WHERE IdEmployer = @Id";

            DataTable table = new DataTable();
            MySqlDataReader myReader;
            MySqlConnection conn = DBConnect.GetDBConnection();

            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@nom", employer.nom);
            cmd.Parameters.AddWithValue("@prenom", employer.prenom);
            cmd.Parameters.AddWithValue("@fixe", employer.fixe);
            cmd.Parameters.AddWithValue("@portable", employer.portable);
            cmd.Parameters.AddWithValue("@email", employer.email);
            cmd.Parameters.AddWithValue("@employerService", employer.employerService);
            cmd.Parameters.AddWithValue("@employerSite", employer.employerSite);
            cmd.Parameters.AddWithValue("@Id", id);

            myReader = cmd.ExecuteReader();
            table.Load(myReader);

            myReader.Close();
            conn.Close();

            return new JsonResult("Updated Successfully");

        }
    }
}