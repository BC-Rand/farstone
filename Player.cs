using System;
using System.Collections.Generic;

namespace farstone
{
    public class Player
    {
        public Deck deck;
        public List<Card> hand;
        public Card[] field = new Card[7];
        int health = 30;
        int manaTotal = 0;
        public string name;
        public Player(Deck inputDeck, string inputName)
        {
            deck = inputDeck;
            name = inputName;
        }
        public void draw()
        {
            if (deck.cards.Count > 0)
            {
                Card drawCard = deck.cards[0];
                deck.cards.RemoveAt(0);
                hand.Add(drawCard);
            }
        }

    }
}