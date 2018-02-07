using System;

namespace farstone
{
    class Program
    {
        public static void showInfo(Player current_player, Player other_player)
        {
            string info = "";
            Console.WriteLine($"*************************** {current_player.name}'s Turn ******************************");
            Console.WriteLine($"============================ {other_player.name}'s stats ==========================");
            Console.WriteLine($"Health: {other_player.health}...................Hand Size: {other_player.hand.Count}");
            Console.WriteLine($"");
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
            Console.WriteLine($"========================================================================");
            Console.WriteLine($"");

            Console.WriteLine($"============================ {current_player.name}'s stats ==========================");
            Console.WriteLine($"Health: {current_player.health}...................Hand Size: {current_player.hand.Count}");
            Console.WriteLine($"Mana: {current_player.manaTotal}");
            Console.WriteLine($"");
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
            Console.WriteLine($"++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine($"");
            Console.WriteLine($"+++++++++++++++ {current_player.name}'s Cards ++++++++++++++");
            for(int i = 0; i < 7; i++)
            {
                Console.WriteLine($"Slot {i}: Name: {current_player.field[i].name} --- Attack: {current_player.field[i].atk} --- HP: {current_player.field[i].hp} --- Cost: {current_player.field[i].cost}");
            }
            Console.WriteLine($"++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine($"*************************** {current_player.name}'s Turn ******************************");
        }

        public static bool makeChoice(Player current_player)
        {
            Console.WriteLine($"Mana: {current_player.manaTotal}");            
            Console.WriteLine("Do you want to [P]lay a card, [A]ttack with a creatue or [E]nd your turn.");
            string choice = Console.ReadLine().ToLower();
            if(choice != "p" || choice != "a" || choice != "e")
            {
                Console.WriteLine("I guess you had an issue with the instructions");
                Console.WriteLine("Enter 'P', 'A' or 'E' since that wasn't clear");
            }
            else if (choice == "p")
            {
                Console.WriteLine("These are you cards:");
                for 
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
            while(makeChoice(current_player)){}


            //sets up next player's turn
            Player temp = current_player;
            current_player = other_player;
            other_player = temp;
        }

        static void Main(string[] args)
        {
            //creates players
            Console.WriteLine($"Welcome {player1.name}, you are Player 1");


            Player player1 = createPlayer(name1);
            Console.WriteLine($"Greetings {player1.name}, you are now playing as Player 1");
            Player player2 = createPlayer(name2);
            Console.WriteLine($"Greetings {player2.name}, you are now playing as Player 2");

            Player current_player = player1;
            Player other_player = player2;
            
            //Game Loop
            while(player1.health > 0 && player2.health > 0)
            {
                gameLoop(current_player, other_player);
            }
        }
    }
}
