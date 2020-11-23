using Newtonsoft.Json;

namespace Oxide.Ext.Discord.DiscordEvents
{
    using Oxide.Ext.Discord.DiscordObjects;

    public class GuildMemberAdd : GuildMember
    {
        [JsonProperty("guild_id")]
        public string GuildId { get; set; }
    }
}
