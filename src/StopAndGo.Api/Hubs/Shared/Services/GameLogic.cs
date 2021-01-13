using System;
using System.Threading;
using System.Threading.Tasks;
using Coravel.Invocable;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using StopAndGo.Api.Hubs.Shared.Constants;
using StopAndGo.Api.Hubs.Shared.Models;
using StopAndGo.Api.Hubs.Shared.Services.Interfaces;

namespace StopAndGo.Api.Hubs.Shared.Services
{
    public class GameLogic : IInvocable
    {
        private readonly IGameState _gameState;
        private readonly IHubContext<GameHub> _hubContext;
        private readonly GameLogicConfiguration _gameLogicConfiguration;

        public GameLogic(
            IConfiguration configuration,
            IGameState gameState,
            IHubContext<GameHub> hubContext)
        {
            _gameState = gameState;
            _hubContext = hubContext;

            _gameLogicConfiguration = new GameLogicConfiguration();
            configuration.GetSection("GameLogic").Bind(_gameLogicConfiguration);
        }

        public async Task Invoke()
        {
            _gameState.IsRunning = true;

            await RunStartingCountdown();

            await RunGameLoop();

            if (_gameState.HasWinners())
                await _hubContext.Clients.All.SendAsync(GameCommands.GameOver, _gameState.GetPlayerList());

            _gameState.Reset();
        }

        private async Task RunStartingCountdown()
        {
            var intervals = _gameLogicConfiguration.StartCountdownIntervals;

            for (var i = 0; i < intervals.Length; i++)
            {
                if (!_gameState.HasPlayers()) return;

                await Starting(intervals[i]);

                var sleep = i != intervals.Length - 1 ? intervals[i] - intervals[i + 1] : intervals[i];
                Thread.Sleep(sleep * 1000);
            }
        }

        private async Task RunGameLoop()
        {
            await Go();

            while (_gameState.HasPlayers())
            {
                await Update();

                if (_gameState.HasWinners()) return;

                if (!Stopped()) continue;

                await Stop();
                await Go();
            }
        }

        private bool Stopped() => new Random().Next(1, 100) <= _gameLogicConfiguration.StopRate;

        private async Task Starting(int seconds) =>
            await _hubContext.Clients.All.SendAsync(
                GameCommands.GameStarting, new {Seconds = seconds, Players = _gameState.GetPlayerList()});

        private async Task Stop()
        {
            await _hubContext.Clients.All.SendAsync(GameCommands.Stop);

            Thread.Sleep(_gameLogicConfiguration.StopReactionGap);
            if (!_gameState.HasPlayers()) return;

            _gameState.ResetPlayers();
            await _hubContext.Clients.All.SendAsync(GameCommands.Update, _gameState.GetPlayerList());

            Thread.Sleep(_gameLogicConfiguration.StopCooldown);
        }

        private async Task Go()
        {
            if (!_gameState.HasPlayers()) return;
            await _hubContext.Clients.All.SendAsync(GameCommands.Go);
        }

        private async Task Update()
        {
            Thread.Sleep(_gameLogicConfiguration.GameSpeed);
            if (!_gameState.HasPlayers()) return;

            _gameState.AdvancePlayers();
            await _hubContext.Clients.All.SendAsync(GameCommands.Update, _gameState.GetPlayerList());
        }
    }
}
