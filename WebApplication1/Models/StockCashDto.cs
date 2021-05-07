using System.Text.Json.Serialization;

namespace SelfCheckoutMachine.Models
{
    public class StockCashDto
    {
        [JsonPropertyName("500")]
        public int? FiveHundred { get; set; }

        [JsonPropertyName("200")]
        public int? TwoHundred { get; set; }

        [JsonPropertyName("100")]
        public int? Hundred { get; set; }

        [JsonPropertyName("10")]
        public int? Ten { get; set; }

        [JsonPropertyName("20")]
        public int? Twenty { get; set; }

        [JsonPropertyName("5")]
        public int? Five { get; set; }

        [JsonPropertyName("50")]
        public int? Fifty { get; set; }
    }
}
