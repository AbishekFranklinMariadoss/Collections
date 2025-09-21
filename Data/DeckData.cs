using System.Collections.Generic;
using GameSimulation.Model;

namespace GameSimulation.Data
{
    public class DeckData
    {
        public List<Card> GetStandardDeck()
        {
            var deck = new List<Card>();
            foreach (Suit suit in System.Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank rank in System.Enum.GetValues(typeof(Rank)))
                {
                    deck.Add(new Card(suit, rank));
                }
            }
            return deck;
        }
    }
}
