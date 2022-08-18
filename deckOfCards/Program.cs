// Card aceOfDiamonds = new Card();

// aceOfDiamonds.Name = "Ace";
// aceOfDiamonds.Suit = "Diamonds";
// aceOfDiamonds.Val = 1;

// aceOfDiamonds.PrintCard();

Deck newDeck = new Deck();
newDeck.SetDeck();

foreach (Card card in newDeck.Cards)
{
    card.PrintCard();
}
Console.WriteLine("=====================================================");
Card DealtCard = newDeck.DealCard();
DealtCard.PrintCard();

Console.WriteLine("=====================================================");
foreach (Card card in newDeck.Cards)
{
    card.PrintCard();
}

newDeck.ResetDeck();

Console.WriteLine("=====================================================");
foreach (Card card in newDeck.Cards)
{
    card.PrintCard();
}

Console.WriteLine("=====================================================");
newDeck.ShuffleDeck();
Console.WriteLine($"The deck has {newDeck.Cards.Count} Cards");
foreach (Card card in newDeck.Cards)
{
    card.PrintCard();
}

Console.WriteLine("=====================================================");
Card DealtCard2 = newDeck.DealCard();
DealtCard2.PrintCard();