using System;
using System.Collections.Generic;

namespace farstone
{
    public class Deck
    {
        public List<Card> cards;
        public Deck(List<Card> inputCards)
        {
            cards = inputCards;
        }
        public void shuffle()
        {
            Random rand = new Random();
            for (int i=0; i<cards.Count; i++)
            {
                int idx = rand.Next(0,cards.Count);
                Card temp = cards[i];
                cards[i] = cards[idx];
                cards[idx] = temp;
            }
        }
    }
}