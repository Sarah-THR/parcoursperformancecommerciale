using System.Text.Json.Serialization;

namespace EcoleDeLaPerformance.Ui.Models.SalesUp
{
    public class SalesUpUserId
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
    }
}
