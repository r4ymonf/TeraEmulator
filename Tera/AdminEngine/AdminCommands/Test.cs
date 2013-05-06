using Data.Enums;
using Data.Interfaces;
using Network.Server;

namespace Tera.AdminEngine.AdminCommands
{
    class Test : ACommand
    {
        public override void Process(IConnection connection, string msg)
        {
            Communication.Global.StatsService.UpdateStats(connection.Player);
			new SpSystemNotice("Welcome to our Server enjoy!").Send(connection);

            
            //int counter = 0;

            //connection.Player.Recipes = new List<int>();

            //foreach (var VARIABLE in Data.Data.Recipes)
            //{
            //    connection.Player.Recipes.Add(VARIABLE.Key);
            //    if (connection.Player.Recipes.Count >= 20)
            //        break;
            //}
            //new SpCharacterRecipes(connection.Player.Recipes.Select(recipe => Data.Data.Recipes[recipe]).ToList()).Send(connection);
            //new SpCharacterRecipes(null, true).Send(connection);
            //
        }
    }
}
