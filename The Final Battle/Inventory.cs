using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Final_Battle
{
    public class Inventory
    {
        public int size = 6;
        public List<Items> inventory = new List<Items>();
        public List<Items> possibleItems = new List<Items> { new Sword(7), new Bomb(10), new HealingPotion(8), 
            new BuffPotions(7), new Stave(5), new Scimitar(8), new Knife(3) };
    }
}
