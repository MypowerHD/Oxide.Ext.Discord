using System.Collections.Generic;
using Newtonsoft.Json;

namespace Oxide.Ext.Discord.DiscordObjects
{

    public class AuditLogChangeKey
    {
        public class Guild
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("icon_hash")]
            public string IconHash { get; set; }

            [JsonProperty("splash_hash")]
            public string SplashHash { get; set; }

            [JsonProperty("owner_id")]
            public string OwnerId { get; set; }

            [JsonProperty("region")]
            public string Region { get; set; }

            [JsonProperty("afk_channel_id")]
            public string AfkChannelId { get; set; }

            [JsonProperty("afk_timeout")]
            public int? AfkTimeout { get; set; }

            [JsonProperty("mfa_level")]
            public int? MfaLevel { get; set; }

            [JsonProperty("verification_level")]
            public int? VerificationLevel { get; set; }

            [JsonProperty("explicit_content_filter")]
            public int? ExplicitContentFilter { get; set; }

            [JsonProperty("default_message_notifications")]
            public int? DefaultMessageNotifications { get; set; }

            [JsonProperty("vanity_url_code")]
            public string VanityUrlCode { get; set; }

            [JsonProperty(PropertyName = "$add")]
            public List<Role> Add { get; set; }

            [JsonProperty(PropertyName = "$remove")]
            public List<Role> Remove { get; set; }

            [JsonProperty("prune_delete_days")]
            public int? PruneDeleteDays { get; set; }

            [JsonProperty("widget_enabled")]
            public bool WidgetEnabled { get; set; }

            [JsonProperty("widget_channel_id")]
            public string WidgetChannelId { get; set; }
        }

        public class Channel
        {
            [JsonProperty("position")]
            public int? Position { get; set; }

            [JsonProperty("topic")]
            public string Topic { get; set; }

            [JsonProperty("bitrate")]
            public int? Bitrate { get; set; }

            [JsonProperty("permission_overwrites")]
            public List<Overwrite> PermissionOverwrites { get; set; }

            [JsonProperty("nsfw")]
            public bool Nsfw { get; set; }

            [JsonProperty("application_id")]
            public string ApplicationId { get; set; }
        }

        public class Role
        {
            [JsonProperty("mentionable")]
            public bool Mentionable { get; set; }

            [JsonProperty("allow")]
            public int? Allow { get; set; }

            [JsonProperty("deny")]
            public int? Deny { get; set; }
        }

        public class Invite
        {
            [JsonProperty("code")]
            public string Code { get; set; }

            [JsonProperty("channel_id")]
            public string ChannelId { get; set; }

            [JsonProperty("inviter_id")]
            public string InviterId { get; set; }

            [JsonProperty("max_uses")]
            public int? MaxUses { get; set; }

            [JsonProperty("uses")]
            public int? Uses { get; set; }

            [JsonProperty("max_age")]
            public int? MaxAge { get; set; }

            [JsonProperty("temporary")]
            public bool Temporary { get; set; }
        }

        public class User
        {
            [JsonProperty("deaf")]
            public bool Deaf { get; set; }

            [JsonProperty("mute")]
            public bool Mute { get; set; }

            [JsonProperty("nick")]
            public string Nick { get; set; }

            [JsonProperty("avatar_hash")]
            public string AvatarHash { get; set; }
        }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public int? Type { get; set; }
    }
}
