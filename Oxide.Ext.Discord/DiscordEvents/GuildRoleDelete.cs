using Newtonsoft.Json;

namespace Oxide.Ext.Discord.DiscordEvents
{
    public class GuildRoleDelete
    {
        [JsonProperty("guild_id")]
        public string GuildId { get; set; }

        [JsonProperty("role_id")]
        public string RoleId { get; set; }
    }
}
