public class Card
{
    public string Name {get;set;}
    public string Suit {get;set;}
    public int Val {get;set;}

    public void PrintCard()
    {
        Console.WriteLine($"{this.Name} of {this.Suit}");
    }
}