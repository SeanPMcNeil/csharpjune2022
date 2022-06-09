using System.ComponentModel.DataAnnotations;
#pragma warning disable CS8618
namespace MVCLecture.Models;

public class User
{
    [Required(ErrorMessage = "Name is required")]
    [MinLength(2)]
    public string Name { get; set;}

    [Required]
    public string FavColor { get; set;}

    [Required]
    [Range(-1000,1000)]
    public int FavNum { get; set; }
}