using System;
using System.Collections.Generic;

namespace farstone
{
    public class Player
    {
        public Deck deck;
        public List<Card> hand = new List<Card>();
        public Minion[] field = new Minion[7];
        public int health = 30;
        public int manaTotal = 0;
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
                Card drawCard = deck.cards[0] as Card;
                deck.cards.RemoveAt(0);
                hand.Add(drawCard);
            }
        }

    }
}