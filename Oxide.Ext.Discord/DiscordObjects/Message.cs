using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Oxide.Ext.Discord.Helpers;
using Oxide.Ext.Discord.REST;

namespace Oxide.Ext.Discord.DiscordObjects
{
    
    public class Message
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("channel_id")]
        public string ChannelId { get; set; }

        [JsonProperty("guild_id")]
        public string GuildId { get; set; }

        [JsonProperty("author")]
        public User Author { get; set; }

        [JsonProperty("member")]
        public GuildMember Member { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }

        [JsonProperty("edited_timestamp")]
        public string EditedTimestamp { get; set; }

        [JsonProperty("tts")]
        public bool Tts { get; set; }

        [JsonProperty("mention_everyone")]
        public bool MentionEveryone { get; set; }

        [JsonProperty("mentions")]
        public List<User> Mentions { get; set; }

        [JsonProperty("mention_roles")]
        public List<string> MentionRoles { get; set; }

        [JsonProperty("attachments")]
        public List<Attachment> Attachments { get; set; }

        [JsonProperty("embed")]
        public Embed Embed { get; set; }

        [JsonProperty("embeds")]
        public List<Embed> Embeds { get; set; }

        [JsonProperty("reactions")]
        public List<Reaction> Reactions { get; set; }

        [JsonProperty("nonce")]
        public string Nonce { get; set; }

        [JsonProperty("pinned")]
        public bool Pinned { get; set; }

        [JsonProperty("webhook_id")]
        public string WebHookId { get; set; }

        [JsonProperty("type")]
        public MessageType? Type { get; set; }

        public void Reply(DiscordClient client, Message message, bool ping = true, Action<Message> callback = null)
        {
            if (ping && !string.IsNullOrEmpty(message.Content) && !message.Content.Contains($"<@{Author.Id}>"))
            {
                message.Content = $"<@{Author.Id}> {message.Content}";
            }

            client.REST.DoRequest($"/channels/{ChannelId}/messages", RequestMethod.POST, message, callback);
        }

        public void Reply(DiscordClient client, string message, bool ping = true, Action<Message> callback = null)
        {
            Message newMessage = new Message()
            {
                Content = ping ? $"<@{Author.Id}> {message}" : message
            };

            Reply(client, newMessage, ping, callback);
        }

        public void Reply(DiscordClient client, Embed embed, bool ping = true, Action<Message> callback = null)
        {
            Message newMessage = new Message()
            {
                Content = ping ? $"<@{Author.Id}>" : null,
                Embed = embed
            };

            Reply(client, newMessage, ping, callback);
        }

        public void CreateReaction(DiscordClient client, string emoji, Action callback = null)
        {
            client.REST.DoRequest($"/channels/{ChannelId}/messages/{Id}/reactions/{emoji}/@me", RequestMethod.PUT, null, callback);
        }

        public void DeleteOwnReaction(DiscordClient client, string emoji, Action callback = null)
        {
            client.REST.DoRequest($"/channels/{ChannelId}/messages/{Id}/reactions/{emoji}/@me", RequestMethod.DELETE, null, callback);
        }

        public void DeleteUserReaction(DiscordClient client, string emoji, User user, Action callback = null) => DeleteUserReaction(client, emoji, user.Id, callback);

        public void DeleteUserReaction(DiscordClient client, string emoji, string userId, Action callback = null)
        {
            client.REST.DoRequest($"/channels/{ChannelId}/messages/{Id}/reactions/{emoji}/{userId}", RequestMethod.DELETE, null, callback);
        }

        public void GetReactions(DiscordClient client, string emoji, Action<List<User>> callback = null)
        {
            byte[] encodedEmoji = Encoding.UTF8.GetBytes(emoji);
            string hexString = HttpUtility.UrlEncode(encodedEmoji);

            client.REST.DoRequest($"/channels/{ChannelId}/messages/{Id}/reactions/{hexString}", RequestMethod.GET, null, callback);
        }

        public void DeleteAllReactions(DiscordClient client, Action callback = null)
        {
            client.REST.DoRequest($"/channels/{ChannelId}/messages/{Id}/reactions", RequestMethod.DELETE, null, callback);
        }

        public void EditMessage(DiscordClient client, Action<Message> callback = null)
        {
            client.REST.DoRequest<Message>($"/channels/{ChannelId}/messages/{Id}", RequestMethod.PATCH, this, callback);
        }

        public void DeleteMessage(DiscordClient client, Action<Message> callback = null)
        {
            client.REST.DoRequest<Message>($"/channels/{ChannelId}/messages/{Id}", RequestMethod.DELETE, null, callback);
        }

        public void AddPinnedChannelMessage(DiscordClient client, Action callback = null)
        {
            client.REST.DoRequest($"/channels/{ChannelId}/pins/{Id}", RequestMethod.PUT, null, callback);
        }

        public void DeletePinnedChannelMessage(DiscordClient client, Action callback = null)
        {
            client.REST.DoRequest($"/channels/{ChannelId}/pins/{Id}", RequestMethod.DELETE, null, callback);
        }
    }
}
