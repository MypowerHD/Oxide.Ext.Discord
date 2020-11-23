using Newtonsoft.Json;

namespace Oxide.Ext.Discord.DiscordEvents
{
    using System.Collections.Generic;
    using Oxide.Ext.Discord.DiscordObjects;

    public class PresenceUpdate
    {
        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("roles")]
        public List<string> Roles { get; set; }

        [JsonProperty("game")]
        public Game Game { get; set; }

        [JsonProperty("guild_id")]
        public string GuildId { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
