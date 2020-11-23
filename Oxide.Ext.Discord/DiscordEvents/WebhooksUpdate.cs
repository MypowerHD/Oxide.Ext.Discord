using Newtonsoft.Json;

namespace Oxide.Ext.Discord.DiscordEvents
{
    public class WebHooksUpdate
    {
        [JsonProperty("guild_id")]
        public string GuildId { get; set; }

        [JsonProperty("channel_id")]
        public string ChannelId { get; set; }
    }
}
