using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DuinoCoin.Net.Models
{
    public class UserBalance
    {
        [JsonPropertyName("balance")]
        public decimal Balance { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set; }
    }
}
