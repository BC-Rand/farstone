using System;
using System.Collections.Generic;
namespace farstone
{
    public class Card{
        public int cost;
        public string name;
    }
    public class Minion : Card{
        public int atk;
        public int hp;
        public bool canAtk = false;
        Minion(int atkVal, int hpVal ,int costVal , string nameVal){
        atk = atkVal;
        hp = hpVal;
        cost = costVal;
        name = nameVal;
        }
    }
    public class Spell : Card{
        Spell(int costVal, string nameVal){
        cost = costVal;
        name = nameVal;
        }
    }

}