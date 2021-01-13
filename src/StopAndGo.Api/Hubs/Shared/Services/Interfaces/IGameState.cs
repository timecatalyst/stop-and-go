using System.Collections.Generic;
using StopAndGo.Api.Hubs.Shared.Models;

namespace StopAndGo.Api.Hubs.Shared.Services.Interfaces
{
    public interface IGameState
    {
        bool IsRunning { get; set; }

        void AddPlayer(string connectionId, string playerName);
        void RemovePlayer(string connectionId);

        IEnumerable<PlayerModel> GetPlayerList();
        bool HasPlayers();
        bool HasWinners();

        void AdvancePlayers();
        void ResetPlayers();
        void SetPlayerCommand(string connectionId, string command);
        void Reset();
    }
}
