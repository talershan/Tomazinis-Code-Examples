using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Final_Battle
{
    internal class Game
    {
        public void TakeTurn(Characters attacker, Parties attacked, Parties attacking)
        {
            int choice = 0;
            int enemyPartyNumber = 1;
            int attackWho = 0;
            Console.WriteLine($"It's {attacking.name}'s turn, go ahead {attacker.name}.");
            Console.WriteLine("What do you want to do?\n" +
                $"1. {attacker.attackType}\n" +
                "2. Do nothing\n" +
                "3. Heal\n"
                );
            choice = Convert.ToInt32(Console.ReadLine());


            switch (choice)
            {
                case 1:
                    {
                        Console.WriteLine($"Who do you want to {attacker.attackType}?");
                        for (int i = 0; i < attacked.Party.Count; i++)
                        {
                            Console.WriteLine($"{enemyPartyNumber}. {attacked.Party[i].name}");
                            enemyPartyNumber++;
                        }
                        attackWho = Convert.ToInt32(Console.ReadLine()) - 1;
                        attacker.Attack(attacker, attacked.Party[attackWho], attacked.Party, attackWho);
                        break;
                    }
                case 2:
                    Console.WriteLine(attacker.name + " did nothing.");
                    break;
                case 3:
                    attacker.Heal(attacker, attacker.damage);
                    break;
            }


        }
        public void AIPlayer(Characters attacker, List<Characters> HeroParty, Parties party)
        {
            Console.WriteLine($"It's {party.name}: {attacker.name}'s turn.");
            Thread.Sleep(1500);
            string[] possibleActions = new string[] { "attack", "sleep", "heal", "turn around", "do nothing" };
            Random random = new Random();
            int attackSelection = 0;
            int selectionIndex = random.Next(0, possibleActions.Length);
            switch (possibleActions[selectionIndex])
            {
                case "attack":
                    attackSelection = random.Next(0, HeroParty.Count);
                    attacker.Attack(attacker, HeroParty[attackSelection], HeroParty, attackSelection);
                    break;
                case "do nothing":
                    Console.WriteLine($"{attacker.name} did nothing.");
                    break;
                case "sleep":
                    Console.WriteLine($"{attacker.name} fell asleep");
                    break;
                case "turn around":
                    Console.WriteLine($"{attacker.name} seems to be confused and has turned around.");
                    break;
                case "heal":
                    attacker.Heal(attacker, 5);
                    break;
            }
            Thread.Sleep(1500);

        }

        public void DisplayBoard(Game game, List<Characters> HeroParty, List<Characters> EnemyParty)
        {
            Console.WriteLine("My Team");
            Console.WriteLine("__________________________________________________________________");
            for (int i = 0; i < HeroParty.Count; i++)
            {
                Console.Write($"{HeroParty[i].name} : {HeroParty[i].weapons}          ");
            }
            Console.WriteLine("\n");
            for (int i = 0; i < HeroParty.Count; i++)
            {
                Console.Write($"Health:{HeroParty[i].HP}/{HeroParty[i].MaxHP}       ");
            }
            Console.WriteLine("\n");

            Console.WriteLine();
            for (int i = 0; i < HeroParty.Count; i++)
            {
                Console.Write("X                  ");
            }
            Console.WriteLine("\n");
            Console.WriteLine("Enemy Team");
            Console.WriteLine("__________________________________________________________________");

            for (int i = 0; i < EnemyParty.Count; i++)
            {
                Console.Write($"{EnemyParty[i].name}            ");
            }
            Console.WriteLine("\n");
            for (int i = 0; i < EnemyParty.Count; i++)
            {
                Console.Write($"Health:{EnemyParty[i].HP}/{EnemyParty[i].MaxHP}          ");
            }
            Console.WriteLine("\n");
        }
        public bool BattleEnd(List<Characters> Party)
        {
            if (Party.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void PlayerGame(Game game, Characters character, Parties HeroParty, Parties EnemyParty1, Parties EnemyParty2, Parties FinalParty,string partyType)
        {
            Console.WriteLine("Use standard Party or make your own?");
            partyType = Console.ReadLine();

            switch (partyType)
            {
                case "standard party":
                    HeroParty.MakeStandardParty(HeroParty.Party);
                    break;

                case "make my own":
                    HeroParty.AddToParty(HeroParty.possibleAllies);
                    break;
            }
            Console.WriteLine("Generate an Inventory, or add your own items?");

            switch (Console.ReadLine())
            {
                case "generate":
                    HeroParty.GenerateInventory(character, HeroParty.possibleItems);
                    break;
                case "add my own":
                    game.Store(HeroParty.possibleItems, HeroParty.Party[0]);
                    break;
            }
            do
            {
                game.DoBattle(game, HeroParty, EnemyParty1);

                Console.WriteLine("Ah, you've beat your first battle, but lets see what you do next! \n");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine($"Welcome to Battle 2! This will be more challenging. Prepare yourself, {HeroParty.Party[0].name}!");

                game.DoBattle(game, HeroParty, EnemyParty2);

                Console.WriteLine("I see. So you think you can beat me, eh?\n" +
                    "Then lets go, let's fight! Prepare to die!");

                game.DoBattle(game, HeroParty, FinalParty);

                Console.WriteLine($"You have bested me. Very well. You can take my power. Good luck, {HeroParty.Party[0].name}.You're gonna need it.");

            } while (true);
        }

        public void MultiGame(Game game, Characters character, Parties HeroParty, Parties EnemyParty1, Parties EnemyParty2, Parties FinalParty, string partyType)
        {
            Console.WriteLine("Use standard Party or make your own?");
            partyType = Console.ReadLine();

            switch (partyType)
            {
                case "standard party":
                    HeroParty.MakeStandardParty(HeroParty.Party);
                    break;

                case "make my own":
                    HeroParty.AddToParty(HeroParty.possibleAllies);
                    break;
            }
            Console.WriteLine("Generate an Inventory, or add your own items?");

            switch (Console.ReadLine())
            {
                case "generate":
                    HeroParty.GenerateInventory(character, HeroParty.possibleItems);
                    break;
                case "add my own":
                    game.Store(HeroParty.possibleItems, HeroParty.Party[0]);
                    break;
            }
            do
            {
                game.DoBattleMulti(game, HeroParty, EnemyParty1);

                Console.WriteLine("Ah, you've beat your first battle, but lets see what you do next! \n");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine($"Welcome to Battle 2! This will be more challenging. Prepare yourself, {HeroParty.Party[0].name}!");

                game.DoBattleMulti(game, HeroParty, EnemyParty2);

                Console.WriteLine("I see. So you think you can beat me, eh?\n" +
                    "Then lets go, let's fight! Prepare to die!");

                game.DoBattleMulti(game, HeroParty, FinalParty);

                Console.WriteLine($"You have bested me. Very well. You can take my power. Good luck, {HeroParty.Party[0].name}.You're gonna need it.");

            } while (true);
        }

        public void AIGame(Game game, Parties HeroParty, Parties EnemyParty1, Parties EnemyParty2, string partyType)
        {
            HeroParty.GenerateParty(HeroParty.Party, HeroParty.possibleEnemies);
            Console.WriteLine("debug");

            do
            {
                game.DoBattleAI(game, HeroParty, EnemyParty1);

                Console.WriteLine("Ah, you've beat your first battle, but lets see what you do next! \n");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine($"Welcome to Battle 2! This will be more challenging. Prepare yourself, {HeroParty.Party[0].name}!");

                game.DoBattleAI(game, HeroParty, EnemyParty2);

            } while (true);
        }//working

    

        public void DoBattle(Game game, Parties HeroParty, Parties EnemyParty)
        {
            Console.WriteLine("Let the Battle begin! \n");
            while ((game.BattleEnd(EnemyParty.Party) == false) && (game.BattleEnd(HeroParty.Party) == false))
            {
                for (int i = 0; i < HeroParty.Party.Count; i++)
                {
                    game.DisplayBoard(game, HeroParty.Party, EnemyParty.Party);
                    game.TakeTurn(HeroParty.Party[i], EnemyParty, HeroParty);
                    if (game.BattleEnd(EnemyParty.Party))
                    {
                        break;
                    }
                    Thread.Sleep(1700);
                }

                if (game.BattleEnd(HeroParty.Party))
                {
                    break;
                }
                for (int i = 0; i < EnemyParty.Party.Count; i++)
                {
                    game.AIPlayer(EnemyParty.Party[i], HeroParty.Party, EnemyParty);
                    if (game.BattleEnd(HeroParty.Party))
                    {
                        break;
                    }
                }

            }
        }//working
        public void DoBattleMulti(Game game, Parties HeroParty, Parties EnemyParty)
        {
            Console.WriteLine("Let the Battle begin! \n");
            while ((game.BattleEnd(EnemyParty.Party) == false) && (game.BattleEnd(HeroParty.Party) == false))
            {
                for (int i = 0; i < HeroParty.Party.Count; i++)
                {
                    game.DisplayBoard(game, HeroParty.Party, EnemyParty.Party);
                    game.TakeTurn(HeroParty.Party[i], EnemyParty, HeroParty);
                    if (game.BattleEnd(EnemyParty.Party))
                    {
                        break;
                    }
                    Thread.Sleep(1700);
                }

                if (game.BattleEnd(HeroParty.Party))
                {
                    break;
                }
                for (int i = 0; i < EnemyParty.Party.Count; i++)
                {
                    
                    if (game.BattleEnd(HeroParty.Party))
                    {
                        break;
                    }
                    game.DisplayBoard(game, HeroParty.Party, EnemyParty.Party);
                    game.TakeTurn(EnemyParty.Party[i], HeroParty, EnemyParty);
                    if (game.BattleEnd(HeroParty.Party))
                    {
                        break;
                    }
                    Thread.Sleep(1700);
                }

            }
        }//working
        public void DoBattleAI(Game game, Parties HeroParty, Parties EnemyParty)
        {
            while ((game.BattleEnd(EnemyParty.Party) == false) && (game.BattleEnd(HeroParty.Party) == false))
            {
                game.DisplayBoard(game, HeroParty.Party, EnemyParty.Party);
                for (int i = 0; i < HeroParty.Party.Count; i++)
                {
                    game.AIPlayer(HeroParty.Party[i], EnemyParty.Party, HeroParty);
                    if (game.BattleEnd(EnemyParty.Party))
                    {
                        break;
                    }
                }

                if (game.BattleEnd(HeroParty.Party))
                {
                    break;
                }
                game.DisplayBoard(game, HeroParty.Party, EnemyParty.Party);
                for (int i = 0; i < EnemyParty.Party.Count; i++)
                {
                    game.AIPlayer(EnemyParty.Party[i], HeroParty.Party, EnemyParty);
                    if (game.BattleEnd(HeroParty.Party))
                    {
                        break;
                    }
                }
                
            }
        }//working


        public void Store(List<Items> storeInventory, Characters character)
        {
            int inventoryIndex = 1;
            string buyingChoice = "";
            int inventoryNumber = 0;
            Console.WriteLine("Welcome to my Shop!\n" +
                "What would you like to buy?\n" +
                $"Your available Gold: {character.Gold}");


            for (int i = 0; i < storeInventory.Count; i++)
            {
                Console.WriteLine($"{inventoryIndex}. {storeInventory[i].name} - {storeInventory[i].cost}gp, - {storeInventory[i].damage}");
                inventoryIndex++;
            }

            
            do
            {
                buyingChoice = Console.ReadLine();
                switch (buyingChoice)
                {
                    case "sword":
                        character.Gold -= storeInventory[0].cost;
                        character.AddToInventory(character, new Sword(10));
                        character.damage = storeInventory[0].damage;
                        character.weapons = Weapon.SWORD;
                        Console.WriteLine($"{character.Gold} gold left.");
                        break;
                    case "bow":
                        character.Gold -= storeInventory[1].cost;
                        character.AddToInventory(character, new Bow(10));
                        character.damage = storeInventory[1].damage;
                        character.weapons = Weapon.BOW;
                        Console.WriteLine($"{character.Gold} gold left.");
                        break;
                    case "bomb":
                        character.Gold -= storeInventory[2].cost;
                        character.AddToInventory(character, new Bomb(10));
                        character.damage = storeInventory[2].damage;
                        character.weapons = Weapon.BOMB;
                        Console.WriteLine($"{character.Gold} gold left.");
                        break;
                    case "stave":
                        character.Gold -= storeInventory[3].cost;
                        character.AddToInventory(character, new Stave(10));
                        character.damage = storeInventory[3].damage;
                        character.weapons = Weapon.STAVE;
                        Console.WriteLine($"{character.Gold} gold left.");
                        break;
                    case "scimitar":
                        character.Gold -= storeInventory[3].cost;
                        character.AddToInventory(character, new Scimitar(10));
                        character.damage = storeInventory[3].damage;
                        character.weapons = Weapon.SCIMITAR;
                        Console.WriteLine($"{character.Gold} gold left.");
                        break;
                    case "healing potion":
                        character.Gold -= storeInventory[3].cost;
                        character.AddToInventory(character, new HealingPotion(7));
                        Console.WriteLine($"{character.Gold} gold left.");
                        break;
                    case "potion of strength":
                        character.Gold -= storeInventory[3].cost;
                        character.AddToInventory(character, new BuffPotions(7));
                        Console.WriteLine($"{character.Gold} gold left.");
                        break;
                    case "knife":
                        character.Gold -= storeInventory[3].cost;
                        character.AddToInventory(character, new Knife(10));
                        character.damage = storeInventory[3].damage;
                        character.weapons = Weapon.KNIFE;
                        Console.WriteLine($"{character.Gold} gold left.");
                        break;
                }
                inventoryNumber++;
                continue;
            } while ((buyingChoice != "quit") && (inventoryNumber < 6));

            Console.WriteLine("Thanks for coming to my shop! See ya next time!");
            Thread.Sleep(1200);
        }     
    }
}
