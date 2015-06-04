using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ScoreboardServer.Controllers
{
    public class RegisterScoreController : ApiController
    {
        private static Dictionary<string, int> _scores;

            //// GET: api/RegisterScore
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/RegisterScore/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/RegisterScore
        [Route("Register/{name}")]
        public void Post(string name)
        {
            if (!_scores.ContainsKey(name))
            {
                _scores[name] = 0;

            }
            _scores[name] = _scores[name]++;

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
