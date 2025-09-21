using System;

namespace GameSimulation.Model
{
    public enum Suit { Heart, Diamond, Club, Spade }
    public enum Rank { Ace = 1, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King }

    public class Card
    {
        public Suit Suit { get; }
        public Rank Rank { get; }
        
        public Card(Suit suit, Rank rank)
        {
            Suit = suit;
            Rank = rank;
        }
        
        public override string ToString() => $"{Suit}-{Rank}";
    }
}
