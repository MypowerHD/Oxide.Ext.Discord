using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Oxide.Ext.Discord.REST;

namespace Oxide.Ext.Discord.DiscordObjects
{

    public class User
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }

        [JsonProperty("avatar")]
        public string Avatar { get; set; }

        [JsonProperty("bot")]
        [DefaultValue(false)]
        public bool Bot { get; set; }

        [JsonProperty("mfa_enabled")]
        [DefaultValue(false)]
        public bool MfaEnabled { get; set; }

        [JsonProperty("locale")]
        public string Locale { get; set; }

        [JsonProperty("verified")]
        [DefaultValue(false)]
        public bool Verified { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("premium_type")]
        public UserPremiumType? PremiumType { get; set; }

        public static void GetCurrentUser(DiscordClient client, Action<User> callback = null)
        {
            client.REST.DoRequest($"/users/@me", RequestMethod.GET, null, callback);
        }

        public static void GetUser(DiscordClient client, string userId, Action<User> callback = null)
        {
            client.REST.DoRequest($"/users/{userId}", RequestMethod.GET, null, callback);
        }

        public void ModifyCurrentUser(DiscordClient client, Action<User> callback = null) => ModifyCurrentUser(client, this.Username, this.Avatar, callback);

        public void ModifyCurrentUser(DiscordClient client, string username = "", string avatarData = "", Action<User> callback = null)
        {
            var jsonObj = new Dictionary<string, string>()
            {
                { "username", username },
                { "avatar", avatarData }
            };

            client.REST.DoRequest($"/users/@me", RequestMethod.PATCH, jsonObj, callback);
        }

        public void GetCurrentUserGuilds(DiscordClient client, Action<List<Guild>> callback = null)
        {
            client.REST.DoRequest($"/users/@me/guilds", RequestMethod.GET, null, callback);
        }

        public void LeaveGuild(DiscordClient client, Guild guild, Action callback = null) => LeaveGuild(client, guild.Id, callback);

        public void LeaveGuild(DiscordClient client, string guildId, Action callback = null)
        {
            client.REST.DoRequest($"/users/@me/guilds/{guildId}", RequestMethod.DELETE, null, callback);
        }

        public void GetUserDMs(DiscordClient client, Action<List<Channel>> callback = null)
        {
            client.REST.DoRequest($"/users/@me/channels", RequestMethod.GET, null, callback);
        }

        public void CreateDm(DiscordClient client, Action<Channel> callback = null)
        {
            var jsonObj = new Dictionary<string, string>()
            {
                { "recipient_id", this.Id }
            };

            client.REST.DoRequest("/users/@me/channels", RequestMethod.POST, jsonObj, callback);
        }

        public void CreateGroupDm(DiscordClient client, string[] accessTokens, List<Nick> nicks, Action<Channel> callback = null)
        {
            var nickDict = nicks.ToDictionary(k => k.Id, v => v.Username);

            var jsonObj = new Dictionary<string, object>()
            {
                { "access_tokens", accessTokens },
                { "nicks", nicks }
            };

            client.REST.DoRequest($"/users/@me/channels", RequestMethod.POST, jsonObj, callback);
        }

        public void GetUserConnections(DiscordClient client, Action<List<Connection>> callback = null)
        {
            client.REST.DoRequest($"/users/@me/connections", RequestMethod.GET, null, callback);
        }

        public void GroupDmAddRecipient(DiscordClient client, Channel channel, string accessToken, Action callback = null) => GroupDmAddRecipient(client, channel.Id, accessToken, this.Username, callback);

        public void GroupDmAddRecipient(DiscordClient client, string channelId, string accessToken, string nick, Action callback = null)
        {
            var jsonObj = new Dictionary<string, string>()
            {
                { "access_token", accessToken },
                { "nick", nick }
            };

            client.REST.DoRequest($"/channels/{channelId}/recipients/{Id}", RequestMethod.PUT, jsonObj, callback);
        }

        public void GroupDmRemoveRecipient(DiscordClient client, Channel channel) => GroupDmRemoveRecipient(client, channel.Id);

        public void GroupDmRemoveRecipient(DiscordClient client, string channelId, Action callback = null)
        {
            client.REST.DoRequest($"/channels/{channelId}/recipients/{Id}", RequestMethod.DELETE, null, callback);
        }

        public void Update(User updatedUser)
        {
            if (updatedUser.Avatar != null)
                this.Avatar = updatedUser.Avatar;
            //if (updateduser.Bot != null)
            //    this.Bot = updateduser.Bot;
            if (updatedUser.Discriminator != null)
                this.Discriminator = updatedUser.Discriminator;
            if (updatedUser.Email != null)
                this.Email = updatedUser.Email;
            if (updatedUser.Locale != null)
                this.Locale = updatedUser.Locale;
            //if (updateduser.MfaEnabled != null)
            //    this.MfaEnabled = updateduser.MfaEnabled;
            if (updatedUser.PremiumType != null)
                this.PremiumType = updatedUser.PremiumType;
            if (updatedUser.Username != null)
                this.Username = updatedUser.Username;
            //if (updateduser.Verified != null)
            //    this.Verified = updateduser.Verified;
        }
    }
}
