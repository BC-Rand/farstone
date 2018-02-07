using System;
using System.Collections.Generic;

namespace farstone
{
    public class AttackClass
    {
        public static void Attack(Player current_player, Player other_player)
        {
            if (!AttackValid(current_player))
            {
                Console.WriteLine("You have no minions that can attack");
            }
            else
            {
                // showField is unbuilt
                Program.showField(current_player, other_player);
                Console.WriteLine("Choose the Minion you'd like to attack with");
                int attackIdx = GetAttackerIndex(current_player);
                Console.WriteLine("Choose 1-7 to attack a minion or 8 to attack the enemy player");
                int receiverIdx = GetReceiverIndex(other_player);
                current_player.field[attackIdx].canAtk = false;
                if (receiverIdx == 8)
                {
                    other_player.health -= current_player.field[attackIdx].atk;
                }
                else
                {
                    other_player.field[receiverIdx].hp -= current_player.field[attackIdx].atk;
                    current_player.field[attackIdx].hp -= other_player.field[receiverIdx].atk;
                    if (other_player.field[receiverIdx].hp <= 0)
                    {
                        other_player.field[receiverIdx] = null;
                    }
                    if (current_player.field[attackIdx].hp <= 0)
                    {
                        current_player.field[attackIdx] = null;
                    }
                    Program.showField(current_player, other_player);
                }
            }
        }
        public static int GetAttackerIndex(Player player)
        {
            int attackerIdx = GetInput.GetInt();
            if (attackerIdx >= 0 && attackerIdx <= 7 && player.field[attackerIdx] != null)
            {
                if (player.field[attackerIdx].canAtk == true)
                {
                    return attackerIdx;
                }
                else
                {
                    Console.WriteLine("That Minion cannot attack");
                    {
                        return GetAttackerIndex(player);
                    }
                }
            }
            else
            {
                Console.WriteLine("No Minion at that index");
                return GetAttackerIndex(player);
            }
        }
        public static int GetReceiverIndex(Player player)
        {
            int receiverIdx = GetInput.GetInt();
            if (receiverIdx == 8)
            {
                return receiverIdx;
            }
            else if (receiverIdx >= 0 && receiverIdx <= 7 && player.field[receiverIdx] != null)
            {
                return receiverIdx;
            }
            else
            {
                Console.WriteLine("No Minion at that index");
                return GetReceiverIndex(player);
            }
        }
        public static Boolean AttackValid(Player current_player)
        {
            Boolean validity = false;
            for (int i=0; i<7; i++)
            {
                if (current_player.field[i] != null && current_player.field[i].canAtk == true)
                {
                    validity = true;
                    break;
                }
            }
            return validity;
        }
    }
}