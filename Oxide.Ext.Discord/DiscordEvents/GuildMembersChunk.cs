using Newtonsoft.Json;

namespace Oxide.Ext.Discord.DiscordEvents
{
    using System.Collections.Generic;
    using Oxide.Ext.Discord.DiscordObjects;

    public class GuildMembersChunk
    {
        [JsonProperty("guild_id")]
        public string GuildId { get; set; }

        [JsonProperty("members")]
        public List<GuildMember> Members { get; set; }
    }
}
