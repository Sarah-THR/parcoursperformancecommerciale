using System.Text.Json.Serialization;

namespace EcoleDeLaPerformance.Ui.Models
{
    public class SearchUserRequest
    {
        [JsonPropertyName("search")]
        public Search Search { get; set; }
    }
}
