using Newtonsoft.Json;

namespace Oxide.Ext.Discord.DiscordObjects
{

    public class GuildMembersRequest
    {
        [JsonProperty("guild_id")]
        public string GuildId { get; set; }

        [JsonProperty("query")]
        public string Query { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; }
    }
}
