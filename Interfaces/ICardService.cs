using System.Collections.Generic;
using GameSimulation.Model;

namespace GameSimulation.Interfaces
{
    public interface ICardService
    {
        List<Card> CreateDeck();
    }
}
