using NPCMarking.Services;
using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPCMarking.Commands
{
    public class GetClosestPositionCommand : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;

        public string Name => "GetClosestPosition";

        public string Help => "Gives and Marks your Closest possible Marker Position as it's Flag Value";

        public string Syntax => "";

        public List<string> Aliases => new List<string>() { "CPos" };

        public List<string> Permissions => new List<string>();

        public void Execute(IRocketPlayer caller, string[] command)
        {
            UnturnedPlayer player = (UnturnedPlayer)caller;

            short flagValue = FlagConvertor.GetClosestValueFromPosition(player.Position);
            player.Player.quests.replicateSetMarker(true, FlagConvertor.GetLocation(flagValue), flagValue.ToString());
            UnturnedChat.Say(caller, NPCMarking.Instance.Translate("GetClosestPositionSuccess", flagValue), NPCMarking.Instance.MessageColour, true);
        }
    }
}
