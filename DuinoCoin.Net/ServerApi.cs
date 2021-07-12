using DuinoCoin.Net.Converters;
using DuinoCoin.Net.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DuinoCoin.Net
{
    public class ServerApi
    {
        public string BaseUrl { get; set; }
        private HttpClient _client { get; set; }
        private JsonSerializerOptions _options { get; set; }

        public ServerApi(string baseUrl = "https://server.duinocoin.com")
        {
            BaseUrl = baseUrl;
            _client = new HttpClient { BaseAddress = new Uri(BaseUrl) };
            _options = new JsonSerializerOptions();
            _options.Converters.Add(new JsonCustomDateTimeConverter());
        }

        /// <summary>
        /// Get a specific user's details including: Balance, Miners and Transactions.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public async Task<UserInfoResult> GetUserInfo(string username)
        {            
            var res = await _client.GetFromJsonAsync<ResponseBase<UserInfoResult>>($"users/{username}", _options);
            return res.Result;
        }

        /// <summary>
        /// Get the most recent transactions on the blockchain.
        /// </summary>
        /// <returns></returns>
        public async Task<Dictionary<string, Transaction>> GetTransactions()
        {
            var res = await _client.GetFromJsonAsync<ResponseBase<Dictionary<string, Transaction>>>($"transactions", _options);
            return res.Result;
        }

        /// <summary>
        /// Get a specific transaction from the blockchain for a specific hash value.
        /// </summary>
        /// <param name="hash"></param>
        /// <returns></returns>
        public async Task<Transaction> GetTransaction(string hash)
        {
            var res = await _client.GetFromJsonAsync<ResponseBase<Transaction>>($"transactions/{hash}", _options);
            return res.Result;
        }

        /// <summary>
        /// Get a dictionary of usernames and their corresponding balances.
        /// </summary>
        /// <returns></returns>
        public async Task<Dictionary<string, decimal>> GetBalances()
        {
            var res = await _client.GetFromJsonAsync<ResponseBase<Dictionary<string, decimal>>>($"balances");
            return res.Result;
        }

        /// <summary>
        /// Get the current balance for a specific user.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public async Task<UserBalance> GetBalance(string username)
        {
            var res = await _client.GetFromJsonAsync<ResponseBase<UserBalance>>($"balances/{username}");
            return res.Result;
        }

        /// <summary>
        /// Get a dictionary of users and their corresponding miners.
        /// </summary>
        /// <returns></returns>
        public async Task<Dictionary<string, List<Miner>>> GetMiners()
        {
            var res = await _client.GetFromJsonAsync<ResponseBase<Dictionary<string, List<Miner>>>>("miners");
            return res.Result;
        }
    }
}
