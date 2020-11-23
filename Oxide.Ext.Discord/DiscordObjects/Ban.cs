using Newtonsoft.Json;

namespace Oxide.Ext.Discord.DiscordObjects
{
    public class Ban
    {
        [JsonProperty("reason")]
        public string Reason { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }
    }
}
