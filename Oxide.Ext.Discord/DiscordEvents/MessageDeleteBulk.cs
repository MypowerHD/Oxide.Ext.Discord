using Newtonsoft.Json;

namespace Oxide.Ext.Discord.DiscordEvents
{
    using System.Collections.Generic;

    public class MessageDeleteBulk
    {
        [JsonProperty("ids")]
        public List<string> Ids { get; set; }

        [JsonProperty("channel_id")]
        public string ChannelId { get; set; }
    }
}
