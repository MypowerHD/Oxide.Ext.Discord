using Newtonsoft.Json;

namespace Oxide.Ext.Discord.DiscordObjects
{

    public class Presence
    {
        [JsonProperty("status")]
        public string Status { get; set; } = "online";

        [JsonProperty("game")]
        public Game Game { get; set; }

        [JsonProperty("since")]
        public int? Since { get; set; }

        [JsonProperty("afk")]
        public bool Afk { get; set; }
    }
}
