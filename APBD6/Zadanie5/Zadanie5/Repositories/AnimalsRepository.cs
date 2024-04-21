using System.Data.SqlClient;

namespace Zadanie5.Repositories;
public class AnimalsRepository : IAnimalsRepository
{
   private IConfiguration _configuration;

   public AnimalsRepository(IConfiguration configuration)
   {
      _configuration = configuration;
   }

   public IEnumerable<Animal> GetAnimals(string orderBy)
   {
      using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
      con.Open();
      using var cmd = new SqlCommand();
      cmd.Connection = con;
      if (!orderBy.Equals("Name") || !orderBy.Equals("Description") || !orderBy.Equals("Area") ||
          !orderBy.Equals("Category"))
      {
         orderBy = "Name";
      }

      String command = "SELECT Id, Name, Description, Category, Area FROM Animal ORDER BY " + orderBy;
      cmd.CommandText = command;
      var dr = cmd.ExecuteReader();
      var animals = new List<Animal>();
      while (dr.Read())
      {
         Animal animal = new Animal()
         {
            Id = (int)dr["Id"],
            Name = dr["Name"].ToString(),
            Description = dr["Description"].ToString(),
            Category = dr["Category"].ToString(),
            Area = dr["Area"].ToString(),
         };
         animals.Add(animal);
      }

      return animals;
   }

   public int CreateAnimal(Animal animal)
   {
      using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
      con.Open();
      using var cmd = new SqlCommand();
      cmd.Connection = con;
      cmd.CommandText =
         "INSERT INTO Animal(Name,Description,Category,Area) VALUES(@Name, @Description, @Category, @Area)";
      cmd.Parameters.AddWithValue("@Name", animal.Name);
      cmd.Parameters.AddWithValue("@Description", animal.Description);
      cmd.Parameters.AddWithValue("@Category", animal.Category);
      cmd.Parameters.AddWithValue("@Area", animal.Area);
      var count = cmd.ExecuteNonQuery();
      return count;
   }

   public int UpdateAnimal(Animal animal, int id)
   {
      using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
      con.Open();
      using var cmd = new SqlCommand();
      cmd.Connection = con;
      cmd.CommandText =
         "UPDATE Animal SET Name=@Name, Description = @Description, Category = @Category, Area = @Area WHERE Id = @ID";
      cmd.Parameters.AddWithValue("@Id", id);
      cmd.Parameters.AddWithValue("@Name", animal.Name);
      cmd.Parameters.AddWithValue("@Description", animal.Description);
      cmd.Parameters.AddWithValue("@Category", animal.Category);
      cmd.Parameters.AddWithValue("@Area", animal.Area);
      var count = cmd.ExecuteNonQuery();
      return count;
   }

   public int DeleteAnimal(int id)
   {
      using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
      con.Open();
      using var cmd = new SqlCommand();
      cmd.Connection = con;
      cmd.CommandText = "DELETE FROM Animal WHERE Id = @id";
      cmd.Parameters.AddWithValue("@Id", id);
      var count = cmd.ExecuteNonQuery();
      return count;
   }
}