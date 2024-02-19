using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Text.Json.Serialization;

namespace HackerNewsAPI.Models
{
    public class Story
    {
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("title")]
        public string? title { get; set; }

        [JsonProperty("url")]
        public string? url { get; set; }

        [JsonProperty("by")]
        public string? postedBy { get; set; }

        [JsonProperty("time")]
        [Newtonsoft.Json.JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime? time { get; set; }

        [JsonProperty("score")]
        public int score { get; set; }

        [JsonProperty("descendants")]
        public int CommentCount { get; set; }

        [JsonProperty("Kids")]
        public List<string>? kids { get; set; }

        [JsonProperty("text")]
        public string? Text { get; set; }

        [JsonProperty("parent")]
        public string? Parent { get; set; }
    }
}

