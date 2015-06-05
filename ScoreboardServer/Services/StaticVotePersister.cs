using System.Collections.Generic;
using ScoreboardServer.Controllers;

namespace ScoreboardServer.Services
{
    public class StaticVotePersister : IVotePersister
    {
        private static Dictionary<string, int> _scores = new Dictionary<string, int>();

        public void PersistVote(string name)
        {
            if (!_scores.ContainsKey(name))
            {
                _scores[name] = 0;

            }
            _scores[name] = ++_scores[name];
        }

        public int GetCountBy(string name)
        {
            if (!_scores.ContainsKey(name))
                return 0;

            return _scores[name];
        }
    }
}