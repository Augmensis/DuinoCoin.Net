using System;
using Xunit;

namespace DuinoCoin.Net.Tests
{
    public class ServerApiTests
    {
        private ServerApi _server { get; set; }

        public ServerApiTests()
        {
            _server = new ServerApi();
        }

        [Theory]
        [InlineData("Dezzamondo")]
        // You can extend tests with your own usernames here if needed
        public async void GetUserInfo_ReturnsTheCorrectMiner(string username)
        {
            var userInfo = await _server.GetUserInfo(username);

            Assert.NotNull(userInfo);
            Assert.NotNull(userInfo.Balance);
            Assert.NotNull(userInfo.Miners);
            Assert.NotNull(userInfo.Transactions);
            Assert.Equal(username, userInfo.Balance?.Username);
        }

        [Theory]
        [InlineData("Dezzamondo")]
        public async void GetTransactions_ReturnsMoreThanTransaction(string shouldContainSender)
        {
            var result = await _server.GetTransactions();

            Assert.NotNull(result);
            Assert.NotNull(result.Keys);
            Assert.NotNull(result.Values);
            Assert.True(result.Keys.Count > 1);
            Assert.Contains(result.Values, x => x.Sender == shouldContainSender);
        }

        [Theory]
        [InlineData("d9f0790263a4e502651ea1e75e9228e98ca5df35", "Dezzamondo", "revox", 0.69, "Keep up the good work Revox. This is a test transaction :)")]
        public async void GetTransaction_ReturnsTheCorrectTransaction(string transactionId, string sender, string recipient, decimal amount, string memo)
        {
            var transaction = await _server.GetTransaction(transactionId);

            Assert.NotNull(transaction);
            Assert.Equal(sender, transaction.Sender);
            Assert.Equal(recipient, transaction.Recipient);
            Assert.Equal(amount, transaction.Amount);
            Assert.Equal(memo, transaction.Memo);
            Assert.Equal(transactionId, transaction.Hash);
        }

        [Theory]
        [InlineData("Dezzamondo")]
        public async void GetBalances_ReturnsMoreThanOneBalance(string shouldContainUsername)
        {
            var balances = await _server.GetBalances();

            Assert.NotNull(balances);
            Assert.True(balances.Count > 1);
            Assert.Contains(balances, m => m.Key == shouldContainUsername);
        }

        [Theory]
        [InlineData("Dezzamondo")]
        public async void GetBalance_ReturnsTheCorrectUsersBalance(string username)
        {
            var balance = await _server.GetBalance(username);

            Assert.NotNull(balance);
            Assert.Equal(username, balance.Username);
            Assert.True(balance.Balance > 1.0M);            
        }

        [Fact]
        public async void GetMiners_ReturnsMoreThanOneMiner()
        {
            var miners = await _server.GetMiners();

            Assert.NotNull(miners);
            Assert.True(miners.Count > 1);
            Assert.Contains(miners, m => m.Key == "Dezzamondo");
        }
    }
}
