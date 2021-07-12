using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DuinoCoin.Net.Models
{
    public class Miner
    {
        [JsonPropertyName("accepted")]
        public long Accepted { get; set; }

        [JsonPropertyName("algorithm")]
        public string Algorithm { get; set; }

        [JsonPropertyName("diff")]
        public int Difficulty { get; set; }

        [JsonPropertyName("hashrate")]
        public decimal Hashrate { get; set; }

        [JsonPropertyName("identifier")]
        public string Identifier { get; set; }

        [JsonPropertyName("rejected")]
        public long Rejected { get; set; }

        [JsonPropertyName("sharetime")]
        public decimal ShareTime { get; set; }

        [JsonPropertyName("software")]
        public string Software { get; set; }

        [JsonPropertyName("threadid")]
        public string ThreadId { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set; }
    }
}
