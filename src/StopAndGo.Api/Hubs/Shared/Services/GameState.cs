using System;
using System.Collections.Generic;
using System.Linq;
using StopAndGo.Api.Hubs.Shared.Constants;
using StopAndGo.Api.Hubs.Shared.Models;
using StopAndGo.Api.Hubs.Shared.Services.Interfaces;

namespace StopAndGo.Api.Hubs.Shared.Services
{
    public class GameState : IGameState
    {
        private readonly IDictionary<string, PlayerModel> _players = new Dictionary<string, PlayerModel>();
        private const int LastPosition = 20;
        public bool IsRunning { get; set; }

        public void AddPlayer(string connectionId, string playerName)
        {
            var random = new Random();

            _players.Add(
                connectionId,
                new PlayerModel
                {
                    ConnectionId = connectionId,
                    Name = playerName,
                    Color = $"#{random.Next(0x1000000):X6}",
                    Position = 0,
                    Command = GameCommands.Stop
                }
            );
        }

        public void RemovePlayer(string connectionId) => _players.Remove(connectionId);

        public IEnumerable<PlayerModel> GetPlayerList() =>
            _players.Select(p => p.Value)
                    .OrderBy(p => p.Name)
                    .ToArray();

        public bool HasPlayers() => _players.Any();

        public bool HasWinners() => _players.Any(p => p.Value.Position >= LastPosition);

        public void SetPlayerCommand(string connectionId, string command)
        {
            if (_players.TryGetValue(connectionId, out var player)) player.Command = command;
        }

        public void AdvancePlayers()
        {
            foreach (var (_, value) in _players)
            {
                if (value.Command == GameCommands.Go && value.Position < LastPosition) value.Position++;
            }
        }

        public void ResetPlayers()
        {
            foreach (var (_, value) in _players)
            {
                if (value.Command == GameCommands.Go) value.Position = 0;
            }
        }

        public void Reset()
        {
            _players.Clear();
            IsRunning = false;
        }
    }
}
