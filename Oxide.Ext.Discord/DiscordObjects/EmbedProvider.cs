using Newtonsoft.Json;

namespace Oxide.Ext.Discord.DiscordObjects
{
    public class EmbedProvider
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}