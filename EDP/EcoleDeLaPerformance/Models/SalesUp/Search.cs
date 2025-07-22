using System.Text.Json.Serialization;

namespace EcoleDeLaPerformance.Ui.Models.SalesUp
{
    public class Search
    {
        [JsonPropertyName("selects")]
        public List<Select> Selects { get; set; }

        [JsonPropertyName("filters")]
        public List<Filter> Filters { get; set; }
    }
}
