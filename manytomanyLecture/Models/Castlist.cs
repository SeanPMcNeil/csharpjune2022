#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace manytomanyLecture.Models;

public class Castlist
{
    [Key]
    public int CastlistId {get;set;}
    // The connection to the Actor Table
    public int ActorId {get;set;}
    public Actor? Actor {get;set;}
    // The connection to the Movie Table
    public int MovieId {get;set;}
    public Movie? Movie {get;set;}
}