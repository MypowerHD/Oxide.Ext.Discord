using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Oxide.Ext.Discord.REST;

namespace Oxide.Ext.Discord.DiscordObjects
{

    public class AuditLog
    {
        [JsonProperty("webhooks")]
        public List<Webhook> WebHooks { get; set; }

        [JsonProperty("users")]
        public List<User> Users { get; set; }
        
        [JsonProperty("audit_log_entries")]
        public List<AuditLogEntry> AuditLogEntries { get; set; }

        public static void GetGuildAuditLog(DiscordClient client, Guild guild, Action<AuditLog> callback = null) => GetGuildAuditLog(client, guild.Id, callback);
        
        public static void GetGuildAuditLog(DiscordClient client, string guildId, Action<AuditLog> callback = null)
        {
            client.REST.DoRequest($"/guilds/{guildId}/audit-logs", RequestMethod.GET, null, callback);
        }
    }
}
