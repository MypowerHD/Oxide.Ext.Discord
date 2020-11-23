using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;

namespace Oxide.Ext.Discord.DiscordObjects
{

    public class Connection
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("revoked")]
        [DefaultValue(false)]
        public bool Revoked { get; set; }

        [JsonProperty("integrations")]
        public List<Integration> Integrations { get; set; }
    }
}
