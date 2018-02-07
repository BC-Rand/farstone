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
                {1,1,0,"Tree"},
                {1,3,1,"DireMole"},
                {2,1,1,"Murloc"},
                {3,2,2,"Raptor"},
                {3,2,2,"AcidOoze"},
                {4,1,2,"Duskboar"},
                {2,3,2,"Croclisk"},
                {3,3,3,"Grizzly"},
                {5,1,3,"MagmaMan"},
                {2,4,3,"Tentacle"},
                {4,5,4,"ChillYeti"},
                {5,4,4,"Ancient"},
                {4,6,5,"Smith"},
                {6,7,6,"Ogre"},
                {9,5,7,"Hound"},
            };
            List<Card> cardList = new List<Card>();
            for (int i=0; i<15; i++)
            {
                cardList.Add(new Minion((int)deckBlueprint[i,0],(int)deckBlueprint[i,1],(int)deckBlueprint[i,2],(string)deckBlueprint[i,3]));
                cardList.Add(new Minion((int)deckBlueprint[i,0],(int)deckBlueprint[i,1],(int)deckBlueprint[i,2],(string)deckBlueprint[i,3]));
            }
            Deck playerDeck;
            Console.WriteLine("Would you like to create your own deck? [Y]es or [N]o?");            
            string ans = Console.ReadLine().ToLower();
            if(ans == "y")
            {
                playerDeck = new Deck(createDeck.MakingDeck());
            }
            else
            {
                playerDeck = new Deck(cardList);
            }
            
            Player newPlayer = new Player(playerDeck, inputName);
            newPlayer.deck.shuffle();
            newPlayer.deck.shuffle();
            newPlayer.deck.shuffle();
            newPlayer.draw();
            newPlayer.draw();
            newPlayer.draw();
            return newPlayer;
        }
    }
    
}