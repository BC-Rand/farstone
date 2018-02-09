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
        public Minion(int atkVal, int hpVal ,int costVal , string nameVal){
        atk = atkVal;
        hp = hpVal;
        cost = costVal;
        name = nameVal;
        }
    }
    public class Wisp : Minion{
        public Wisp():base(1,1,0,"Wisp"){
        }
    }
    public class Tree : Minion{
        public Tree():base(1,1,0,"Tree"){
        }
    }
    public class DireMole : Minion{
        public DireMole():base(1,3,1,"DireMole"){
        }
    }
    public class MurlocRaider : Minion{
        public MurlocRaider():base(2,1,1,"Murloc"){
        }
    }
    public class BloodfenRaptor : Minion{
        public BloodfenRaptor():base(3,2,2,"Raptor"){
        }
    }
    public class AcidicSwampOoze : Minion{
        public AcidicSwampOoze():base(3,2,2,"AcidOoze"){
        }
    }
    public class Duskboar : Minion{
        public Duskboar():base(4,1,2,"Duskboar"){
        }
    }
    public class RiverCrocolisk : Minion{
        public RiverCrocolisk():base(2,3,2,"Croclisk"){
        }
    }
    public class IronfurGrizzly : Minion{
        public IronfurGrizzly():base(3,3,3,"Grizzly"){
        }
    }
    public class MagmaRager : Minion{
        public MagmaRager():base(5,1,3,"MagmaMan"){
        }
    }
    public class SquirmingTentacle : Minion{
        public SquirmingTentacle():base(2,4,3,"Tentacle"){
        }
    }
    public class FireFly : Minion{
        public FireFly():base(3,6,4,"FireFly"){
        }
    }
    public class ChillwindYeti : Minion{
        public ChillwindYeti():base(4,5,4,"ChillYeti"){
        }
    }
    public class AncientBrewmaster : Minion{
        public AncientBrewmaster():base(5,4,4,"Ancient"){
        }
    }
    public class SpitefulSmith : Minion{
        public SpitefulSmith():base(4,6,5,"Smith"){
        }
    }
    public class Sergeant : Minion{
        public Sergeant():base(5,5,5,"Sergeant"){
        }
    }
    public class BoulderfistOgre : Minion{
        public BoulderfistOgre():base(6,7,6,"Ogre"){
        }
    }
    public class StoneMan : Minion{
        public StoneMan():base(7,6,6,"Ogre"){
        }
    }
    public class CoreHound : Minion{
        public CoreHound():base(9,5,7,"Hound"){
        }
    }
    public class LavaMan : Minion{
        public LavaMan():base(8,8,8,"LavaMan"){
        }
    }
    public class Spell : Card{
        Spell(int costVal, string nameVal){
        cost = costVal;
        name = nameVal;
        }
    }

}