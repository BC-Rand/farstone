using System;
using System.Collections.Generic;

namespace farstone
{
    class createDeck
    {
        public static List<Card> MakingDeck()
        {
            List<Card> cardList = new List<Card>();
            List<Card> deckBlueprint = new List<Card>();
            {
                deckBlueprint.Add(new Wisp());
                deckBlueprint.Add(new Tree());
                deckBlueprint.Add(new DireMole());
                deckBlueprint.Add(new MurlocRaider());
                deckBlueprint.Add(new BloodfenRaptor());
                deckBlueprint.Add(new AcidicSwampOoze());
                deckBlueprint.Add(new Duskboar());
                deckBlueprint.Add(new RiverCrocolisk());
                deckBlueprint.Add(new IronfurGrizzly());
                deckBlueprint.Add(new MagmaRager());
                deckBlueprint.Add(new SquirmingTentacle());
                deckBlueprint.Add(new FireFly());
                deckBlueprint.Add(new ChillwindYeti());
                deckBlueprint.Add(new AncientBrewmaster());
                deckBlueprint.Add(new SpitefulSmith());
                deckBlueprint.Add(new Sergeant());
                deckBlueprint.Add(new BoulderfistOgre());
                deckBlueprint.Add(new StoneMan());
                deckBlueprint.Add(new CoreHound());
                deckBlueprint.Add(new LavaMan());

            };

            while(cardList.Count < 30)
            {
                for (int i = 0; i < deckBlueprint.Count; i++)
                {
                    Console.WriteLine($"{i} - {deckBlueprint[i].name} Has {(deckBlueprint[i] as Minion).atk} ATK | {(deckBlueprint[i] as Minion).hp} HP | {deckBlueprint[i].cost} Cost");
                }
                Console.WriteLine($"What would you like to add to your deck? {cardList.Count}/30");
                int c = GetInput.GetInt();
                if(c > deckBlueprint.Count){
                    Console.WriteLine("That is not a card!");
                }
                else
                {
                    for (int z = 0; z < 2; z++)
                    {
                        cardList.Add(deckBlueprint[c]);
                    }
                    deckBlueprint.RemoveAt(c);
                }
            }
            
            Console.WriteLine("Your Deck!");
            for (int i = 0; i < 30; i++)
            {
                Console.WriteLine($"Card {i+1}: {cardList[i].name}");
            }
            return cardList;
        }
    }
}