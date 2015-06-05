using System.Collections.Generic;
using System.Web.Http;
using ScoreboardServer.Models;
using ScoreboardServer.Services;

namespace ScoreboardServer.Controllers
{
    public class RegisterScoreController : ApiController
    {
        private IVotePersister _votePersister;
        private ScoreboardContext _ScoreboardContext;

        public RegisterScoreController()
        {
            _ScoreboardContext = new ScoreboardContext();
            _votePersister = new VotePersister(_ScoreboardContext);
        }

        [Route("Vote/{playerId}")]
        public string Get(int playerId)
        {
            var player = _votePersister.FindPlayerBy(playerId);
            return _votePersister.GetCountBy(player).ToString();
        }

        [Route("Vote/{playerId}")]
        public void Post(int playerId)
        {
            var player = _votePersister.FindPlayerBy(playerId);
            _votePersister.PersistVote(player);
        }

        [Route("Players/")]
        public List<Player> GetPlayers()
        {
            return _votePersister.GetAllPlayers();
        }
    }
}
