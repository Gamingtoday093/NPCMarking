using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocket.API;

namespace NPCMarking
{
    public class NPCMarkingConfiguration : IRocketPluginConfiguration
    {
        public string MessageColour { get; set; }

        public ushort MarkerFlagId { get; set; }
        public ushort SpawnpointFlagId { get; set; }
        public ushort LocationFlagId { get; set; }

        public void LoadDefaults()
        {
            MessageColour = "Green";

            MarkerFlagId = 42672;
            SpawnpointFlagId = 42673;
            LocationFlagId = 42674;
        }
    }
}
