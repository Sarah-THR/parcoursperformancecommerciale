using System.Text.Json.Serialization;

namespace EcoleDeLaPerformance.Ui.Models
{
    public class BonusRequest
    {
        [JsonPropertyName("date")]
        public string Date { get; set; }

        [JsonPropertyName("accessable_ids")]
        public List<string> Ids { get; set; }

        [JsonPropertyName("accessable_type")]
        public string Type { get; set; }
    }
}
