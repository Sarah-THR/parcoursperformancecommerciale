using System.Text.Json.Serialization;

namespace EcoleDeLaPerformance.Ui.Models
{
    public class Bonus
    {
        [JsonPropertyName("bonus_value")]
        public int Value { get; set; }
    }
}
