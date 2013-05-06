using Data.Enums;
using Data.Interfaces;
using Network.Server;

/**
 * Class ViewMember
 * Allow GMs to view location and controller
 * information for users.
 * Usage : `viewmember {type} {player}
 * type string
 * player string
 * Types : position, controller, showpos
 * ------------------------------
 * Copyright (c) 2013 Uebari, formatme
 * TeraEmulator
 * Version: 1725-001 Beta
 * This source is Open under GPL License
 * --------------------------------
*/
namespace Tera.AdminEngine.AdminCommands
{
    class ViewMember : ACommand
    {
        public override void Process(IConnection connection, string msg)
        {
            try
            {
                string result = "";
                var args = msg.Split(' ');
                var player = Communication.Global.PlayerService.GetPlayerByName(args[0]);

                if(player == null)
                {
                    new SpChatMessage("Cannot find a player with such name!", ChatType.Notice).Send(connection);
                    return;
                }

                switch (args[1])
                {
                    case "position":
                        result = "Character position X= " + connection.Player.Position.X + ";\nY= " +
                            connection.Player.Position.Y + ";\nZ= " + connection.Player.Position.Z + ";\nMapId= " +
                            connection.Player.Position.MapId;
                        break;
                    case "controller":
                        result = "Controller = " + player.Controller;
                        break;
                    case "showpos": // Show Complete Positioning
                        result = "Position Identifier: \n X= " + connection.Player.Position.X + ";\n Y= " +
                            connection.Player.Position.Y + ";\nZ= " + connection.Player.Position.Z + ";\nMapID= " +
                            connection.Player.Position.MapId + ";\nHeading= " + connection.Player.Position.Heading;
                        break;
                }
                new SpChatMessage(connection.Player, result, ChatType.Notice).Send(connection);
            }
            catch
            {
                //Nothing
            }
        }
    }
}
