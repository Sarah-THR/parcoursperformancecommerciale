using System.Text.Json.Serialization;

namespace EcoleDeLaPerformance.Ui.Models
{
    public class Select
    {
        [JsonPropertyName("field")]
        public string Field { get; set; }
    }
}
