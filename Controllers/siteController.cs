using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using BlockAPI.Connection;
using System.Data;
using BlockAPI.siteModel;

namespace BlockAPI.SiteController
{
    [Route("api/Site")]
    [ApiController]
    public class SiteController : ControllerBase
    {

        [HttpGet]
        public String Get()
        {
            string sql = "SELECT * FROM site";

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
            string sql = "SELECT * FROM site WHERE IdSite = @Id";

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
        public JsonResult Post(Site site)
        {
            string sql = @"INSERT INTO site(ville, adresse, codePostal) VALUES (@ville, @adresse, @codePostal)";

            DataTable table = new DataTable();
            MySqlDataReader myReader;
            MySqlConnection conn = DBConnect.GetDBConnection();

            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@ville", site.ville);
            cmd.Parameters.AddWithValue("@adresse", site.adresse);
            cmd.Parameters.AddWithValue("@codePostal", site.codePostal);


            myReader = cmd.ExecuteReader();
            table.Load(myReader);

            myReader.Close();
            conn.Close();

            return new JsonResult("Added Successfully");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string sql = @"delete from site where IdSite = @Id;";

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
        public JsonResult Put(int id, Site site)
        {
            var sql = @"UPDATE site
                        SET ville = @ville,  
                        adresse = @adresse, 
                        codePostal = @codePostal
                        WHERE IdSite = @Id";

            DataTable table = new DataTable();
            MySqlDataReader myReader;
            MySqlConnection conn = DBConnect.GetDBConnection();

            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@ville", site.ville);
            cmd.Parameters.AddWithValue("@adresse", site.adresse);
            cmd.Parameters.AddWithValue("@codePostal", site.codePostal);

            cmd.Parameters.AddWithValue("@Id", id);

            myReader = cmd.ExecuteReader();
            table.Load(myReader);

            myReader.Close();
            conn.Close();

            return new JsonResult("Updated Successfully");

        }
    }
}