public class Deck
{
    public List<Card> Cards {get;set;} = new List<Card>();

    public void SetDeck()
    {
        string[] Suits = {"Hearts","Diamonds","Spades","Clubs"};
        string[] Names = {"Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King"};
        int[] Values = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13};

        foreach (string suit in Suits)
        {
            foreach (int value in Values)
            {
                Card newCard = new Card();
                newCard.Suit = suit;
                newCard.Val = value;
                newCard.Name = Names[value - 1];
                this.Cards.Add(newCard);
            }
        }
    }

    public void ResetDeck()
    {
        this.Cards.Clear();
        this.SetDeck();
    }

    public Card DealCard()
    {
        Card TopCard = this.Cards[0];
        this.Cards.Remove(TopCard);
        return TopCard;
    }

    public void ShuffleDeck()
    {
        Random random = new Random();
        int n = this.Cards.Count;

        for (int i = n - 1; i > 1; i--)
        {
            int rnd = random.Next(i + 1);

            Card value = this.Cards[rnd];
            this.Cards[rnd] = this.Cards[i];
            this.Cards[i] = value;
        }
    }
}