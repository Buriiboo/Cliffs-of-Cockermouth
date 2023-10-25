using System;

namespace Monsters
{
    public class Monster
    {
        public string monName {get; set;}
        public int monDmg {get; set;}
        public int monLvl {get; set;}
        public int monHP {get; set;}
        public List<Inventory> monInventory {get; set;}

        //Constructor V
        public Monster(string monName, int monLvl, int monHP,int monDmg)
        {
            monName = monname;
            monDmg = mondmg;
            monLvl = monlvl;
            monHP = monhp;
            
        }

        //inventeory?
        Monster monster1 = new Monster("Orcboi", 1, 20, 5);
        

    }

    

}
