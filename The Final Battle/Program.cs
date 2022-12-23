// See https://aka.ms/new-console-template for more information
using The_Final_Battle;

string partyType = "";
Parties EnemyParty1 = new Parties("Enemy");
Parties EnemyParty2 = new Parties("Enemy");
Parties FinalParty = new Parties("Enemy");
Parties HeroParty = new Parties("Hero");
Game game = new Game();
Player player = new Player(15, 30, HeroParty.Party);
Final_Boss UncodedOne = new Final_Boss(25, "The Uncoded One", FinalParty, 5);
player.CollectName();
EnemyParty1.GenerateParty(EnemyParty1.Party, EnemyParty1.possibleEnemies);
EnemyParty2.GenerateParty(EnemyParty2.Party, EnemyParty2.possibleEnemies);
UncodedOne.FinalBattle(FinalParty.Party, FinalParty.possibleEnemies);

Console.WriteLine("Would you like a player controlled game, an AI game, or a multiplayer game?");

switch (Console.ReadLine())
{
    case "player":
        game.PlayerGame(game, player, HeroParty, EnemyParty1, EnemyParty2, FinalParty,partyType);
        break;

    case "AI":
        game.AIGame(game, HeroParty, EnemyParty1, EnemyParty2, partyType);
        break;
    case "multiplayer":
        game.MultiGame(game, player, HeroParty, EnemyParty1, EnemyParty2, FinalParty, partyType);
        break;
}
