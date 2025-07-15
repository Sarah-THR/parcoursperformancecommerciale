using System.Text.Json.Serialization;

namespace EcoleDeLaPerformance.Ui.Models
{
    public class Filter
    {
        [JsonPropertyName("field")]
        public string Field { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }
    }
}
