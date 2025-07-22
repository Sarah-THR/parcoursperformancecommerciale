using System.Text.Json.Serialization;

namespace EcoleDeLaPerformance.Ui.Models.SalesUp
{
    public class SalesUpTokenRequest
    {
        [JsonPropertyName("email")]
        public string Email { get; set; }
        
        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}
