using Newtonsoft.Json;

namespace Oxide.Ext.Discord.DiscordObjects
{

    public class Resume
    {
        [JsonProperty("token")]
        public string Token;

        [JsonProperty("session_id")]
        public string SessionId;

        [JsonProperty("seq")]
        public int Sequence;
    }
}
