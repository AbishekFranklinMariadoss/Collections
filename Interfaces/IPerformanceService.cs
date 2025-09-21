using System;
using System.Collections.Generic;
using GameSimulation.Model;

namespace GameSimulation.Interfaces
{
    public interface IPerformanceService
    {
        void ShuffleList(List<Card> deck, Random rng);
        void ShuffleStack(Stack<Card> stack, Random rng);
        void ShuffleLinkedList(LinkedList<Card> linkedList, Random rng);
    }
}