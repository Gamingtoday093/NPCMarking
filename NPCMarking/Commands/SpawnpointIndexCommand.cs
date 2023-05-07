using Rocket.API;
using Rocket.Unturned.Chat;
using SDG.Framework.Devkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPCMarking.Commands
{
    public class SpawnpointIndexCommand : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;

        public string Name => "SpawnpointIndex";

        public string Help => "Gives the Index of a Spawnpoint by Name";

        public string Syntax => "<SpawnpointName>";

        public List<string> Aliases => new List<string>() { "SpI" };

        public List<string> Permissions => new List<string>();

        public void Execute(IRocketPlayer caller, string[] command)
        {
            if (command.Length < 1)
            {
                UnturnedChat.Say(caller, NPCMarking.Instance.Translate("SpawnpointIndexInvalid"), NPCMarking.Instance.MessageColour, true);
                return;
            }

            IReadOnlyList<Spawnpoint> spawnpoints = SpawnpointSystemV2.Get().GetAllSpawnpoints();
            for (int sp = 0; sp < spawnpoints.Count; sp++)
            {
                if (spawnpoints[sp].name.Equals(command[0]))
                {
                    UnturnedChat.Say(caller, NPCMarking.Instance.Translate("SpawnpointIndexSuccess", sp), NPCMarking.Instance.MessageColour, true);
                    return;
                }
            }

            UnturnedChat.Say(caller, NPCMarking.Instance.Translate("SpawnpointIndexNotFound"), NPCMarking.Instance.MessageColour, true);
        }
    }
}
