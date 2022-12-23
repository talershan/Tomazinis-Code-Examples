using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Final_Battle
{
    public class Characters
    {
        public int HP = 10;
        public int MaxHP = 10;
        public int damage = 1;
        public string name = "";
        public Weapon weapons = Weapon.SWORD;
        public Action attackType = Action.NONE;
        public int Gold = 0;
        public List<Items> inventory = new List<Items>(6);//{new Sword(7), new Bomb(10), new HealingPotion(8),
            //new BuffPotions(7), new Stave(5), new Scimitar(8) };

        public void AddToInventory(Characters character, Items item)
        {
            character.inventory.Add(item);
        }
        //public List<Items> GenerateInventory(Characters character, List<Items> inventory)
        //{
        //    Random random = new Random();
        //    for (int i = 0; i < 6; i++)
        //    {
        //        int StoreInventoryIndex = random.Next(0, inventory.Count - 1);
        //        character.inventory.Add(inventory[StoreInventoryIndex]);
        //        inventory.Remove(inventory[StoreInventoryIndex]);
        //    }
        //    return character.inventory;

        //}
        public void Attack(Characters attacking, Characters attacked, List<Characters> attackedsParty, int selection)
        {
            if ((attacked.HP > 0) && (attacked.HP - attacking.damage > 0))
            {
                Console.WriteLine($"{attacking.name} used {attacking.attackType} on {attacked.name}.");
                Console.WriteLine($"{attacked.name} took {attacking.damage} damage!");
                attacked.HP -= attacking.damage;
            }
            else
            {
                attacked.Die(attackedsParty, selection);
            }
        }

        public void Die(List<Characters> Party, int selection)
        {
            Party[selection].HP = 0;
            Console.WriteLine($"{Party[selection].name} has been killed!");
            Party.Remove(Party[selection]);
        }
        public void Heal(Characters characters, int healAmount)
        {
            int over = 0;

            if (characters.HP + healAmount <= MaxHP)
            {
                characters.HP += healAmount;
                Console.WriteLine($"{characters.name} heals 5 health.");
            }
            else if (characters.HP + healAmount >= MaxHP)
            {
                over = characters.MaxHP - characters.HP;
                characters.HP += over;
                Console.WriteLine($"{characters.name} heals {over} health.");
            }
            else if (characters.HP == characters.MaxHP)
            {
                Console.WriteLine("You have Max HP, you don't need to heal.");
            }
        }
    }

    public class Skeleton : Characters
    {
        
        public Skeleton(int Health, string _name, int Damage = 1)
        {
            HP = Health;
            MaxHP = Health;
            damage = Damage;
            name = _name;
            attackType = Action.CRUNCH;
            weapons = Weapon.STAVE;
            //skeleton.inventory.Add(new Sword(2));
        }
        public void NewInventory(Characters characters, Parties party)
        {
            party.GenerateInventory(characters, characters.inventory);
        }
    }

    public class Orc : Characters
    {
        public Orc(int Health, string _name, int Damage = 1)
        {
            HP = Health;
            MaxHP = Health;
            damage = Damage;
            name = _name;
            attackType = Action.SLICE;
        }
    }

    public class Zombie : Characters
    {
        public Zombie(int Health, string _name, int Damage = 1)
        {
            HP = Health;
            MaxHP = Health;
            damage = Damage;
            name = _name;
            attackType = Action.BITE;
        }
    }
    public class Bear : Characters
    {
        public Bear(int Health, string _name, int Damage = 1)
        {
            HP = Health;
            MaxHP = Health;
            damage = Damage;
            name = _name;
            attackType = Action.BITE;
        }
    }
    public class Werewolf : Characters
    {
        public Werewolf(int Health, string _name, int Damage = 1)
        {
            HP = Health;
            MaxHP = Health;
            damage = Damage;
            name = _name;
            attackType = Action.SLASH;
        }
    }
    public class Vampire : Characters
    {
        public Vampire(int Health, string _name, int Damage = 1)
        {
            HP = Health;
            MaxHP = Health;
            damage = Damage;
            name = _name;
            attackType = Action.SLAP;
        }
    }
    public class Ranger : Characters
    {
        public Ranger(int Health, string _name, int Damage = 1)
        {
            HP = Health;
            MaxHP = Health;
            damage = Damage;
            name = _name;
            attackType = Action.SHOOT;
            weapons = Weapon.BOW;
            inventory.Capacity = 6;
            //GenerateInventory(ranger, ranger.inventory[0].possibleItems);
        }
        public void NewInventory(Characters characters,Parties party)
        {
            party.GenerateInventory(characters, characters.inventory);
        }
    }
    public class Cleric : Characters
    {

        public Cleric(int Health, string _name, int Damage = 1)
        {
            HP = Health;
            MaxHP = Health;
            damage = Damage;
            name = _name;
            attackType = Action.INFLICTWOUNDS;
            inventory.Capacity = 6;
            weapons = Weapon.STAVE;
            //GenerateInventory(cleric, cleric.inventory[0].possibleItems);
        }

        public void NewInventory(Characters characters, Parties party)
        {
            party.GenerateInventory(characters, characters.inventory);
        }
    }
    public class Fighter : Characters
    {
        public Fighter(int Health, string _name, int Damage = 1)
        {
            HP = Health;
            MaxHP = Health;
            damage = Damage;
            name = _name;
            attackType = Action.STAB;
            inventory.Capacity = 6;
            //GenerateInventory(fighter, fighter.inventory[0].possibleItems);
        }
        public void NewInventory(Characters characters, Parties party)
        {
            party.GenerateInventory(characters, characters.inventory);
        }
    }
}
    public enum Action { NONE, SLAP, STAB, SLICE, INFLICTWOUNDS, SHOOT, SLASH, BITE, CRUNCH, PUNCH};
    public enum Weapon { SWORD, BOMB, BOW, STAVE, SCIMITAR, KNIFE, };
