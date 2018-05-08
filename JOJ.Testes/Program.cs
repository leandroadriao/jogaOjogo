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
            int sequencial = 0;
            Dominio.Jogador joga = new Dominio.Jogador();
            sequencial = joga.BuscarProximoSequencial();
            joga.Cadastro(sequencial, "Dinho", 1, 2);
            sequencial = joga.BuscarProximoSequencial();
            joga.Cadastro(sequencial, "Gui", 1, 2);
            sequencial = joga.BuscarProximoSequencial();
            joga.Cadastro(sequencial, "Maconha", 1, 2);
            sequencial = joga.BuscarProximoSequencial();
            joga.Cadastro(sequencial, "Leandro", 1, 2);
            sequencial = joga.BuscarProximoSequencial();
            joga.Cadastro(sequencial, "Junior", 1, 2);
            sequencial = joga.BuscarProximoSequencial();
            joga.Cadastro(sequencial, "Omar", 1, 2);
            sequencial = joga.BuscarProximoSequencial();
            joga.Cadastro(sequencial, "Leandro", 1, 2);
            sequencial = joga.BuscarProximoSequencial();
            joga.Cadastro(sequencial, "oeoskd", 1, 2);
            var tbl = joga.ObterTodosJogadores();
            if (tbl is null)
            {

            }

        }
    }
}
