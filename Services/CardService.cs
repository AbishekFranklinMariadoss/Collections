using System;
using System.Collections.Generic;
using GameSimulation.Data;
using GameSimulation.Interfaces;
using GameSimulation.Model;

namespace GameSimulation.Services
{
    public class CardService : ICardService
    {
        private readonly DeckData _deckData = new DeckData();
        public List<Card> CreateDeck()
        {
            return _deckData.GetStandardDeck();
        }
    }
}
