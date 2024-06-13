using System.Data.SqlClient;
using ZOO_API.Models;

namespace ZOO_API.Repositories;

public class AnimalRepository : IAnimalRepository
{
    private IConfiguration _configuration;

    public AnimalRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IEnumerable<Animal> GetAnimals()
    {
        using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        con.Open();

        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "SELECT IdAnimal, Name, Description, Category, Area FROM Animal";

        var dr = cmd.ExecuteReader();
        var Animals = new List<Animal>();

        while (dr.Read())
        {
            var instance = new Animal
            {
                IdAnimal = (int)dr["IdAnimal"],
                Name = dr["Name"].ToString(),
                Description = dr["Description"].ToString(),
                Category = dr["Category"].ToString(),
                Area = dr["Area"].ToString()
            };
            Animals.Add(instance);
        }

        return Animals;
    }

    public IEnumerable<Animal> GetAnimals(string orderBy)
    {
        using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        con.Open();
        
        string query = "SELECT IdAnimal, Name, Description, Category, Area FROM Animal ORDER BY ";
        query += orderBy;
        query += " DESC";
        
        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText =  query;
        //cmd.Parameters.AddWithValue("@orderBy", orderBy);

        var dr = cmd.ExecuteReader();
        var Animal = new List<Animal>();

        while (dr.Read())
        {
            var instance = new Animal
            {
                IdAnimal = (int)dr["IdAnimal"],
                Name = dr["Name"].ToString(),
                Description = dr["Description"].ToString(),
                Category = dr["Category"].ToString(),
                Area = dr["Area"].ToString()
            };
            Animal.Add(instance);
        }

        //Console.WriteLine(orderBy);
        //Console.WriteLine(orderBy.GetType());
        //Console.WriteLine("Siemano");
        return Animal;
    }
}