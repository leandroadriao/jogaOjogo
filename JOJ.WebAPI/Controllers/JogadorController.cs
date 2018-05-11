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

        [HttpGet]
        public IEnumerable<Models.Jogador> Get()
        {
            return new Models.Jogador().ObterTodosJogadores();
        }

        // GET: api/Jogador/5
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        [ActionName("RegisterJogador")]
        public Boolean Post(string Nome, int Posicao, int Tipo)
        {
            int sequencial = 0;
            Models.Jogador joga = new Models.Jogador();
            sequencial = joga.BuscarProximoSequencial();
            return joga.Cadastro(sequencial, Nome, Posicao, Tipo);
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
