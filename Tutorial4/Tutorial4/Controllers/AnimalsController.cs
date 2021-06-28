using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Tutorial4.Models;

namespace Tutorial4.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private const string dataString = "Data Source=db-mssql;Initial Catalog=s20985;Integrated Security=True";
 
        [HttpGet]
        public IActionResult GetAnimals(string sortOrder)
        {

            var animals = new List<Animal>();
            using (var con = new SqlConnection(dataString))
            {
                using (var com = new SqlCommand())
                {
                    com.Connection = con;

                    if (sortOrder != null)
                        com.CommandText = "Select * from animal order by "+ sortOrder + " ";                    
                    else
                        com.CommandText = "select * from animal order by name";

                    con.Open();
                    var dr = com.ExecuteReader();
                    while (dr.Read())
                    {
                        var animal = new Animal
                        {
                            IdAnimal = (int)dr["IdAnimal"],
                            Name = dr["Name"].ToString(),
                            Description = dr["Description"].ToString(),
                            Category = dr["Category"].ToString(),
                            Area = dr["Area"].ToString()
                        };
                        animals.Add(animal);
                    }
                }
                return Ok(animals);
            }            
        }
        [HttpPost]
        public IActionResult addAnimal(Animal animal)
        {
            using (var con = new SqlConnection(dataString))
            {
                using (var com = new SqlCommand())
                {
                    com.Connection = con; 
                    com.CommandText = "insert into Animal(Name, Description, Category, Area) " +
                        "Values( @Name, @Description, @Category, @Area)";
          
                    com.Parameters.AddWithValue("@Name", animal.Name);
                    com.Parameters.AddWithValue("@Description", animal.Description);
                    com.Parameters.AddWithValue("@Category", animal.Category);
                    com.Parameters.AddWithValue("@Area", animal.Area);

                    con.Open();

                    int rowInserted = com.ExecuteNonQuery();
                    con.Close();
                }      
            }
            return Ok(animal);
        }

        [HttpPut("IdAnimal")]
        public IActionResult UpdateAnimal(Animal animal,int idAnimal)
        {
            using (var con = new SqlConnection(dataString))
            {
                using (var com = new SqlCommand())
                {
                    com.Connection = con;
                    com.CommandText = "Update animal Set name = @Name, description = @Description, category = @Category, area = @Area " +
                         "where idanimal = '" + idAnimal + "'";

                    com.Parameters.AddWithValue("@Name", animal.Name);
                    com.Parameters.AddWithValue("@Description", animal.Description);
                    com.Parameters.AddWithValue("@Category", animal.Category);
                    com.Parameters.AddWithValue("@Area", animal.Area);

                    con.Open();

                    int rowUpdated = com.ExecuteNonQuery();
                    con.Close();
                }
                return Ok(animal);
            }
        }

        [HttpDelete("IdAnimal")]
        public IActionResult delAnimal(int IdAnimal)
        {
            using (var con = new SqlConnection(dataString))
            {
                using (var com = new SqlCommand())
                {
                    com.Connection = con;
                    com.CommandText = "Delete from animal where idanimal='" + IdAnimal + "'";
                    con.Open();
                    int rowDeleted = com.ExecuteNonQuery();
                }
            }
            return Ok();
        }
    }
}

