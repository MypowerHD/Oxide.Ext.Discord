using Newtonsoft.Json;

namespace Oxide.Ext.Discord.DiscordEvents
{
    public class MessageReactionRemoveAll
    {
        [JsonProperty("channel_id")]
        public string ChannelId { get; set; }

        [JsonProperty("message_id")]
        public string MessageId { get; set; }
    }
}
