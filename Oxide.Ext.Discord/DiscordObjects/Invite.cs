using Newtonsoft.Json;
using System;
using Oxide.Ext.Discord.REST;

namespace Oxide.Ext.Discord.DiscordObjects
{

    public class Invite
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("guild")]
        public Guild Guild { get; set; }

        [JsonProperty("channel")]
        public Channel Channel { get; set; }

        public static void GetInvite(DiscordClient client, string inviteCode, Action<Invite> callback = null)
        {
            client.REST.DoRequest($"/invites/{inviteCode}", RequestMethod.GET, null, callback);
        }

        public void DeleteInvite(DiscordClient client, Action<Invite> callback = null)
        {
            client.REST.DoRequest($"/invites/{Code}", RequestMethod.DELETE, null, callback);
        }

        public void AcceptInvite(DiscordClient client, Action<Invite> callback = null)
        {
            client.REST.DoRequest($"/invites/{Code}", RequestMethod.POST, null, callback);
        }
    }
}
