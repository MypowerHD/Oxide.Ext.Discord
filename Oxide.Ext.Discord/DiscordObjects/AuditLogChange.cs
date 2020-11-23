using Newtonsoft.Json;

namespace Oxide.Ext.Discord.DiscordObjects
{
    public class AuditLogChange
    {
        [JsonProperty("new_value")]
        public AuditLogChangeKey NewValue { get; set; }

        [JsonProperty("old_value")]
        public AuditLogChangeKey OldValue { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }
    }
}
