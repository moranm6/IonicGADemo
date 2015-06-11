using System;
using System.Collections.Generic;
using ScoreboardServer.Models;

namespace ScoreboardServer.Services
{
    public interface IVotePersister
    {
        Player FindPlayerBy(int playerId);
        void PersistVote(Player player);
        int GetCountBy(Player player);
        List<Player> GetAllPlayers();
    }
}