#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace logregDemo.Models;

public class LogUser
{
    [Required]
    [EmailAddress]
    public string LogEmail {get;set;}
    [Required]
    [MinLength(8)]
    [DataType(DataType.Password)]
    public string LogPassword {get;set;}
}