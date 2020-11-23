using Newtonsoft.Json;

namespace Oxide.Ext.Discord.DiscordEvents
{
    public class GuildIntergrationsUpdate
    {
        [JsonProperty("guild_id")]
        public string GuildId { get; set; }
    }
}
