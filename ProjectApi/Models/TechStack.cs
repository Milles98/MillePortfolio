using System.Text.Json.Serialization;

namespace ProjectApi.Models
{
    public class TechStack
    {
        [JsonIgnore]
        public int Id { get; set; }
        public TechIcon TechIcon { get; set; } = null!;
    }
}
