using System;
using System.Threading.Tasks;
using Coravel.Queuing.Interfaces;
using Microsoft.AspNetCore.SignalR;
using StopAndGo.Api.Hubs.Shared.Constants;
using StopAndGo.Api.Hubs.Shared.Services;
using StopAndGo.Api.Hubs.Shared.Services.Interfaces;

namespace StopAndGo.Api.Hubs
{
    public class GameHub : Hub
    {
        private readonly IGameState _gameState;
        private readonly IQueue _queue;

        public GameHub(IGameState gameState, IQueue queue)
        {
            _gameState = gameState;
            _queue = queue;
        }

        public override Task OnConnectedAsync() => Task.CompletedTask;

        public override Task OnDisconnectedAsync(Exception exception)
        {
            _gameState.RemovePlayer(Context.ConnectionId);

            if (!_gameState.HasPlayers()) Clients.All.SendAsync(GameCommands.GameEnded);

            return Task.CompletedTask;
        }

        public void JoinGame(string playerName)
        {
            _gameState.AddPlayer(Context.ConnectionId, playerName);

            if (_gameState.IsRunning) return;

            _queue.QueueInvocable<GameLogic>();
        }

        public void LeaveGame()
        {
            _gameState.RemovePlayer(Context.ConnectionId);

            if (!_gameState.HasPlayers()) Clients.All.SendAsync(GameCommands.GameEnded);
        }

        public void Go() => _gameState.SetPlayerCommand(Context.ConnectionId, GameCommands.Go);

        public void Stop() => _gameState.SetPlayerCommand(Context.ConnectionId, GameCommands.Stop);
    }
}
