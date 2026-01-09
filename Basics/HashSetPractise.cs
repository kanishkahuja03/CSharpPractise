using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashSetPractise
{
    public class AccessCardTracker
    {
        private readonly HashSet<string> _activeCards = new HashSet<string>();
        public bool CardEntry(string cardId)
        {
            return _activeCards.Add(cardId);
        }
        public bool CardExit(string cardId)
        {
            return _activeCards.Remove(cardId);
        }
        public bool IsCardInside(string cardId)
        {
            return _activeCards.Contains(cardId);
        }
        public void PrintActiveCards()
        {
            Console.WriteLine("Active cards inside the building:");

            foreach (var cardId in _activeCards)
            {
                Console.WriteLine(cardId);
            }
        }
        public void PrintTotalActiveCards()
        {
            Console.WriteLine($"Total active cards: {_activeCards.Count}");
        }
    }

    class Program
    {
        static void Main()
        {
            var tracker = new AccessCardTracker();

            tracker.CardEntry("CARD-101");
            tracker.CardEntry("CARD-102");
            tracker.CardEntry("CARD-103");

            tracker.CardEntry("CARD-101"); // Duplicate are ignored

            Console.WriteLine(tracker.IsCardInside("CARD-102")); // True

            tracker.CardExit("CARD-102");

            tracker.PrintActiveCards();
            tracker.PrintTotalActiveCards();
        }
    }

}