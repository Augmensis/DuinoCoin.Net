using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DuinoCoin.Net.Models
{
    public class UserInfoResult
    {
        [JsonPropertyName("balance")]
        public UserBalance Balance { get; set; }

        [JsonPropertyName("miners")]
        public List<Miner> Miners { get; set; }

        [JsonPropertyName("transactions")]
        public List<Transaction> Transactions { get; set; }
    }
}
