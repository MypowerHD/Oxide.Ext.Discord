using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Oxide.Ext.Discord.REST;

namespace Oxide.Ext.Discord.DiscordObjects
{

    public class Guild
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("splash")]
        public string Splash { get; set; }

        [JsonProperty("discovery_splash")]
        public string DiscoverySplash { get; set; }

        [JsonProperty("owner")]
        public bool Owner { get; set; }

        [JsonProperty("owner_id")]
        public string OwnerId { get; set; }

        [JsonProperty("permissions")]
        public int? Permissions { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("afk_channel_id")]
        public string AfkChannelId { get; set; }

        [JsonProperty("afk_timeout")]
        public int? AfkTimeout { get; set; }

        [JsonProperty("embed_enabled")]
        public bool? EmbedEnabled { get; set; }

        [JsonProperty("embed_channel_id")]
        public string EmbedChannelId { get; set; }

        [JsonProperty("verification_level")]
        public GuildVerificationLevel? VerificationLevel { get; set; }

        [JsonProperty("default_message_notifications")]
        public int? DefaultMessageNotifications { get; set; }

        [JsonProperty("explicit_content_filter")]
        public int? ExplicitContentFilter { get; set; }

        [JsonProperty("roles")]
        public List<Role> Roles { get; set; }

        [JsonProperty("emojis")]
        public List<Emoji> Emojis { get; set; }

        [JsonProperty("features")]
        public List<string> Features { get; set; }

        [JsonProperty("mfa_level")]
        public GuildMfaLevel? MfaLevel { get; set; }

        [JsonProperty("application_id")]
        public string ApplicationId { get; set; }

        [JsonProperty("widget_enabled")]
        public bool? WidgetEnabled { get; set; }

        [JsonProperty("widget_channel_id")]
        public string WidgetChannelId { get; set; }

        [JsonProperty("system_channel_id")]
        public string SystemChannelId { get; set; }

        [JsonProperty("rules_channel_id")]
        public string RulesChannelId { get; set; }

        [JsonProperty("joined_at")]
        public string JoinedAt { get; set; }

        [JsonProperty("large")]
        public bool? Large { get; set; }

        [JsonProperty("unavailable")]
        public bool? Unavailable { get; set; }

        [JsonProperty("member_count")]
        public int? MemberCount { get; set; }

        [JsonProperty("voice_states")]
        public List<VoiceState> VoiceStates { get; set; }

        [JsonProperty("members")]
        public List<GuildMember> Members { get; set; }

        [JsonProperty("channels")]
        public List<Channel> Channels { get; set; }

        [JsonProperty("presences")]
        public List<Presence> Presences { get; set; }

        [JsonProperty("max_presences")]
        public int? MaxPresences { get; set; }

        [JsonProperty("max_members")]
        public int? MaxMembers { get; set; }

        [JsonProperty("vanity_url_code")]
        public string VanityUrlCode { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("banner")]
        public string Banner { get; set; }

        [JsonProperty("premium_tier")]
        public GuildPremiumTier? PremiumTier { get; set; }

        [JsonProperty("premium_subscription_count")]
        public int? PremiumSubscriptionCount { get; set; }

        [JsonProperty("preferred_locale")]
        public string PreferredLocale { get; set; }

        [JsonProperty("public_updates_channel_id")]
        public string PublicUpdatesChannelId { get; set; }

        public static void CreateGuild(DiscordClient client, string name, string region, string icon, GuildVerificationLevel? verificationLevel, int? defaultMessageNotifications, List<Role> roles, List<Channel> channels, Action<Guild> callback = null)
        {
            var jsonObj = new Dictionary<string, object>()
            {
                { "name", name },
                { "region", region },
                { "icon", icon },
                { "verification_level", verificationLevel },
                { "default_message_notifications", defaultMessageNotifications },
                { "roles", roles },
                { "channels", channels }
            };

            client.REST.DoRequest($"/guilds", RequestMethod.POST, jsonObj, callback);
        }

        public static void GetGuild(DiscordClient client, string guildId, Action<Guild> callback = null)
        {
            client.REST.DoRequest($"/guilds/{guildId}", RequestMethod.GET, null, callback);
        }

        public void ModifyGuild(DiscordClient client, Action<Guild> callback = null)
        {
            client.REST.DoRequest($"/guilds/{Id}", RequestMethod.PATCH, this, callback);
        }

        public void DeleteGuild(DiscordClient client, Action callback = null)
        {
            client.REST.DoRequest($"/guilds/{Id}", RequestMethod.DELETE, null, callback);
        }

        public void GetGuildChannels(DiscordClient client, Action<List<Channel>> callback = null)
        {
            client.REST.DoRequest($"/guilds/{Id}/channels", RequestMethod.GET, null, callback);
        }

        public void CreateGuildChannel(DiscordClient client, Channel channel, Action<Channel> callback = null) => CreateGuildChannel(client, channel.Name, channel.Type, channel.BitRate, channel.UserLimit, channel.PermissionOverwrites, channel.ParentId, callback);

        public void CreateGuildChannel(DiscordClient client, string name, ChannelType? type, int? bitrate, int? userLimit, List<Overwrite> permissionOverwrites, string parentId, Action<Channel> callback = null)
        {
            var jsonObj = new Dictionary<string, object>()
            {
                { "name", name },
                { "type", type },
                { "bitrate", bitrate },
                { "user_limit", userLimit },
                { "permission_overwrites", permissionOverwrites },
                { "parent_id", parentId }
            };

            client.REST.DoRequest($"/guilds/{Id}/channels", RequestMethod.POST, jsonObj, callback);
        }

        public void ModifyGuildChannelPositions(DiscordClient client, List<ObjectPosition> positions, Action callback = null)
        {
            client.REST.DoRequest($"/guilds/{Id}/channels", RequestMethod.PATCH, positions, callback);
        }

        public void GetGuildMember(DiscordClient client, string userId, Action<GuildMember> callback = null)
        {
            client.REST.DoRequest($"/guilds/{Id}/members/{userId}", RequestMethod.GET, null, callback);
        }

        public void ListGuildMembers(DiscordClient client, Action<List<GuildMember>> callback = null)
        {
            client.REST.DoRequest($"/guilds/{Id}/members?limit=1000", RequestMethod.GET, null, callback);
        }

        public void AddGuildMember(DiscordClient client, GuildMember member, string accessToken, List<Role> roles, Action<GuildMember> callback = null) => this.AddGuildMember(client, member.User.Id, accessToken, member.Nick, roles, member.Mute, member.Deaf, callback);

        public void AddGuildMember(DiscordClient client, string userId, string accessToken, string nick, List<Role> roles, bool mute, bool deaf, Action<GuildMember> callback = null)
        {
            var jsonObj = new Dictionary<string, object>()
            {
                { "access_token", accessToken },
                { "nick", nick },
                { "roles", roles },
                { "mute", mute },
                { "deaf", deaf }
            };

            client.REST.DoRequest($"/guilds/{Id}/members/{userId}", RequestMethod.PUT, jsonObj, callback);
        }

        public void ModifyGuildMember(DiscordClient client, GuildMember member, List<string> roles, string channelId, Action callback = null) => this.ModifyGuildMember(client, member.User.Id, member.Nick, roles, member.Deaf, member.Mute, channelId, callback);

        public void ModifyGuildMember(DiscordClient client, string userId, string nick, List<string> roles, bool mute, bool deaf, string channelId, Action callback = null)
        {
            var jsonObj = new Dictionary<string, object>()
            {
                { "nick", nick },
                { "roles", roles },
                { "mute", mute },
                { "deaf", deaf },
                { "channel_id", channelId }
            };

            client.REST.DoRequest($"/guilds/{Id}/members/{userId}", RequestMethod.PATCH, jsonObj, callback);
        }

        public void ModifyUsersNick(DiscordClient client, string userId, string nick, Action callback = null)
        {
            var jsonObj = new Dictionary<string, object>()
            {
                { "nick", nick }
            };

            client.REST.DoRequest($"/guilds/{Id}/members/{userId}", RequestMethod.PATCH, jsonObj, callback);
        }

        public void ModifyCurrentUsersNick(DiscordClient client, string nick, Action<string> callback = null)
        {
            var jsonObj = new Dictionary<string, object>()
            {
                { "nick", nick }
            };

            client.REST.DoRequest($"/guilds/{Id}/members/@me/nick", RequestMethod.PATCH, jsonObj, callback);
        }

        public void AddGuildMemberRole(DiscordClient client, User user, Role role, Action callback = null) => AddGuildMemberRole(client, user.Id, role.Id, callback);

        public void AddGuildMemberRole(DiscordClient client, string userId, string roleId, Action callback = null)
        {
            client.REST.DoRequest($"/guilds/{Id}/members/{userId}/roles/{roleId}", RequestMethod.PUT, null, callback);
        }

        public void RemoveGuildMemberRole(DiscordClient client, User user, Role role, Action callback = null) => RemoveGuildMemberRole(client, user.Id, role.Id, callback);

        public void RemoveGuildMemberRole(DiscordClient client, string userId, string roleId, Action callback = null)
        {
            client.REST.DoRequest($"/guilds/{Id}/members/{userId}/roles/{roleId}", RequestMethod.DELETE, null, callback);
        }

        public void RemoveGuildMember(DiscordClient client, GuildMember member, Action callback = null) => RemoveGuildMember(client, member.User.Id, callback);

        public void RemoveGuildMember(DiscordClient client, string userId, Action callback = null)
        {
            client.REST.DoRequest($"/guilds/{Id}/members/{userId}", RequestMethod.DELETE, null, callback);
        }

        public void GetGuildBans(DiscordClient client, Action<List<Ban>> callback = null)
        {
            client.REST.DoRequest($"/guilds/{Id}/bans", RequestMethod.GET, null, callback);
        }

        public void CreateGuildBan(DiscordClient client, GuildMember member, int? deleteMessageDays, Action callback = null) => CreateGuildBan(client, member.User.Id, deleteMessageDays, callback);

        public void CreateGuildBan(DiscordClient client, string userId, int? deleteMessageDays, Action callback = null)
        {
            var jsonObj = new Dictionary<string, object>()
            {
                { "delete-message-days", deleteMessageDays }
            };

            client.REST.DoRequest($"/guilds/{Id}/bans/{userId}", RequestMethod.PUT, jsonObj, callback);
        }

        public void RemoveGuildBan(DiscordClient client, string userId, Action callback = null)
        {
            client.REST.DoRequest($"/guilds/{Id}/bans/{userId}", RequestMethod.DELETE, null, callback);
        }

        public void GetGuildRoles(DiscordClient client, Action<List<Role>> callback = null)
        {
            client.REST.DoRequest<List<Role>>($"/guilds/{Id}/roles", RequestMethod.GET, null, (returnValue) =>
            {
                callback?.Invoke(returnValue as List<Role>);
            });
        }

        public void CreateGuildRole(DiscordClient client, Role role, Action<Role> callback = null)
        {
            client.REST.DoRequest<Role>($"/guilds/{Id}/roles", RequestMethod.POST, role, callback);
        }

        public void ModifyGuildRolePositions(DiscordClient client, List<ObjectPosition> positions, Action<List<Role>> callback = null)
        {
            client.REST.DoRequest<List<Role>>($"/guilds/{Id}/roles", RequestMethod.PATCH, positions, callback);
        }

        public void ModifyGuildRole(DiscordClient client, Role role, Action<Role> callback = null) => ModifyGuildRole(client, role.Id, role, callback);

        public void ModifyGuildRole(DiscordClient client, string roleId, Role role, Action<Role> callback = null)
        {
            client.REST.DoRequest<Role>($"/guilds/{Id}/roles/{roleId}", RequestMethod.PATCH, role, (returnValue) =>
            {
                callback?.Invoke(returnValue as Role);
            });
        }

        public void DeleteGuildRole(DiscordClient client, Role role, Action callback = null) => DeleteGuildRole(client, role.Id, callback);

        public void DeleteGuildRole(DiscordClient client, string roleId, Action callback = null)
        {
            client.REST.DoRequest($"/guilds/{Id}/roles/{roleId}", RequestMethod.DELETE, null, callback);
        }

        public void GetGuildPruneCount(DiscordClient client, int? days, Action<int?> callback = null)
        {
            client.REST.DoRequest<JObject>($"/guilds/{Id}/prune?days={days}", RequestMethod.GET, null, (returnValue) =>
            {
                var pruned = returnValue.GetValue("pruned").ToObject<int?>();

                callback?.Invoke(pruned);
            });
        }

        public void BeginGuildPrune(DiscordClient client, int? days, Action<int?> callback = null)
        {
            client.REST.DoRequest<JObject>($"/guilds/{Id}/prune?days={days}", RequestMethod.POST, null, (returnValue) =>
            {
                var pruned = returnValue.GetValue("pruned").ToObject<int?>();

                callback?.Invoke(pruned);
            });
        }

        public void GetGuildVoiceRegions(DiscordClient client, Action<List<VoiceRegion>> callback = null)
        {
            client.REST.DoRequest($"/guilds/{Id}/regions", RequestMethod.GET, null, callback);
        }

        public void GetGuildInvites(DiscordClient client, Action<List<Invite>> callback = null)
        {
            client.REST.DoRequest($"/guilds/{Id}/invites", RequestMethod.GET, null, callback);
        }

        public void GetGuildIntegrations(DiscordClient client, Action<List<Integration>> callback = null)
        {
            client.REST.DoRequest($"/guilds/{Id}/integrations", RequestMethod.GET, null, callback);
        }

        public void CreateGuildIntegration(DiscordClient client, Integration integration, Action callback = null) => CreateGuildIntegration(client, integration.Type, integration.Id, callback);

        public void CreateGuildIntegration(DiscordClient client, string type, string id, Action callback = null)
        {
            var jsonObj = new Dictionary<string, object>()
            {
                { "type", type },
                { "id", id }
            };

            client.REST.DoRequest($"/guilds/{id}/integrations", RequestMethod.POST, jsonObj, callback);
        }

        public void ModifyGuildIntegration(DiscordClient client, Integration integration, bool? enableEmoticons, Action callback = null) => ModifyGuildIntegration(client, integration.Id, integration.ExpireBehaviour, integration.ExpireGracePeroid, enableEmoticons, callback);

        public void ModifyGuildIntegration(DiscordClient client, string integrationId, int? expireBehaviour, int? expireGracePeroid, bool? enableEmoticons, Action callback = null)
        {
            var jsonObj = new Dictionary<string, object>()
            {
                { "expire_behaviour", expireBehaviour },
                { "expire_grace_peroid", expireGracePeroid },
                { "enable_emoticons", enableEmoticons }
            };

            client.REST.DoRequest($"/guilds/{Id}/integrations/{integrationId}", RequestMethod.PATCH, jsonObj, callback);
        }

        public void DeleteGuildIntegration(DiscordClient client, Integration integration, Action callback = null) => DeleteGuildIntegration(client, integration.Id, callback);

        public void DeleteGuildIntegration(DiscordClient client, string integrationId, Action callback = null)
        {
            client.REST.DoRequest($"/guilds/{Id}/integrations/{integrationId}", RequestMethod.DELETE, null, callback);
        }

        public void SyncGuildIntegration(DiscordClient client, Integration integration, Action callback = null) => SyncGuildIntegration(client, integration.Id, callback);

        public void SyncGuildIntegration(DiscordClient client, string integrationId, Action callback = null)
        {
            client.REST.DoRequest($"/guilds/{Id}/integrations/{integrationId}/sync", RequestMethod.POST, null, callback);
        }

        public void GetGuildEmbed(DiscordClient client, Action<GuildEmbed> callback = null)
        {
            client.REST.DoRequest($"/guilds/{Id}/embed", RequestMethod.GET, null, callback);
        }

        public void ModifyGuildEmbed(DiscordClient client, GuildEmbed guildEmbed, Action<GuildEmbed> callback = null)
        {
            client.REST.DoRequest($"/guilds/{Id}/embed", RequestMethod.PATCH, guildEmbed, callback);
        }

        public void GetGuildVanityUrl(DiscordClient client, Action<Invite> callback = null)
        {
            client.REST.DoRequest($"/guilds/{Id}/vanity-url", RequestMethod.GET, null, callback);
        }

        public void Update(Guild updatedGuild)
        {
            if (updatedGuild.Name != null)
                this.Name = updatedGuild.Name;
            if (updatedGuild.Icon != null)
                this.Icon = updatedGuild.Icon;
            if (updatedGuild.Splash != null)
                this.Splash = updatedGuild.Splash;
            if (updatedGuild.OwnerId != null)
                this.OwnerId = updatedGuild.OwnerId;
            if (updatedGuild.Region != null)
                this.Region = updatedGuild.Region;
            if (updatedGuild.AfkChannelId != null)
                this.AfkChannelId = updatedGuild.AfkChannelId;
            if (updatedGuild.AfkTimeout != null)
                this.AfkTimeout = updatedGuild.AfkTimeout;
            if (updatedGuild.EmbedEnabled != null)
                this.EmbedEnabled = updatedGuild.EmbedEnabled;
            if (updatedGuild.EmbedChannelId != null)
                this.EmbedChannelId = updatedGuild.EmbedChannelId;
            if (updatedGuild.VerificationLevel != null)
                this.VerificationLevel = updatedGuild.VerificationLevel;
            if (updatedGuild.DefaultMessageNotifications != null)
                this.DefaultMessageNotifications = updatedGuild.DefaultMessageNotifications;
            if (updatedGuild.ExplicitContentFilter != null)
                this.ExplicitContentFilter = updatedGuild.ExplicitContentFilter;
            if (updatedGuild.Roles != null)
                this.Roles = updatedGuild.Roles;
            if (updatedGuild.Emojis != null)
                this.Emojis = updatedGuild.Emojis;
            if (updatedGuild.Features != null)
                this.Features = updatedGuild.Features;
            if (updatedGuild.MfaLevel != null)
                this.MfaLevel = updatedGuild.MfaLevel;
            if (updatedGuild.ApplicationId != null)
                this.ApplicationId = updatedGuild.ApplicationId;
            if (updatedGuild.WidgetEnabled != null)
                this.WidgetEnabled = updatedGuild.WidgetEnabled;
            if (updatedGuild.WidgetChannelId != null)
                this.WidgetChannelId = updatedGuild.WidgetChannelId;
            if (updatedGuild.SystemChannelId != null)
                this.SystemChannelId = updatedGuild.SystemChannelId;
            if (updatedGuild.JoinedAt != null)
                this.JoinedAt = updatedGuild.JoinedAt;
            if (updatedGuild.Large != null)
                this.Large = updatedGuild.Large;
            if (updatedGuild.Unavailable != null)
                this.Unavailable = updatedGuild.Unavailable;
            if (updatedGuild.MemberCount != null)
                this.MemberCount = updatedGuild.MemberCount;
            if (updatedGuild.VoiceStates != null)
                this.VoiceStates = updatedGuild.VoiceStates;
            if (updatedGuild.Members != null)
                this.Members = updatedGuild.Members;
            if (updatedGuild.Channels != null)
                this.Channels = updatedGuild.Channels;
            if (updatedGuild.Presences != null)
                this.Presences = updatedGuild.Presences;
            if (updatedGuild.MaxPresences != null)
                this.MaxPresences = updatedGuild.MaxPresences;
            if (updatedGuild.MaxMembers != null)
                this.MaxMembers = updatedGuild.MaxMembers;
            if (updatedGuild.VanityUrlCode != null)
                this.VanityUrlCode = updatedGuild.VanityUrlCode;
            if (updatedGuild.Description != null)
                this.Description = updatedGuild.Description;
            if (updatedGuild.Banner != null)
                this.Banner = updatedGuild.Banner;
            if (updatedGuild.PremiumTier != null)
                this.PremiumTier = updatedGuild.PremiumTier;
            if (updatedGuild.PremiumSubscriptionCount != null)
                this.PremiumSubscriptionCount = updatedGuild.PremiumSubscriptionCount;
        }
    }
}
