using Newtonsoft.Json;

namespace Oxide.Ext.Discord.DiscordObjects
{

    public class VoiceStateUpdate
    {
        [JsonProperty("guild_id")]
        public string GuildId;

        [JsonProperty("channel_id")]
        public string ChannelId;

        [JsonProperty("self_mute")]
        public bool SelfMute;

        [JsonProperty("self_deaf")]
        public bool SelfDeaf;
    }
}
