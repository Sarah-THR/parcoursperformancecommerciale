using System.Text.Json.Serialization;

namespace EcoleDeLaPerformance.Ui.Models
{
    public class SalesUpUserId
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
    }
}
