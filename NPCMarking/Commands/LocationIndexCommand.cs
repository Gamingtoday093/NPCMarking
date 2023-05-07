using Rocket.API;
using Rocket.Unturned.Chat;
using SDG.Framework.Devkit;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPCMarking.Commands
{
    public class LocationIndexCommand : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;

        public string Name => "LocationIndex";

        public string Help => "Gives the Index of a Location by Name";

        public string Syntax => "<LocationName>";

        public List<string> Aliases => new List<string>() { "LI" };

        public List<string> Permissions => new List<string>();

        public void Execute(IRocketPlayer caller, string[] command)
        {
            if (command.Length < 1)
            {
                UnturnedChat.Say(caller, NPCMarking.Instance.Translate("LocationIndexInvalid"), NPCMarking.Instance.MessageColour, true);
                return;
            }

            IReadOnlyList<LocationDevkitNode> locations = LocationDevkitNodeSystem.Get().GetAllNodes();
            for (int lo = 0; lo < locations.Count; lo++)
            {
                if (locations[lo].locationName.IndexOf(command[0], StringComparison.InvariantCultureIgnoreCase) != -1)
                {
                    UnturnedChat.Say(caller, NPCMarking.Instance.Translate("LocationIndexSuccess", locations[lo].locationName, lo), NPCMarking.Instance.MessageColour, true);
                    return;
                }
            }

            UnturnedChat.Say(caller, NPCMarking.Instance.Translate("LocationIndexNotFound"), NPCMarking.Instance.MessageColour, true);
        }
    }
}
