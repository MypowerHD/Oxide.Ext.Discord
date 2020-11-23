using Newtonsoft.Json;

namespace Oxide.Ext.Discord.DiscordObjects
{
    public class BanObject
    {
        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("guild_id")]
        public string GuildId { get; set; }
    }
}
