using System;
using System.Collections.Generic;

namespace farstone
{
    class createDeck
    {
        public static List<Card> MakingDeck()
        {
            List<Card> cardList = new List<Card>();
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
            for (int i = 0; i < 15; i++)
            {
                Console.WriteLine($"{i} - {deckBlueprint[i,3]} Has {deckBlueprint[i,0]} ATK | {deckBlueprint[i,1]} HP | {deckBlueprint[i,2]} Cost");
            }

            for (int i = 0; i < 15; i++)
            {
                Console.WriteLine("What would you like to add to your deck?");
                int c = GetInput.GetInt();
                for (int z = 0; z < 2; z++)
                {
                    cardList.Add(new Minion((int)deckBlueprint[c,0],(int)deckBlueprint[c,1],(int)deckBlueprint[c,2],(string)deckBlueprint[c,3]));
                }
            }
            Console.WriteLine("Your Deck!");
            for (int i = 0; i < 15; i++){
                Console.WriteLine(cardList[i].name);
            }
            return cardList;
        }
    }
}