using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPCMarking.Commands
{
    public class ClosestLocationIndexCommand : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;

        public string Name => "ClosestLocationIndex";

        public string Help => "Gives your closest Locations Index";

        public string Syntax => "";

        public List<string> Aliases => new List<string>() { "CLI" };

        public List<string> Permissions => new List<string>();

        public void Execute(IRocketPlayer caller, string[] command)
        {
            UnturnedPlayer player = (UnturnedPlayer)caller;

            IReadOnlyList<LocationDevkitNode> locations = LocationDevkitNodeSystem.Get().GetAllNodes();
            if (locations.Count < 1) return;
            
            LocationDevkitNode closestLocation = locations[0];
            int lo;
            for (lo = 1; lo < locations.Count; lo++)
            {
                if ((locations[lo].transform.position - player.Position).sqrMagnitude < (closestLocation.transform.position - player.Position).sqrMagnitude)
                {
                    closestLocation = locations[lo];
                }
            }

            UnturnedChat.Say(caller, NPCMarking.Instance.Translate("LocationIndexSuccess", closestLocation.locationName, lo), NPCMarking.Instance.MessageColour, true);
        }
    }
}
