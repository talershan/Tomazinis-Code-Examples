using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Final_Battle
{
    public class BuffPotions : Items
    {
        public BuffPotions(int BuffAmount)//will have to fix
        {
            buffAmount = BuffAmount;
            name = "Potion of Strength";
        }
    }
    public class HealingPotion : Items
    {
        public HealingPotion(int HealAmount)//should work
        {
            name = "Health Potion";
            Heals = HealAmount;
        }
    }
}
