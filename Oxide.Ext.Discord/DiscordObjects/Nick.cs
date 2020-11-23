using Newtonsoft.Json;
using System.Collections.Generic;

namespace Oxide.Ext.Discord.DiscordObjects
{

    public class Nick
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("nick")]
        public string Username { get; set; }
     
        public static implicit operator KeyValuePair<string, string>(Nick nick) => new KeyValuePair<string, string>(nick.Id, nick.Username);
    }
}
