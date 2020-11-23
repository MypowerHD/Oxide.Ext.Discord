using Newtonsoft.Json;

namespace Oxide.Ext.Discord.DiscordEvents
{
    using Oxide.Ext.Discord.DiscordObjects;

    public class GuildRoleUpdate
    {
        [JsonProperty("guild_id")]
        public string GuildId { get; set; }

        [JsonProperty("role")]
        public Role Role { get; set; }
    }
}
