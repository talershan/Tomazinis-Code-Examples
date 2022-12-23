using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Final_Battle
{
    public class Items
    {
        //public int weight = 1;
        public string name = "item";
        public int damage = 0;
        public int Heals = 0;
        public int buffAmount = 0;
        public int cost = 1;

        
    }

    public class Bomb : Items
    {
        public Bomb(int DamageAmount)
        {
            //weight = 2;
            name = "Bomb";
            damage = DamageAmount;
            cost = 2;
        }
    }
    public class Sword : Items
    {
        public Sword(int DamageAmount)
        {
            //weight = 2;
            name = "Sword";
            damage = DamageAmount;
            cost = 5;
        }
    }
    public class Bow : Items
    {
        public Bow(int DamageAmount)
        {
            //weight = 2;
            name = "Bow";
            damage = DamageAmount;
            cost = 4;
        }
        
    }
    public class Stave : Items
    {
        public Stave(int DamageAmount)
        {
            //weight = 2;
            name = "Stave";
            damage = DamageAmount;
            cost = 4;
        }
    }
    public class Knife : Items
    {
        public Knife(int DamageAmount)
        {
            //weight = 2;
            name = "Knife";
            damage = DamageAmount;
            cost = 4;
        }
    }
    public class Scimitar : Items
    {
        public Scimitar(int DamageAmount)
        {
            //weight = 2;
            name = "Scimitar";
            damage = DamageAmount;
            cost = 4;
        }
    }
}
