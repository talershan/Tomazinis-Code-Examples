using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Final_Battle
{
    public class Final_Boss : Characters
    {
        public Final_Boss(int Health, string _name, Parties party,int Damage = 3) 
        {
            HP = Health;
            MaxHP = Health;
            damage = Damage;
            name = _name;
            attackType = Action.STAB;
            inventory.Capacity = 6;
            party.Party.Add(this);
        }

        public void FinalBattle(List<Characters> party, List<Characters> possibleEnemies)
        {
            int size = 4;
            Random random = new Random();
            for (int i = 1; i < size; i++)
            {
                int randIndex = random.Next(0, possibleEnemies.Count);
                party.Add(possibleEnemies[randIndex]);
                Characters RemoveCharacter = possibleEnemies[randIndex];
                possibleEnemies.Remove(RemoveCharacter);
            }
        }
    }
}
