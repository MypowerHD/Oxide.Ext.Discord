using Newtonsoft.Json;

namespace Oxide.Ext.Discord.DiscordEvents
{
    using System.Collections.Generic;
    using Oxide.Ext.Discord.DiscordObjects;

    public class GuildEmojisUpdate
    {
        [JsonProperty("guild_id")]
        public string GuildId { get; set; }

        [JsonProperty("emojis")]
        public List<Emoji> Emojis { get; set; }
    }
}
