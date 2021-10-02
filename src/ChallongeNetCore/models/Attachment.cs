namespace ChallongeNetCore
{
    using System.Text.Json.Serialization;

    public class Attachment
    {
        [JsonPropertyName("asset")]
        public string Asset { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}
