using System.Text.Json.Serialization;

namespace EcoleDeLaPerformance.Ui.Models.SalesUp
{
    public class SalesUpUser
    {
        [JsonPropertyName("data")]
        public List<SalesUpUserId> Ids {  get; set; }
    }
}
