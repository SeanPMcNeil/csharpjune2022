using System.ComponentModel.DataAnnotations;
#pragma warning disable CS8618
namespace SimpleLoginRegis.Models;

public class LogUser
{
    [Required]
    [DataType(DataType.EmailAddress)]
    [RegularExpression(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"+ "@" + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$", ErrorMessage = "Please enter a valid email address")]
    public string LogEmail { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string LogPassword { get; set; }
}