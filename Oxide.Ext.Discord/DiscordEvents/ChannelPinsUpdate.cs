using Newtonsoft.Json;

namespace Oxide.Ext.Discord.DiscordEvents
{
    public class ChannelPinsUpdate
    {
        [JsonProperty("channel_id")]
        public string ChannelId { get; set; }

        [JsonProperty("last_pin_timestamp")]
        public string LastPinTimestamp { get; set; }
    }
}
