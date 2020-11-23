using Newtonsoft.Json;

namespace Oxide.Ext.Discord.DiscordObjects
{
    public class ObjectPosition
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("position")]
        public int Position { get; set; }
    }
}
