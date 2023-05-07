using NPCMarking.Services;
using Rocket.API.Collections;
using Rocket.Core.Plugins;
using Rocket.Unturned.Chat;
using SDG.Framework.Devkit;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Logger = Rocket.Core.Logging.Logger;

namespace NPCMarking
{
    public class NPCMarking : RocketPlugin<NPCMarkingConfiguration>
    {
        public static NPCMarking Instance { get; private set; }
        public static NPCMarkingConfiguration Config { get; private set; }

        public Color MessageColour { get; private set; }

        protected override void Load()
        {
            Instance = this;
            Config = Configuration.Instance;

            MessageColour = UnturnedChat.GetColorFromName(Config.MessageColour, Color.green);

            PlayerQuests.onAnyFlagChanged += OnFlagChanged;

            Logger.Log($"{Name} {Assembly.GetName().Version} by Gamingtoday093 has been Loaded");
        }

        protected override void Unload()
        {
            PlayerQuests.onAnyFlagChanged -= OnFlagChanged;

            Logger.Log($"{Name} has been Unloaded");
        }

        private void OnFlagChanged(PlayerQuests quests, PlayerQuestFlag flag)
        {
            Vector3 newMarkerLocation;
            if (flag.id == Config.MarkerFlagId) FlagValueToMarkerLocation(flag.value, out newMarkerLocation);
            else if (flag.id == Config.SpawnpointFlagId)
            {
                if (!FlagValueToSpawnpoint(flag.value, out newMarkerLocation)) return;
            }
            else if (flag.id == Config.LocationFlagId)
            {
                if (!FlagValueToLocation(flag.value, out newMarkerLocation)) return;
            }
            else return;

            quests.replicateSetMarker(true, newMarkerLocation);
        }

        public void FlagValueToMarkerLocation(short Value, out Vector3 MarkerLocation)
        {
            MarkerLocation = FlagConvertor.GetLocation(Value);
        }

        public bool FlagValueToSpawnpoint(short Value, out Vector3 Spawnpoint)
        {
            Spawnpoint = Vector3.zero;
            if (Value < 0) return false;
            IReadOnlyList<Spawnpoint> spawnpoints = SpawnpointSystemV2.Get().GetAllSpawnpoints();
            if (Value > spawnpoints.Count - 1) return false;

            Spawnpoint = spawnpoints[Value].transform.position;
            return true;
        }

        public bool FlagValueToLocation(short Value, out Vector3 Location)
        {
            Location = Vector3.zero;
            if (Value < 0) return false;
            IReadOnlyList<LocationDevkitNode> locations = LocationDevkitNodeSystem.Get().GetAllNodes();
            if (Value > locations.Count - 1) return false;

            Location = locations[Value].transform.position;
            return true;
        }

        public override TranslationList DefaultTranslations => new TranslationList()
        {
            { "GetClosestPositionSuccess", "Your closest possible Marker Position has been Marked and has the Flag Value of {0}" },
            { "MarkPositionInvalid", "You must Specify Flag Value!" },
            { "MarkPositionFailedParse", "Failed to Parse Flag Value!" },
            { "MarkPositionSuccess", "Successfully Marked {0} on your Map" },

            { "SpawnpointIndexInvalid", "You must Specify Spawnpoint Name!" },
            { "SpawnpointIndexNotFound", "Spawnpoint not Found!" },
            { "SpawnpointIndexSuccess", "The Spawnpoint Index is {0}" },

            { "LocationIndexInvalid", "You must Specify Location Name!" },
            { "LocationIndexNotFound", "Location not Found!" },
            { "LocationIndexSuccess", "The Location Index of {0} is {1}" },
        };
    }
}
