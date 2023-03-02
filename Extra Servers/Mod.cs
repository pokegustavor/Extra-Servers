using System;
using PulsarModLoader;

namespace Extra_Servers
{
    public class Mod : PulsarMod
    {

        public override string Version => "1.0";

        public override string Author => "pokegustavo";

        public override string ShortDescription => "Adds more Regions";

        public override string Name => "ExtraServers";

        public override string HarmonyIdentifier()
        {
            return "pokegustavo.ExtraServers";
        }
    }
}
