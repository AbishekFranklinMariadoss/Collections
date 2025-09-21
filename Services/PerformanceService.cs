using System;
using System.Collections.Generic;
using System.Linq;
using GameSimulation.Interfaces;
using GameSimulation.Model;

namespace GameSimulation.Services
{
    public class PerformanceService : IPerformanceService
    {
        // Shuffle List using Fisher-Yates algorithm
        public void ShuffleList(List<Card> deck, Random rng)
        {
            Console.WriteLine("=== LIST SHUFFLE ===");
            for (int i = deck.Count - 1; i > 0; i--)
            {
                int j = rng.Next(i + 1);
                var temp = deck[i];
                deck[i] = deck[j];
                deck[j] = temp;
            }
            Console.WriteLine($"Shuffled {deck.Count} cards using List");
        }
        
        // Shuffle Stack by converting to array, shuffling, then rebuilding stack
        public void ShuffleStack(Stack<Card> stack, Random rng)
        {
            Console.WriteLine("=== STACK SHUFFLE ===");
            var array = stack.ToArray();
            stack.Clear();
            
            // Fisher-Yates shuffle on array
            for (int i = array.Length - 1; i > 0; i--)
            {
                int j = rng.Next(i + 1);
                var temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
            
            // Rebuild stack from shuffled array
            for (int i = array.Length - 1; i >= 0; i--)
            {
                stack.Push(array[i]);
            }
            Console.WriteLine($"Shuffled {stack.Count} cards using Stack");
        }
        
        // Shuffle LinkedList using random node movements
        public void ShuffleLinkedList(LinkedList<Card> linkedList, Random rng)
        {
            Console.WriteLine("=== LINKEDLIST SHUFFLE ===");
            int moves = linkedList.Count * 2; // More moves for better shuffle
            
            for (int i = 0; i < moves && linkedList.Count > 1; i++)
            {
                // Pick a random node
                var node = linkedList.First;
                int steps = rng.Next(linkedList.Count);
                for (int j = 0; j < steps && node != null; j++) 
                    node = node.Next;
                
                if (node == null) continue;
                
                // Remove node from current position
                linkedList.Remove(node);
                
                // Insert at random position
                int insertAt = rng.Next(linkedList.Count + 1);
                if (insertAt == 0)
                {
                    linkedList.AddFirst(node);
                }
                else if (insertAt == linkedList.Count)
                {
                    linkedList.AddLast(node);
                }
                else
                {
                    var insertNode = linkedList.First;
                    for (int j = 0; j < insertAt && insertNode != null; j++) 
                        insertNode = insertNode.Next;
                    if (insertNode != null)
                        linkedList.AddBefore(insertNode, node);
                }
            }
            Console.WriteLine($"Shuffled {linkedList.Count} cards using LinkedList");
        }
    }
}