#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace bankAccounts.Models;

public class Transaction
{
    [Key]
    public int TransactionId {get;set;}
    [Required]
    public float Amount {get;set;}
    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;
    [Required]
    public int UserId {get;set;}
    public User? User {get;set;}
}