using System.Web.Http;
using ScoreboardServer.Services;

namespace ScoreboardServer.Controllers
{
    public class RegisterScoreController : ApiController
    {
        private IVotePersister _votePersister;

        public RegisterScoreController()
        {
            _votePersister = new StaticVotePersister();
        }

            //// GET: api/RegisterScore
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        [Route("Vote/{name}")]
        public string Get(string name)
        {
            return _votePersister.GetCountBy(name).ToString();
        }

        [Route("Vote/{name}")]
        public void Post(string name)
        {
            _votePersister.PersistVote(name);
        }

        //// PUT: api/RegisterScore/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/RegisterScore/5
        //public void Delete(int id)
        //{
        //}
    }
}
