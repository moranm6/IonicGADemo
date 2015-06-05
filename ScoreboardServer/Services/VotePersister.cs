using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using ScoreboardServer.Models;

namespace ScoreboardServer.Services
{
    public class VotePersister : IVotePersister
    {
        private ScoreboardContext _scoreboardContext;

        public VotePersister(ScoreboardContext scoreboardContext)
        {
            _scoreboardContext = scoreboardContext;
        }

        public Player FindPlayerBy(int playerId)
        {
            return _scoreboardContext.Players.Find(playerId);
        }

        public void PersistVote(Player player)
        {
            _scoreboardContext.Votes.Add(new Vote
            {
                Player = player
            });

            _scoreboardContext.SaveChanges();
        }

        public int GetCountBy(Player player)
        {
            return _scoreboardContext.Votes.Count(x => x.Player.PlayerId == player.PlayerId);
        }

        public List<Player> GetAllPlayers()
        {
            return _scoreboardContext.Players.ToList();
        }
    }
}