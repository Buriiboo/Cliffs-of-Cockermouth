using System;

namespace Monsters
{
    public class Monster
    {
        public string monName {get; set;}
        public int monDmg {get; set;}
        public int monLvl {get; set;}
        public int monHP {get; set;}
        public List<Inventory> monInventory {get; set;} //enemy inventory som kan förflyttas till playerinventory?

        //Constructor V
        public Monster(string monName, int monLvl, int monHP, int monDmg)
        {
            this.monName = monName;
            this.monDmg = monDmg;
            this.monLvl = monLvl;
            this.monHP = monHP;
            monInventory = new List<Inventory>(); 
        }

  
    }
    
    

}
