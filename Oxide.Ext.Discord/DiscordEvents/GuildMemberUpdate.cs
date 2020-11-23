using Newtonsoft.Json;

namespace Oxide.Ext.Discord.DiscordEvents
{
    using System.Collections.Generic;
    using Oxide.Ext.Discord.DiscordObjects;

    public class GuildMemberUpdate
    {
        [JsonProperty("guild_id")]
        public string GuildId { get; set; }

        [JsonProperty("roles")]
        public List<string> Roles { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("nick")]
        public string Nick { get; set; }
    }
}
