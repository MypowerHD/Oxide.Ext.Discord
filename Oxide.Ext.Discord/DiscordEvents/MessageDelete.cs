using Newtonsoft.Json;

namespace Oxide.Ext.Discord.DiscordEvents
{
    public class MessageDelete
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("channel_id")]
        public string ChannelId { get; set; }
    }
}
