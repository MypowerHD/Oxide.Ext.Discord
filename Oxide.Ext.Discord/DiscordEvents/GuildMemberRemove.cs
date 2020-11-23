using Newtonsoft.Json;

namespace Oxide.Ext.Discord.DiscordEvents
{
    using Oxide.Ext.Discord.DiscordObjects;

    public class GuildMemberRemove
    {
        [JsonProperty("guild_id")]
        public string GuildId { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }
    }
}
