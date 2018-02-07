using System;
using System.Collections.Generic;

namespace farstone
{
    class createDeck
    {
        public static List<Card> MakingDeck()
        {
            List<Card> cardList = new List<Card>();
            object[,] deckBlueprint = new object[20, 4]
            {
                {1,1,0,"Wisp"},
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
                {3,6,4,"FireFly"},
                {4,5,4,"ChillYeti"},
                {5,4,4,"Ancient"},
                {4,6,5,"Smith"},
                {5,5,5,"Sergeant"},
                {6,7,6,"Ogre"},
                {7,6,6,"StoneMan"},
                {9,5,7,"Hound"},
                {8,8,8,"LavaMan"},
            };


            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine($"{i} - {deckBlueprint[i,3]} Has {deckBlueprint[i,0]} ATK | {deckBlueprint[i,1]} HP | {deckBlueprint[i,2]} Cost");
            }

            while(cardList.Count < 30)
            {
                Console.WriteLine("What would you like to add to your deck?");
                int c = GetInput.GetInt();
                if(deckBlueprint[c,0] == null){
                    Console.WriteLine("That is not a card!");
                }
                else
                {
                    for (int z = 0; z < 2; z++)
                    {
                        cardList.Add(new Minion((int)deckBlueprint[c,0],(int)deckBlueprint[c,1],(int)deckBlueprint[c,2],(string)deckBlueprint[c,3]));
                    }

                    cardList.RemoveAt(c);
                }
            }
            
            Console.WriteLine("Your Deck!");
            for (int i = 0; i < 30; i++)
            {
                Console.WriteLine($"Card {i}: {cardList[i].name}");
            }
            return cardList;
        }
    }
}