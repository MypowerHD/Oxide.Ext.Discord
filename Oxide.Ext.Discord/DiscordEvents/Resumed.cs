using Newtonsoft.Json;

namespace Oxide.Ext.Discord.DiscordEvents
{
    using System.Collections.Generic;

    public class Resumed
    {
        [JsonProperty("_trace")]
        public List<string> Trace { get; set; }
    }
}
