using Newtonsoft.Json;

namespace Oxide.Ext.Discord.DiscordObjects
{
    public class InviteCreated
    {
        [JsonProperty("channel_id")]
        public string ChannelId { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty("guild_id")]
        public string GuildId { get; set; }

        [JsonProperty("inviter")]
        public User Inviter { get; set; }

        [JsonProperty("max_age")]
        public int? MaxAge { get; set; }

        [JsonProperty("max_uses")]
        public int? MaxUses { get; set; }

        [JsonProperty("temporary")]
        public bool? Temporary { get; set; }

        [JsonProperty("uses")]
        public int? Uses { get; set; }
    }
}
