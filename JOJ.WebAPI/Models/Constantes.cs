using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JOJ.WebAPI.Models
{
    public class Constantes
    {
        public enum PosicaoJogador
        {
            Ataque = 1,
            Defesa = 2
        }
        public enum TipoJogador
        {
            Mensalista = 1,
            Avulso = 2
        }

        public enum TipoContabil
        {
            Entrada = 1,
            Saida = 2
        }
    }
}