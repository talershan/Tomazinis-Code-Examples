using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Final_Battle
{
    public class Parties
    {
        public string name = "";
        public int partiesMax = 4;
        public List<Characters> Party = new List<Characters>(4);                                                                                                                                                                                              
        public List<Characters> possibleAllies = new List<Characters> { new Ranger(10, "Ranger", 15),
            new Cleric(12, "Cleric", 15),
            new Fighter(12, "Fighter", 15) };
        public List<Characters> possibleEnemies = new List<Characters> { new Orc(10, "Orc", 1),
            new Skeleton(12, "Skeleton", 1),
            new Zombie(12, "Zombie", 1),
            new Vampire(11, "Vampire", 1),
            new Werewolf(13, "Werewolf", 1),
            new Bear(9, "Bear", 1) };
        public List<Items> possibleItems = new List<Items> { new Sword(7), new Bomb(10), new HealingPotion(8),
            new BuffPotions(7), new Stave(5), new Scimitar(8), new Knife(3) };



        public Parties(string _name)
        {
            name = _name;
        }//working

        public void MakeStandardParty(List<Characters> Party)//working
        {
            Party.Add(new Ranger(15, "Ranger", 15));
            Party.Add(new Cleric(15, "Cleric", 15));
            Party.Add(new Fighter(15, "Fighter", 15));
        }
        public void GenerateParty(List<Characters> party, List<Characters> possibleEnemies)
        {
            int size = 4;
            Random random = new Random();
            for (int i = 0; i < size; i++)
            {
                int randIndex = random.Next(0, possibleEnemies.Count);
                party.Add(possibleEnemies[randIndex]);
                Characters RemoveCharacter = possibleEnemies[randIndex];
                possibleEnemies.Remove(RemoveCharacter);
            }
        }//working

        public List<Items> GenerateInventory(Characters character, List<Items> inventory)
        {
            Random random = new Random();
            for (int i = 0; i < 6; i++)
            {
                int StoreInventoryIndex = random.Next(0, inventory.Count);
                character.inventory.Add(inventory[StoreInventoryIndex]);
                inventory.Remove(inventory[StoreInventoryIndex]);
            }
            Console.WriteLine("Inventory generated.");
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine($"{character.inventory[i].name}");
            }
            
            return character.inventory;
            
        }

        public void AddToParty(List<Characters> allies)
        {
            Random random = new Random();
            int partyLimit = random.Next(2, 4);
            string selection = "";
            Console.WriteLine($"You have {partyLimit} open spots. Who would you like to add to your party?");
            for (int i = 0; i < allies.Count; i++)
            {
                Console.WriteLine($"A {allies[i].name} ");
            }

            for (int i = 1; i <= partyLimit; i++)
            {
                selection = Console.ReadLine();
                switch (selection)
                {
                    case "Ranger":
                        Party.Add(allies[0]);
                        Console.WriteLine($"You added an Ranger to your party! You have {partyLimit - i} spaces left.");
                        break;
                    case "Cleric":
                        Party.Add(allies[1]);
                        Console.WriteLine($"You added an Cleric to your party! You have {partyLimit - i} spaces left.");
                        break;
                    case "Fighter":
                        Party.Add(allies[2]);
                        Console.WriteLine($"You added an Fighter to your party! You have {partyLimit - i} spaces left.");
                        break;
                }
            }

        }//working
    }
}
