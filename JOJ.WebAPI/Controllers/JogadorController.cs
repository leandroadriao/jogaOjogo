using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JOJ.WebAPI.Controllers
{
    public class JogadorController : ApiController
    {
        // GET: api/Jogador
        public IEnumerable<Models.Jogador> Get()
        {
            return new Models.Jogador().ObterTodosJogadores();
        }

        // GET: api/Jogador/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Jogador
        [HttpPost, Route("RegisterPerson")]
        public string Post(string Nome, int Posicao, int Tipo)
        {
            return "value";
        }

        // PUT: api/Jogador/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Jogador/5
        public void Delete(int id)
        {
        }
    }
}
