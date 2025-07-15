using System.Text.Json.Serialization;

namespace EcoleDeLaPerformance.Ui.Models
{
    public class Search
    {
        [JsonPropertyName("selects")]
        public List<Select> Selects { get; set; }

        [JsonPropertyName("filters")]
        public List<Filter> Filters { get; set; }
    }
}
