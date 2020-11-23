using Newtonsoft.Json;

namespace Oxide.Ext.Discord.DiscordObjects
{

    public class Game
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public ActivityType Type { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
