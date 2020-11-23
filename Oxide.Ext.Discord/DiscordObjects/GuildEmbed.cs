using Newtonsoft.Json;

namespace Oxide.Ext.Discord.DiscordObjects
{
    public class GuildEmbed
    {
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("channel_id")]
        public string ChannelId { get; set; }
    }
}
