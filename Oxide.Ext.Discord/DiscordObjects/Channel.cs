using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Oxide.Ext.Discord.REST;

namespace Oxide.Ext.Discord.DiscordObjects
{

    public class Channel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public ChannelType? Type { get; set; }

        [JsonProperty("guild_id")]
        public string GuildId { get; set; }

        [JsonProperty("position")]
        public int? Position { get; set; }

        [JsonProperty("permission_overwrites")]
        public List<Overwrite> PermissionOverwrites { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("topic")]
        public string Topic { get; set; }

        [JsonProperty("nsfw")]
        [DefaultValue(false)]
        public bool Nsfw { get; set; }

        [JsonProperty("last_message_id")]
        public string LastMessageId { get; set; }

        [JsonProperty("bitrate")]
        [DefaultValue(0)]
        public int BitRate { get; set; }

        [JsonProperty("user_limit")]
        [DefaultValue(0)]
        public int UserLimit { get; set; }

        [JsonProperty("rate_limit_per_user")]
        [DefaultValue(0)]
        public int RateLimitPerUser { get; set; }

        [JsonProperty("recipients")]
        public List<User> Recipients { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("owner_id")]
        public string OwnerId { get; set; }

        [JsonProperty("application_id")]
        public string ApplicationId { get; set; }

        [JsonProperty("parent_id")]
        public string ParentId { get; set; }

        [JsonProperty("last_pin_timestamp")]
        // TODO: Parse to DateTime
        public string LastPinTimestamp { get; set; } 

        public static void GetChannel(DiscordClient client, string channelId, Action<Channel> callback = null)
        {
            client.REST.DoRequest($"/channels/{channelId}", RequestMethod.GET, null, callback);
        }

        public void ModifyChannel(DiscordClient client, Channel newChannel, Action<Channel> callback = null)
        {
            client.REST.DoRequest($"/channels/{Id}", RequestMethod.PATCH, newChannel, callback);
        }

        public void DeleteChannel(DiscordClient client, Action<Channel> callback = null)
        {
            client.REST.DoRequest($"/channels/{Id}", RequestMethod.DELETE, null, callback);
        }

        public void GetChannelMessages(DiscordClient client, Action<List<Message>> callback = null)
        {
            client.REST.DoRequest($"/channels/{Id}/messages", RequestMethod.GET, null, callback);
        }

        public void GetChannelMessage(DiscordClient client, Message message, Action<Message> callback = null) => GetChannelMessage(client, message.Id, callback);

        public void GetChannelMessage(DiscordClient client, string messageId, Action<Message> callback = null)
        {
            client.REST.DoRequest($"/channels/{Id}/messages/{messageId}", RequestMethod.GET, null, callback);
        }

        public void CreateMessage(DiscordClient client, Message message, Action<Message> callback = null)
        {
            client.REST.DoRequest($"/channels/{Id}/messages", RequestMethod.POST, message, callback);
        }

        public void CreateMessage(DiscordClient client, string message, Action<Message> callback = null)
        {
            Message createMessage = new Message()
            {
                Content = message
            };

            client.REST.DoRequest($"/channels/{Id}/messages", RequestMethod.POST, createMessage, callback);
        }

        public void CreateMessage(DiscordClient client, Embed embed, Action<Message> callback = null)
        {
            Message createMessage = new Message()
            {
                Embed = embed
            };

            client.REST.DoRequest($"/channels/{Id}/messages", RequestMethod.POST, createMessage, callback);
        }

        public void BulkDeleteMessages(DiscordClient client, string[] messageIds, Action callback = null)
        {
            var jsonObj = new Dictionary<string, string[]>()
            {
                { "messages", messageIds }
            };

            client.REST.DoRequest($"/channels/{Id}/messages/bulk-delete", RequestMethod.POST, jsonObj, callback);
        }

        public void EditChannelPermissions(DiscordClient client, Overwrite overwrite, int? allow, int? deny, string type) => EditChannelPermissions(client, overwrite.Id, allow, deny, type);

        public void EditChannelPermissions(DiscordClient client, string overwriteId, int? allow, int? deny, string type, Action callback = null)
        {
            var jsonObj = new Dictionary<string, object>()
            {
                { "allow", allow },
                { "deny", deny },
                { "type", type }
            };

            client.REST.DoRequest($"/channels/{Id}/permissions/{overwriteId}", RequestMethod.PUT, jsonObj, callback);
        }

        public void GetChannelInvites(DiscordClient client, Action<List<Invite>> callback = null)
        {
            client.REST.DoRequest($"/channels/{Id}/invites", RequestMethod.GET, null, callback);
        }

        public void CreateChannelInvite(DiscordClient client, Action<Invite> callback = null, int? maxAge = 86400, int? maxUses = 0, bool temporary = false, bool unique = false)
        {
            var jsonObj = new Dictionary<string, object>()
            {
                { "max_age", maxAge },
                { "max_uses", maxUses },
                { "temporary", temporary },
                { "unique", unique }
            };

            client.REST.DoRequest<Invite>($"/channels/{Id}/invites", RequestMethod.POST, jsonObj, callback);
        }

        public void DeleteChannelPermission(DiscordClient client, Overwrite overwrite, Action callback) => DeleteChannelPermission(client, overwrite.Id, callback);

        public void DeleteChannelPermission(DiscordClient client, string overwriteId, Action callback)
        {
            client.REST.DoRequest($"/channels/{Id}/permissions/{overwriteId}", RequestMethod.DELETE, null, callback);
        }

        public void TriggerTypingIndicator(DiscordClient client, Action callback)
        {
            client.REST.DoRequest($"/channels/{Id}/typing", RequestMethod.POST, null, callback);
        }

        public void GetPinnedMessages(DiscordClient client, Action<List<Message>> callback = null)
        {
            client.REST.DoRequest<List<Message>>($"/channels/{Id}/pins", RequestMethod.GET, null, callback);
        }

        public void GroupDmAddRecipient(DiscordClient client, User user, string accessToken, Action callback = null) => GroupDmAddRecipient(client, user.Id, accessToken, user.Username, callback);

        public void GroupDmAddRecipient(DiscordClient client, string userId, string accessToken, string nick, Action callback = null)
        {
            var jsonObj = new Dictionary<string, string>()
            {
                { "access_token", accessToken },
                { "nick", nick }
            };

            client.REST.DoRequest($"/channels/{Id}/recipients/{userId}", RequestMethod.PUT, jsonObj, callback);
        }

        public void GroupDmRemoveRecipient(DiscordClient client, string userId, Action callback)
        {
            client.REST.DoRequest($"/channels/{Id}/recipients/{userId}", RequestMethod.DELETE, null, callback);
        }
    }
}