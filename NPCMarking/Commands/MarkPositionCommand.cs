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
    public class MarkPositionCommand : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;

        public string Name => "MarkPosition";

        public string Help => "Sets your Marker at specified NPC Flag Value";

        public string Syntax => "<FlagValue>";

        public List<string> Aliases => new List<string>() { "MPos" };

        public List<string> Permissions => new List<string>();

        public void Execute(IRocketPlayer caller, string[] command)
        {
            if (command.Length < 1)
            {
                UnturnedChat.Say(caller, NPCMarking.Instance.Translate("MarkPositionInvalid"), NPCMarking.Instance.MessageColour, true);
                return;
            }

            if (!short.TryParse(command[0], out short flagValue))
            {
                UnturnedChat.Say(caller, NPCMarking.Instance.Translate("MarkPositionFailedParse"), NPCMarking.Instance.MessageColour, true);
                return;
            }

            UnturnedPlayer player = (UnturnedPlayer)caller;

            player.Player.quests.replicateSetMarker(true, FlagConvertor.GetLocation(flagValue), flagValue.ToString());
            UnturnedChat.Say(caller, NPCMarking.Instance.Translate("MarkPositionSuccess", flagValue), NPCMarking.Instance.MessageColour, true);
        }
    }
}
