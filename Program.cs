using System;
using System.Collections.Generic;
using System.Linq;
using GameSimulation.Interfaces;
using GameSimulation.Services;
using GameSimulation.Model;

namespace GameSimulation
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of card service to generate deck
            ICardService cardService = new CardService();
            // Create performance service for shuffle demonstrations
            IPerformanceService performanceService = new PerformanceService();
            // Create random number generator for shuffling
            var rng = new Random();

            // Create deck
            var deck = cardService.CreateDeck();
            
            // Demonstrate shuffling with List
            var deckList = new List<Card>(deck);
            performanceService.ShuffleList(deckList, rng);
            
            // Demonstrate shuffling with Stack
            var deckStack = new Stack<Card>(deck);
            performanceService.ShuffleStack(deckStack, rng);
            
            // Demonstrate shuffling with LinkedList
            var deckLinkedList = new LinkedList<Card>(deck);
            performanceService.ShuffleLinkedList(deckLinkedList, rng);

            Console.WriteLine();

            // Display instructions to user
            Console.WriteLine("Enter a number (1-52) to get the card at that position, or 'q' to exit:");
            
            // Main interaction loop
            while (true)
            {
                // Prompt user for input
                Console.Write("Position: ");
                // Read user input (nullable string)
                string? input = Console.ReadLine();
                
                // Check if user wants to quit
                if (input?.ToLower() == "q")
                    break;
                
                // Validate input is a number between 1-52
                if (int.TryParse(input, out int position) && position >= 1 && position <= 52)
                {
                    // Display header for card at requested position
                    Console.WriteLine($"\n=== Card at position {position} ===");
                    
                    // List access using direct indexing (0-based, so subtract 1)
                    var listCard = deckList[position - 1];
                    // Display card from List collection
                    Console.WriteLine($"List: {listCard}");
                    
                    // Stack access requires conversion to array for indexing
                    var stackArray = deckStack.ToArray();
                    // Get card from stack array at specified position
                    var stackCard = stackArray[position - 1];
                    // Display card from Stack collection
                    Console.WriteLine($"Stack: {stackCard}");
                    
                    // LinkedList access requires traversal to find position
                    var linkedListCard = GetCardAtPosition(deckLinkedList, position - 1);
                    // Display card from LinkedList collection
                    Console.WriteLine($"LinkedList: {linkedListCard}");
                    
                    // Add blank line for readability
                    Console.WriteLine();
                }
                else
                {
                    // Display error message for invalid input
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 52, or 'q' to exit.\n");
                }
            }
            
            // Print the complete shuffled deck when user quits
            Console.WriteLine("\n=== Complete Shuffled Deck ===");
            // Loop through all cards in the deck
            for (int i = 0; i < deckList.Count; i++)
            {
                // Display each card with its position (1-based indexing for display)
                Console.WriteLine($"Position {i + 1}: {deckList[i]}");
            }
            
            // Display goodbye message
            Console.WriteLine("\nThanks for playing!");
        }
        
        // Helper method to get card at specific position in LinkedList
        static Card GetCardAtPosition(LinkedList<Card> linkedList, int index)
        {
            // Start at first node
            var current = linkedList.First;
            // Traverse the linked list to reach desired index
            for (int i = 0; i < index && current != null; i++)
            {
                // Move to next node
                current = current.Next;
            }
            // Return the card value at the found node (! suppresses null warning)
            return current!.Value;
        }
    }
}
