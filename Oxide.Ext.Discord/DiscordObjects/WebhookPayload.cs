using Newtonsoft.Json;
using System.Collections.Generic;

namespace Oxide.Ext.Discord.DiscordObjects
{

    public class WebhookPayload
    {
        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; }

        [JsonProperty("tts")]
        public bool Tts { get; set; }

        [JsonProperty("file")]
        public string File { get; set; }

        [JsonProperty("embeds")]
        public List<Embed> Embeds { get; set; }
    }
}
