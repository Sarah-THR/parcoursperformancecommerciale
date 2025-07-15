using System.Text.Json.Serialization;

namespace EcoleDeLaPerformance.Ui.Models
{
    public class SalesUpTokenRequest
    {
        [JsonPropertyName("email")]
        public string Email { get; set; }
        
        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}
