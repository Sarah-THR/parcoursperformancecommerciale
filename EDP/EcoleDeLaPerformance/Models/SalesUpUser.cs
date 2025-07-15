using System.Text.Json.Serialization;

namespace EcoleDeLaPerformance.Ui.Models
{
    public class SalesUpUser
    {
        [JsonPropertyName("data")]
        public List<SalesUpUserId> Ids {  get; set; }
    }
}
