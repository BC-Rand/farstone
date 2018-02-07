using System;

namespace farstone
{
    class Program
    {
        public static void showHand(Player current_player)
        {
            Console.WriteLine($"+++++++++++++++ {current_player.name}'s Hand ++++++++++++++");
            for(int i = 0; i < current_player.hand.Count; i++)
            {
                if(current_player.hand[i] is Minion){
                    Minion card = current_player.hand[i] as Minion;
                    Console.WriteLine($"Card {i}: Name: {card.name} --- Attack: {card.atk} --- HP: {card.hp} --- Cost: {card.cost}");
                }
                //add spell display here as else if
            }
            Console.WriteLine($"++++++++++++++++++++++++++++++++++++++++++++++++++++++");
        }

        public static void showField(Player current_player, Player other_player)
        {
            Console.WriteLine($"+++++++++++++++ {other_player.name}'s creatures ++++++++++++++");
            for(int i = 0; i < 7; i++)
            {
                if(other_player.field[i] == null)
                {
                    Console.WriteLine($"Slot {i}: Empty");
                }
                else
                {
                    Console.WriteLine($"Slot {i}: Name: {other_player.field[i].name} --- Attack: {other_player.field[i].atk} --- HP: {other_player.field[i].hp} --- Cost: {other_player.field[i].cost}");
                }
            }
            Console.WriteLine($"++++++++++++++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine($"+++++++++++++++ {current_player.name}'s creatures ++++++++++++++");
            for(int i = 0; i < 7; i++)
            {
                if(current_player.field[i] == null)
                {
                    Console.WriteLine($"Slot {i}: Empty");
                }
                else
                {
                    Console.WriteLine($"Slot {i}: Name: {current_player.field[i].name} --- Attack: {current_player.field[i].atk} --- HP: {current_player.field[i].hp} --- Cost: {current_player.field[i].cost}");
                }
            }
            Console.WriteLine($"++++++++++++++++++++++++++++++++++++++++++++++++++++");
        }

        public static void showStats(Player current_player, Player other_player)
        {
            Console.WriteLine($"============================ {other_player.name}'s stats ==========================");            
            Console.WriteLine($"Health: {other_player.health}...................Hand Size: {other_player.hand.Count}");
            Console.WriteLine($"");
            Console.WriteLine($"============================ {current_player.name}'s stats ==========================");
            Console.WriteLine($"Health: {current_player.health}...................Hand Size: {current_player.hand.Count}");
            Console.WriteLine($"Mana: {current_player.manaTotal}");
            Console.WriteLine($"");
            Console.WriteLine($"========================================================================");
        }

        public static void showInfo(Player current_player, Player other_player)
        {
            Console.WriteLine($"*************************** {current_player.name}'s Turn ******************************");
            showStats(current_player, other_player);
            Console.WriteLine($"");
            showField(current_player, other_player);
            Console.WriteLine($"");
            showHand(current_player);
            Console.WriteLine($"*************************** {current_player.name}'s Turn ******************************");
        }

        public static void playCard(Player current_player, Player other_player, int turn_mana)
        {
            showField(current_player, other_player);
            Console.WriteLine("These are you cards:");
            showHand(current_player);
            Console.WriteLine($"You have {turn_mana} Mana to play.");
            Console.WriteLine("Please input the slot # of the card you want to play:");
            string card_string = Console.ReadLine();
            if(int.TryParse(card_string, out int card_num))
            {
                if(current_player.hand[card_num].cost <= turn_mana)
                {
                    Console.WriteLine($"Select the slot in the field you wish to play {current_player.hand[card_num].name} in:");
                    int slot = GetInput.GetInt();
                    current_player.field[slot] = current_player.hand[card_num] as Minion;
                    current_player.hand.RemoveAt(card_num);
            showField(current_player, other_player);
                }
                else
                {
                    Console.WriteLine("Nice try, but that creatures costs more than you got. peasent.");
                }

            }
            else
            {
                Console.WriteLine("Iditot, that wasn't a number");
            }
        }

        public static bool makeChoice(Player current_player, Player other_player, int turn_mana)
        {
            Console.WriteLine($"Mana: {turn_mana}");            
            Console.WriteLine("Do you want to [P]lay a card, [A]ttack with a creatue or [E]nd your turn.");
            string choice = Console.ReadLine().ToLower();
            if(choice != "p" && choice != "a" && choice != "e")
            {
                Console.WriteLine("I guess you had an issue with the instructions");
                Console.WriteLine("Enter 'P', 'A' or 'E' since that wasn't clear");
            }
            else if (choice == "p")
            {
                playCard(current_player, other_player, turn_mana);
            }
            else if (choice == "a")
            {
                AttackClass.Attack(current_player, other_player);
            }
            else if (choice == "e")
            {
                Console.WriteLine($"End of {current_player.name}'s turn.");
                return false;
            }
            

            return true;
        }

        public static void gameLoop(Player current_player, Player other_player)
        {
            if (current_player.manaTotal < 10)
            {
                current_player.manaTotal++;
            }
            int turn_mana = current_player.manaTotal;
            current_player.draw();
            showInfo(current_player, other_player);
            while(makeChoice(current_player, other_player, turn_mana)){}

            for(int i = 0; i < 7; i++)
            {
                if(current_player.field[i] != null)
                {
                    current_player.field[i].canAtk = true;
                }
            }
            //sets up next player's turn
            Player temp = current_player;
            current_player = other_player;
            other_player = temp;
        }

        static void Main(string[] args)
        {
            //creates players
            Console.WriteLine($"Welcome to game time, you are Player");


            Player player1 = GameStart.makePlayer();
            Console.WriteLine($"Greetings {player1.name}, you are now playing as Player 1");
            Player player2 = GameStart.makePlayer();
            Console.WriteLine($"Greetings {player2.name}, you are now playing as Player 2");

            Player current_player = player1;
            Player other_player = player2;
            Player tempPlayer;
            
            //Game Loop
            while(player1.health > 0 && player2.health > 0)
            {
                gameLoop(current_player, other_player);
                tempPlayer = current_player;
                current_player = other_player;
                other_player = tempPlayer;
            }
        }
    }
}
