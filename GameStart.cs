using System;
using System.Collections.Generic;

namespace farstone
{
    class GameStart
    {
        public static Player makePlayer()
        {
            Console.WriteLine("Please enter your name");
            string inputName = Console.ReadLine();
            object[,] deckBlueprint = new object[15, 4]
            {
                {1,1,0,"Wisp"},
                {1,3,1,"Dire Mole"},
                {2,1,1,"Murloc Raider"},
                {3,2,2,"Bloodfen Raptor"},
                {3,2,2,"Acidic Swamp Ooze"},
                {4,1,2,"Duskboar"},
                {2,3,2,"River Crocolisk"},
                {3,3,3,"Ironfur Grizzly"},
                {5,1,3,"Magma Rager"},
                {2,4,3,"Squirming Tentacle"},
                {4,5,4,"Chillwind Yeti"},
                {5,4,4,"Ancient Brewmaster"},
                {4,6,5,"Spiteful Smith"},
                {6,7,6,"Boulderfist Ogre"},
                {9,5,7,"Core Hound"}
            };
            List<Card> cardList = new List<Card>();
            for (int i=0; i<15; i++)
            {
                cardList.Add(new Minion((int)deckBlueprint[i,0],(int)deckBlueprint[i,1],(int)deckBlueprint[i,2],(string)deckBlueprint[i,3]));
                cardList.Add(new Minion((int)deckBlueprint[i,0],(int)deckBlueprint[i,1],(int)deckBlueprint[i,2],(string)deckBlueprint[i,3]));
            }
            Deck playerDeck = new Deck(cardList);
            Player newPlayer = new Player(playerDeck, inputName);
            newPlayer.deck.shuffle();
            newPlayer.draw();
            newPlayer.draw();
            newPlayer.draw();
            return newPlayer;
        }
    }
    
}