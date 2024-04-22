using System.ComponentModel.DataAnnotations;

namespace WebApplication1;

public class Animal
{
    public int IdAnimal { get; set; }
    
    [Required]
    [MaxLength(200)]
    public String Name { get; set; }
    
    [MaxLength(200)]
    public String Description { get; set; }
    
    [Required]
    [MaxLength(200)]
    public String Category { get; set; }
    
    [Required]
    [MaxLength(200)]
    public String Area { get; set; }
}