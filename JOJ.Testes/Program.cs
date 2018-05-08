using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JOJ.Testes
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dominio.Jogador joga = new Dominio.Jogador();
            var tbl = joga.ObterTodosJogadores();

        }
    }
}
