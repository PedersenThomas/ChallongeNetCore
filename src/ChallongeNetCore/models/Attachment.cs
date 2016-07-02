using Newtonsoft.Json;

namespace ChallongeNetCore
{
    public class Attachment
    {
        [JsonProperty(PropertyName = "asset")]
        public string Asset { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }
    }
}
