using System.ComponentModel;
using Newtonsoft.Json;

namespace Oxide.Ext.Discord.DiscordEvents
{
    public class GuildBan
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }

        [JsonProperty("avatar")]
        public string Avatar { get; set; }

        [JsonProperty("bot")]
        [DefaultValue(false)]
        public bool Bot { get; set; }

        [JsonProperty("guild_id")]
        public string GuildId { get; set; }
    }
}
