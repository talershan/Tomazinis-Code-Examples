using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Final_Battle
{
    public class Player : Characters
    {
        
        public Player(int Damage, int Health, List<Characters> Party)
        {
            damage = Damage;
            MaxHP = Health;
            HP = Health;
            Party.Add(this);
            attackType = Action.PUNCH;
            Gold = 20;
            inventory.Capacity = 6;
        }

        public void CollectName()
        {
            Console.WriteLine("Welcome to the Final Battle!\n"+
                "What's your name?");
            name = Console.ReadLine();
            Console.WriteLine($"Prepare yourself, {name}, you have much ahead of you.");
        }
    }
}
