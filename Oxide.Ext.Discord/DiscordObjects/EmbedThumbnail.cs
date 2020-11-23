using Newtonsoft.Json;

namespace Oxide.Ext.Discord.DiscordObjects
{
    public class EmbedThumbnail
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("proxy_url")]
        public string ProxyUrl { get; set; }

        [JsonProperty("height")]
        public int? Height { get; set; }

        [JsonProperty("width")]
        public int? Width { get; set; }
    }
}