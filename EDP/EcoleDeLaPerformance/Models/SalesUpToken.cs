using System.Text.Json.Serialization;

namespace EcoleDeLaPerformance.Ui.Models
{
    public class SalesUpToken
    {
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }
    }
}
